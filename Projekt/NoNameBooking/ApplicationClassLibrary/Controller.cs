﻿using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class Controller
    {
        private static Controller _instance;
        private readonly ClientRepo _clientRepo;
        private readonly DepartmentRepo _departmentRepo;
        private readonly PractitionerRepo _practitionerRepo;
        private readonly AppointmentRepo _appointmentRepo;

        public EventHandler NewClientCreatedEventHandler;

        private Controller()
        {
            _clientRepo = ClientRepo.GetInstance();
            _clientRepo.NewClientEventHandler += NewClientEventHandler;

            _departmentRepo = DepartmentRepo.GetInstance();

            _practitionerRepo = PractitionerRepo.GetInstance();

            _appointmentRepo = AppointmentRepo.GetInstance();
        }

        private void NewClientEventHandler(object sender, EventArgs e)
        {
            NewClientCreatedEventHandler.Invoke(((Client) sender).Name, e);
        }

        public static Controller GetInstance()
        {
            return _instance ?? (_instance = new Controller());
        }

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress,
            string clientSsn, string clientNote)
        {
            InputValidator.EnsureValidPhoneNumber(clientPhoneNumber);
            InputValidator.EnsureValidSsn(clientSsn);
            InputValidator.EnsureValidZip(clientAddress);

            _clientRepo.CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote);
        }

        public List<string> GetClientNames()
        {
            List<Client> clients = _clientRepo.GetClients();

            return clients.ConvertAll(client => client.Name);
        }

        public List<string> GetDepartmentNames()
        {
            List<Department> departments = _departmentRepo.GetDepartments();

            return departments.ConvertAll(department => department.Name);
        }

        public List<string> GetPractitionerNamesForDepartment(string departmentName)
        {
            Department tempDepartment = _departmentRepo.GetDepartment(departmentName);

            List<Practitioner> practitionerNames = tempDepartment.GetPractitioners();

            return practitionerNames.ConvertAll(practitioner => practitioner.Name);
        }

        public List<string> GetTreatments(string practitionerName)
        {
            Practitioner tempPractitioner = _practitionerRepo.GetPractitioner(practitionerName);
            List<AppointmentType> treatments = tempPractitioner.AppointmentTypes;

            return treatments.ConvertAll(treatmentType => treatmentType.Name);
        }

        public List<DateTime> GetBusyDates(string practitionerName, string departmentName, DateTime startDate,
            DateTime endDate)
        {
            List<DateTime> practitionerAvailableDates =
                _practitionerRepo.GetAvailableDatesForPractitioner(practitionerName, startDate, endDate);

            List<DateTime> departmentAvailableDates =
                _departmentRepo.GetAvailableDatesForDepartment(departmentName, startDate, endDate);

            List<DateTime> busyDates = DateTimeCalculator.GetBusyDates(practitionerAvailableDates, departmentAvailableDates,
                startDate, endDate);

            return busyDates;
        }

        public List<string> GetAvailableTimes(DateTime selectedDateValue, string practitionerName, string departmentName)
        {
            List<DateTime> practitionerTimes =
                _practitionerRepo.GetAvailableTimesForPractitioner(selectedDateValue, practitionerName);

            List<DateTime> departmentTimes =
                _departmentRepo.GetAvailableTimesForDepartment(selectedDateValue, departmentName);

            List<DateTime> availableTimes = DateTimeCalculator.GetAvailableTimes(practitionerTimes, departmentTimes);

            return availableTimes.ConvertAll(time => time.ToShortTimeString());
        }

        public void CreateAppointment(DateTime dateAndTime, string timeString, string departmentName, string clientName,
            string practitionerName, string appointmentTypeString, string note)
        {
            DateTime appointmentTime = InputValidator.ConvertShortTimeStringToDateTime(timeString);

            dateAndTime = dateAndTime.AddHours(appointmentTime.Hour);

            Department tempDepartment = _departmentRepo.GetDepartment(departmentName);
            Room tempRoom = tempDepartment.GetAvailableRoom(dateAndTime);

            Client tempClient = _clientRepo.GetClient(clientName);
            Practitioner tempPractitioner = _practitionerRepo.GetPractitioner(practitionerName);

            List<User> users = new List<User>() {tempClient, tempPractitioner};

            Appointment tempAppointment = _appointmentRepo.CreateAppointment(dateAndTime, tempRoom, users,
                tempPractitioner.GetAppointmentType(appointmentTypeString), note);
            _appointmentRepo.AddAppointment(tempAppointment);
        }
    }
}
