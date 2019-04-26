using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class Room : IBookable
    {
        private List<Appointment> _appointments;
        public string Name { get; set; }
        public Department Department { get; }

        public Room(string name, Department department)
        {
            Name = name;
            Department = department;

            _appointments = new List<Appointment>();
        }

        public List<DateTime> GetAvailability(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }
    }
}
