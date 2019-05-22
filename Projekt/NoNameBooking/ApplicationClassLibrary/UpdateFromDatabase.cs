using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    class UpdateFromDatabase
    {
        private static UpdateFromDatabase _instance;
        private List<Client> _clients;
        private readonly List<Practitioner> _practitioners;
        private List<Appointment> _appointments;
        private readonly List<Department> _departments;
        private readonly TimeSpan _minutesToSleep = TimeSpan.FromMinutes(5);
        private const bool Running = true;

        private readonly IPersistable _persistable;
        public event EventHandler ClientsUpdatedEventHandler;
        public event EventHandler AppointmentsUpdatedEventHandler;

        private UpdateFromDatabase(IPersistable persistable, List<Client> clients, List<Appointment> appointments,
            List<Practitioner> practitioners, List<Department> departments)
        {
            _persistable = persistable;
            _clients = new List<Client>(clients);
            _appointments = new List<Appointment>(appointments);
            _practitioners = practitioners;
            _departments = departments;

            Thread updateThread = new Thread(CheckForUpdates) {IsBackground = true};

            updateThread.Start();
        }

        private void CheckForUpdates()
        {
            while (Running)
            {
                CheckForClients();
                CheckForAppointments();
                Thread.Sleep(_minutesToSleep);
            }
            
        }

        private void CheckForClients()
        {
            List<Client> tempClients = _persistable.GetClients();

            bool newClientsInDatabase = tempClients.All(_clients.Contains) && tempClients.Count == _clients.Count;

            if (newClientsInDatabase)
            {
                ClientsUpdatedEventHandler?.Invoke(_clients, EventArgs.Empty);
                _clients = tempClients;
            }
        }

        private void CheckForAppointments()
        {
            List<User> users = new List<User>();
            users.AddRange(_clients);
            users.AddRange(_practitioners);
            List<Appointment> tempAppointments = _persistable.GetAppointments(users, _departments);

            bool newAppointmentsInDatabase = tempAppointments.All(_appointments.Contains) && tempAppointments.Count == _appointments.Count;

            if (newAppointmentsInDatabase)
            {
                AppointmentsUpdatedEventHandler?.Invoke(_appointments, EventArgs.Empty);
                _appointments = tempAppointments;
            }
        }

        public static UpdateFromDatabase GetInstance(IPersistable persistable, List<Client> clients,
            List<Appointment> appointments, List<Practitioner> practitioners, List<Department> departments)
        {
            return _instance ?? (_instance =
                       new UpdateFromDatabase(persistable, clients, appointments, practitioners, departments));
        }
    }
}
