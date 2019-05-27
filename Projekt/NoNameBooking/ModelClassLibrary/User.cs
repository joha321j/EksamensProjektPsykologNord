using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelClassLibrary
{
    public class User
    {
        public int Id { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public string Email { get; }

        protected readonly List<Appointment> Appointments = new List<Appointment>();

        public User(string name = "", string address = "", string phoneNumber = "", string email ="", int id = -1)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Id = id;
        }

        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public Appointment GetAppointment(Appointment appointment)
        {
            return Appointments.Find(a => a.Equals(appointment));
        }

        public Appointment GetAppointment()
        {
            return Appointments.Last();
        }
    }
}
