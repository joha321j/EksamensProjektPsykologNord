using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    class AppointmentRepo
    {
        private static AppointmentRepo _instance;

        private List<Appointment> _appointments;

        private AppointmentRepo()
        {
            _appointments = new List<Appointment>();
        }

        public static AppointmentRepo GetInstance()
        {
            return _instance ?? (_instance = new AppointmentRepo());
        }

        public void AddAppointment(DateTime dateAndTime, Room tempRoom, List<User> users, object getAppointmentType, string note)
        {
            throw new NotImplementedException();
        }
    }
}
