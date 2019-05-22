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
        private readonly MailNotification _mailNotification;
        private readonly SmsNotification _smsNotification = new SmsNotification();
        private IPersistable _persistable;
        private readonly ClientRepo _clientRepo;
        private readonly AppointmentRepo _appointmentRepo;
        private const bool Running = true;

        public AppointmentNotification(List<Appointment> tempAppointments, AppointmentRepo appointmentRepo, IPersistable persistable)
        {
            _appointments = tempAppointments;

            _persistable = persistable;

            _clientRepo = ClientRepo.GetInstance(_persistable);
            _mailNotification = new MailNotification(_persistable);

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

            while (Running)
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
                                _mailNotification.SendReminderMail(user);
                                appointment.EmailNotification = false;
                                _persistable.EditAppointment(appointment);
                            }
                        }

                    }
                }
                Thread.Sleep(TimeSpan.FromMinutes(5));
            }
            
        }

        public void AppointmentCreatedNotification(Appointment appointment)
        {
            if (appointment.EmailNotification)
            {
                _mailNotification.AppointmentCreatedEmail(appointment);
            }

            if (appointment.SmsNotification)
            {
                _smsNotification.AppointmentCreatedSms(appointment);
            }
        }

        public void AppointmentDeletedNotification(Appointment appointment)
        {
            if (appointment.EmailNotification)
            {
                _mailNotification.AppointmentDeletedEmail(appointment);
            }

            if (appointment.SmsNotification)
            {
                _smsNotification.AppointmentDeletedSms(appointment);
            }
        }

        public void AppointmentUpdatedNotification(Appointment appointment)
        {
            if (appointment.EmailNotification)
            {
                _mailNotification.AppointmentUpdatedEmail(appointment);
            }

            if (appointment.SmsNotification)
            {
                _smsNotification.AppointmentUpdatedSms(appointment);
            }
        }
    }
}
