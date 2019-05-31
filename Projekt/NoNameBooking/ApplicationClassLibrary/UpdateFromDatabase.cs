using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    internal class UpdateFromDatabase
    {
        private static UpdateFromDatabase _instance;
        private List<Client> _clients;
        private readonly List<Practitioner> _practitioners;
        private List<Appointment> _appointments;
        private readonly List<Department> _departments;
        private readonly TimeSpan _minutesToSleep = TimeSpan.FromMinutes(1);
        private static bool _running = true;
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

            Thread updateThread = new Thread(CheckForUpdates)
                { IsBackground = true};

            updateThread.Start();
        }

        private void CheckForUpdates()
        {
            while (_running)
            {
                CheckForClients();
                CheckForAppointments();
                Thread.Sleep(_minutesToSleep);
            }
            
        }

        private void CheckForClients()
        {
            List<Client> tempClients = _persistable.GetClients();

            bool newClientsInDatabase = !(tempClients.Count == _clients.Count || tempClients.All(_clients.Contains)) ;

            if (newClientsInDatabase)
            {
                _clients = tempClients;
                ClientsUpdatedEventHandler?.Invoke(_clients, EventArgs.Empty);
            }
        }

        private void CheckForAppointments()
        {
            List<User> users = new List<User>();
            users.AddRange(_clients);
            users.AddRange(_practitioners);
            List<Appointment> tempAppointments = _persistable.GetAppointments(users, _departments);

            bool newAppointmentsInDatabase = !(tempAppointments.Count == _appointments.Count || tempAppointments.All(_appointments.Contains));

            if (newAppointmentsInDatabase)
            {
                _appointments = tempAppointments;
                AppointmentsUpdatedEventHandler?.Invoke(_appointments, EventArgs.Empty);
            }
        }

        public static UpdateFromDatabase GetInstance(IPersistable persistable, List<Client> clients,
            List<Appointment> appointments, List<Practitioner> practitioners, List<Department> departments)
        {
            return _instance ?? (_instance =
                       new UpdateFromDatabase(persistable, clients, appointments, practitioners, departments));
        }

        public static void StopThread()
        {
            _running = false;
        }
    }
}
