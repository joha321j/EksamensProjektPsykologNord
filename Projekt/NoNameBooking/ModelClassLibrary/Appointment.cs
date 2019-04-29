using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public class Appointment
    {
        public DateTime DateAndTime { get; set; }
        public Room Location { get; set; }
        public List<User> Participants { get; set; }
        public double Price { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string Note { get; set; }

        public Appointment()
        {

        }
        public Appointment(DateTime dateAndTime, List<User> participants, AppointmentType appointmentType, Room testRoom, string note, double price = 0)
        {
            DateAndTime = dateAndTime;
            Participants = participants;
            AppointmentType = appointmentType;
            Location = testRoom;
            Note = note;

            testRoom.AddAppointment(this);

            foreach (User participant in participants)
            {
                participant.AddAppointment(this);
            }

            Price = Math.Abs(price) < 0.01 ? appointmentType.StandardPrice : price;
        }
    }
}
