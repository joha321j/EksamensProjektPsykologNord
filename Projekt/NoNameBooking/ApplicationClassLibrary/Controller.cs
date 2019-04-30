using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class Controller
    {
        private static Controller _instance;
        private readonly ClientRepo _clientRepo;
        private readonly DepartmentRepo _departmentRepo;
        private readonly PractitionerRepo _practitionerRepo;

        public EventHandler NewClientCreatedEventHandler;

        private Controller()
        {
            _clientRepo = ClientRepo.GetInstance();
            _clientRepo.NewClientEventHandler += NewClientEventHandler;

            _departmentRepo = DepartmentRepo.GetInstance();

            _practitionerRepo = PractitionerRepo.GetInstance();
        }

        private void NewClientEventHandler(object sender, EventArgs e)
        {
            NewClientCreatedEventHandler.Invoke(((Client) sender).Name, e);
        }

        public static Controller GetInstance()
        {
            return _instance ?? (_instance = new Controller());
        }

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, string clientSsn, string clientNote)
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
            List<AppointmentType> treatments = tempPractitioner.TreatmentTypes;

            return treatments.ConvertAll(treatmentType => treatmentType.Name);
        }

        public List<DateTime> GetBusyDates(string practitionerName, string departmentName, DateTime startDate,
            DateTime endDate)
        {
            List<DateTime> busyDates = new List<DateTime>();
            List<DateTime> practitionerAvailableDates =
                _practitionerRepo.GetAvailableDatesForPractitioner(practitionerName);

            List<DateTime> departmentAvailableDates =
                _departmentRepo.GetAvailableDatesForDepartment(departmentName, startDate, endDate);

            busyDates = AvailabilityCalculator.GetBusyDates(practitionerAvailableDates, departmentAvailableDates,
                startDate, endDate);

            return busyDates;
        }
    }
}
