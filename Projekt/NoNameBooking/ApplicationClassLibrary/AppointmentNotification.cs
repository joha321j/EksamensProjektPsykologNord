using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using PersistencyClassLibrary;
using System.Threading;

namespace ApplicationClassLibrary
{
    class AppointmentNotification
    {
        private List<Appointment> _appointments;
        private readonly MailNotification _mailNotification = new MailNotification();
        private IPersistable _persistable;
        private readonly ClientRepo _clientRepo;
        private readonly AppointmentRepo _appointmentRepo;
        private readonly bool _running = true;

        public AppointmentNotification(List<Appointment> tempAppointments, AppointmentRepo appointmentRepo, IPersistable persistable)
        {
            _appointments = tempAppointments;

            _persistable = persistable;

            _clientRepo = ClientRepo.GetInstance(_persistable);

            _appointmentRepo = appointmentRepo;
            appointmentRepo.AppointmentsChangedEventHandler += UpdateAppointments;
        }

        private void UpdateAppointments(object sender, EventArgs e)
        {
            // Make a copy of the list of appointments in the appointment repo.
            _appointments = new List<Appointment>(_appointmentRepo.GetAppointments());
        }

        public void EmailUpdateThread()
        {
            Thread emailThread = new Thread(EmailSender) {IsBackground = true};
            emailThread.Start();
        }

        public void EmailSender()
        {

            while (_running)
            {
                foreach (Appointment appointment in _appointments)
                {
                    DateTime now = DateTime.Now;
                    int hoursToAppointment = appointment.NotificationTime.Hours;

                    if (appointment.DateAndTime > now &&
                        appointment.DateAndTime <= now.AddHours(hoursToAppointment)
                        && appointment.EmailNotification)
                    {
                        foreach (User user in appointment.Participants)
                        {
                            if (_clientRepo.IsClient(user))
                            {
                                _mailNotification.SendTestMail(user);
                                appointment.EmailNotification = false;
                                _persistable.EditAppointment(appointment);
                            }
                        }

                    }
                }
                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
            
        }

    }
}
