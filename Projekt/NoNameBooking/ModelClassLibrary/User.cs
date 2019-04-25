using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class User
    {
        public string Name { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public string Email { get; }

        private List<Appointment> appointments = new List<Appointment>();

        public User(string name = "", string address = "", string phoneNumber = "", string email ="")
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void AddAppointment(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public Appointment GetAppointment(Appointment appointment)
        {
            return appointments.Find(a => a.Equals(appointment));
        }
    }
}
