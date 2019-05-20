using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using PersistencyClassLibrary;
using System.Threading;

namespace ApplicationClassLibrary
{
    class UpdateAppointmentEmailList
    {
        List<Appointment> appointments = new List<Appointment>();
        MailNotification mailNotification = new MailNotification();
        private IPersistable _persistable;
        private readonly ClientRepo _clientRepo;

        public UpdateAppointmentEmailList(Appointment appointment)
        {
            appointments.Add(appointment);
            _clientRepo = ClientRepo.GetInstance(_persistable);
        }

        public UpdateAppointmentEmailList(List<Appointment> tempAppointments)
        {
            appointments = tempAppointments;
            _clientRepo = ClientRepo.GetInstance(_persistable);
        }

        public void emailUpdateThread()
        {
            Thread emailThread = new Thread(emailSender);
            emailThread.Start();
        }

        public void emailSender()
        {
            List<Appointment> removeList = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                DateTime now = DateTime.Now;
                User emailUser;
                if (appointment.DateAndTime > now && appointment.DateAndTime <= now.AddHours(24))
                {
                    foreach (User user in appointment.Participants)
                    {
                        UserView tempUserView = new UserView(user.Id, user.Name, user.PhoneNumber, user.Address, user.Email);
                        if (_clientRepo.IsClient(tempUserView))
                        {
                            emailUser = new User(tempUserView.Name, tempUserView.Address, tempUserView.PhoneNumber, tempUserView.Email);
                            mailNotification.SendTestMail(emailUser);
                            removeList.Add(appointment);
                        }
                    }
                    
                }
            }
            foreach (Appointment appointment in removeList)
            {
                appointments.Remove(appointment);
            }
            Thread.Sleep(TimeSpan.FromMinutes(5));
        }

    }
}
