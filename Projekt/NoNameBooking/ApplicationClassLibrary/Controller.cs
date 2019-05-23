using System;
using System.Collections.Generic;
using ModelClassLibrary;
using PersistencyClassLibrary; 

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
        public EventHandler NewAppointmentCreatedEventHandler;

        private Controller()
        {
            IPersistable persistable = new DbController();
            
            _clientRepo = ClientRepo.GetInstance(persistable);
            _clientRepo.NewClientEventHandler += NewClientEventHandler;

            _practitionerRepo = PractitionerRepo.GetInstance(persistable);

            _departmentRepo = DepartmentRepo.GetInstance(persistable, _practitionerRepo.GetPractitioners());

            _appointmentRepo = AppointmentRepo.GetInstance(persistable, GetUsers(), _departmentRepo.GetDepartments());
            _appointmentRepo.AppointmentsChangedEventHandler += AppointmentsChangedEventHandler;

            UpdateFromDatabase updateFromDatabase = UpdateFromDatabase.GetInstance(persistable,
                _clientRepo.GetClients(), _appointmentRepo.GetAppointments(), _practitionerRepo.GetPractitioners(),
                _departmentRepo.GetDepartments());

            updateFromDatabase.ClientsUpdatedEventHandler += _clientRepo.Update;
            updateFromDatabase.AppointmentsUpdatedEventHandler += _appointmentRepo.Update;

        }

        public List<User> GetUsers()
        {
            List<User> tempUsers = new List<User>();
            tempUsers.AddRange(_clientRepo.GetClients());
            tempUsers.AddRange(_practitionerRepo.GetPractitioners());

            return tempUsers;

        }

        private void NewClientEventHandler(object sender, EventArgs e)
        {
            NewClientCreatedEventHandler?.Invoke(((Client) sender)?.Name, e);
        }

        private void AppointmentsChangedEventHandler(object sender, EventArgs e)
        {
            NewAppointmentCreatedEventHandler?.Invoke(sender, e);
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

            _clientRepo.CreateAndAddClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote);
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

        /// <summary>
        /// Returns a list of unavailable dates based on available dates for practitioners and department.
        /// </summary>
        /// <param name="practitionerName"></param>
        /// <param name="departmentName"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a list of times you can select.
        /// </summary>
        /// <param name="selectedDateValue"></param>
        /// <param name="practitionerName"></param>
        /// <param name="departmentName"></param>
        /// <returns></returns>
        public List<string> GetAvailableTimes(DateTime selectedDateValue, string practitionerName, string departmentName)
        {
            List<DateTime> practitionerTimes =
                _practitionerRepo.GetAvailableTimesForPractitioner(selectedDateValue, practitionerName);

            List<DateTime> departmentTimes =
                _departmentRepo.GetAvailableTimesForDepartment(selectedDateValue, departmentName);

            List<DateTime> availableTimes = DateTimeCalculator.GetAvailableTimes(practitionerTimes, departmentTimes);

            return availableTimes.ConvertAll(time => time.ToShortTimeString());
        }

        public void CreateAppointment(DateTime date, string timeString, string departmentName, string clientName,
            string practitionerName, string appointmentTypeString, string note, TimeSpan notificationTime, Boolean emailNotification, Boolean smsNotification)
        {
            DateTime appointmentTime = InputValidator.ConvertShortTimeStringToDateTime(timeString);

            date = date.AddHours(appointmentTime.Hour);

            Client tempClient = _clientRepo.GetClient(clientName);

            Practitioner tempPractitioner = _practitionerRepo.GetPractitioner(practitionerName);
            AppointmentType tempAppointmentType = tempPractitioner.GetAppointmentType(appointmentTypeString);

            Department tempDepartment = _departmentRepo.GetDepartment(departmentName);
            Room tempRoom = tempDepartment.GetAvailableRoom(date, tempAppointmentType.Duration);

            List<User> users = new List<User>() {tempClient, tempPractitioner};

            _appointmentRepo.CreateAndAddAppointment(date, tempRoom, users,
                tempAppointmentType, note, notificationTime, emailNotification, smsNotification);
        }

        public List<UserView> GetPractitionerFromAppointmentView(AppointmentView appoView)
        {
            List<UserView> users = appoView.Users;

            List<UserView> practitioner = new List<UserView>();

            foreach (UserView user in users)
            {
                if (_practitionerRepo.IsPractitioner(user))
                {
                    practitioner.Add(user);
                }
            }

            return practitioner;
        }

        public List<UserView> GetClientsFromAppointmentView(AppointmentView appoView)
        {
            List<UserView> users = appoView.Users;

            List<UserView> clients = new List<UserView>();

            foreach (UserView user in users)
            {
                if (_clientRepo.IsClient(user))
                {
                    clients.Add(user);
                }
            }

            return clients;
        }

        public void RemoveAppointment(int appointmentId)
        {                        
            _appointmentRepo.RemoveAppointment(appointmentId);
        }

        public DepartmentView GetDepartmentViewFromRoomId(int id)
        {
           return _departmentRepo.GetDepartmentViewFromRoomId(id);
        }

        public List<AppointmentView> GetAllAppointmentsByPracId(int id, DateTime startDate, DateTime endDate)
        {
            List<AppointmentView> appointmentViews = _appointmentRepo.GetAppointmentsByPractitionerId(id);
            
            List<AppointmentView> returnList = appointmentViews.FindAll(appointment =>
                appointment.DateAndTime > startDate && appointment.DateAndTime < endDate);
            return returnList;
        }

        public DateTime GetMondayDate(DateTime today)
        {
            int weekNumber = DateTimeCalculator.GetIso8601WeekOfYear(today);

            return DateTimeCalculator.FirstDateOfWeek(today.Year, weekNumber);
        }

        public void EditAppointment(AppointmentView appointmentView)
        {
            _appointmentRepo.EditAppointment(appointmentView);
        }

        public List<PractitionerView> GetPractitioners()
        {
            List<Practitioner> practitioners = _practitionerRepo.GetPractitioners();

            return practitioners.ConvertAll(practitioner => new PractitionerView(practitioner.Id, practitioner.Name,
                practitioner.PhoneNumber, practitioner.Address, practitioner.Email, practitioner.Start,
                practitioner.DayLength));
        }

        public double GetAppointmenmtPrice(int appoId)
        {
            AppointmentView tempAppo = _appointmentRepo.GetAppointmentById(appoId);
            return tempAppo.Price;
        }

        public RoomView GetRoomByAppointmentId(int appointmentId, string departmentName)
        {
            RoomView roomView = _departmentRepo.GetRoomByAppointmentId(appointmentId, departmentName);
            return roomView;
        }

        public AppointmentTypeView GetAppointmentTypeByName(string typeName, string practitionerName)
        {
            AppointmentType tempType = _practitionerRepo.GetTreatmentByTreatmentName(typeName, practitionerName);
            AppointmentTypeView appoTypeView = new AppointmentTypeView(tempType.Id,tempType.Name,tempType.Duration,tempType.StandardPrice);

            return appoTypeView;
        }

        public AppointmentView GetAppointmentById(int appoId)
        {
            return _appointmentRepo.GetAppointmentById(appoId);
        }
    }
}
