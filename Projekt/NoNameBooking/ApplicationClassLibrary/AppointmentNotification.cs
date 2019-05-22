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

        public AppointmentNotification(List<Appointment> tempAppointments, AppointmentRepo appointmentRepo)
        {
            _appointments = tempAppointments;
            _clientRepo = ClientRepo.GetInstance(_persistable);
            _appointmentRepo = appointmentRepo;
            appointmentRepo.NewAppointmentEventHandler += UpdateAppointments;
        }

        private void UpdateAppointments(object sender, EventArgs e)
        {
            _appointments = _appointmentRepo.GetAppointments();
        }

        public void EmailUpdateThread()
        {
            Thread emailThread = new Thread(EmailSender);
            emailThread.Start();
        }

        public void EmailSender()
        {
            List<Appointment> removeList = new List<Appointment>();
            foreach (Appointment appointment in _appointments)
            {
                DateTime now = DateTime.Now;
                if (appointment.DateAndTime > now && appointment.DateAndTime <= now.AddHours(24))
                {
                    foreach (User user in appointment.Participants)
                    {
                        UserView tempUserView = new UserView(user.Id, user.Name, user.PhoneNumber, user.Address, user.Email);
                        if (_clientRepo.IsClient(tempUserView))
                        {
                            User emailUser = new User(tempUserView.Name, tempUserView.Address, tempUserView.PhoneNumber, tempUserView.Email);
                            _mailNotification.SendTestMail(emailUser);
                            removeList.Add(appointment);
                        }
                    }
                    
                }
            }
            foreach (Appointment appointment in removeList)
            {
                _appointments.Remove(appointment);
            }
            Thread.Sleep(TimeSpan.FromMinutes(5));
        }

    }
}
