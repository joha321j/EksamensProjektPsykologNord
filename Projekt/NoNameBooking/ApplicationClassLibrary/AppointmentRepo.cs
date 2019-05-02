using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class AppointmentRepo
    {
        private static AppointmentRepo _instance;

        private readonly List<Appointment> _appointments;

        private AppointmentRepo()
        {
            _appointments = new List<Appointment>();
        }

        public static AppointmentRepo GetInstance()
        {
            return _instance ?? (_instance = new AppointmentRepo());
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public Appointment CreateAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note)
        {
            return new Appointment(dateAndTime, users, appointmentType, room, note);
        }

        public void ResetInstance()
        {
            _instance = null;
        }

        public List<Appointment> GetAppointments()
        {
            return _appointments;
        }
    }
}
