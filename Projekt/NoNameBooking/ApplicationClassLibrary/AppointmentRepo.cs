using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class AppointmentRepo
    {
        private IPersistable _persistable;
        private static AppointmentRepo _instance;

        private readonly List<Appointment> _appointments;

        private AppointmentRepo(IPersistable persistable)
        {
            _persistable = persistable;
            _appointments = _persistable.GetAppointments();
        }

        public static AppointmentRepo GetInstance(IPersistable persistable)
        {
            return _instance ?? (_instance = new AppointmentRepo(persistable));
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void CreateAndAddAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note)
        {
            Appointment tempAppointment = CreateAppointment(dateAndTime, users, appointmentType, room, note);
            AddAppointment(tempAppointment);
        }

        private Appointment CreateAppointment(DateTime dateAndTime, List<User> users, AppointmentType appointmentType, Room room, string note)
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
