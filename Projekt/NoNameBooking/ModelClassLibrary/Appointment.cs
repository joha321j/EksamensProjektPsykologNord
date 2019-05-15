using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public Room Location { get; set; }
        public List<User> Participants { get; set; }
        public double Price { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string Note { get; set; }

        public Appointment()
        {

        }
        public Appointment(DateTime dateAndTime, List<User> participants, AppointmentType appointmentType, Room room, string note, double price = 0, int id = -1)
        {
            Id = id;
            DateAndTime = dateAndTime;
            Participants = participants;
            AppointmentType = appointmentType;
            Location = room;
            Note = note;

            room.AddAppointment(this);

            foreach (User participant in participants)
            {
                participant.AddAppointment(this);
            }

            Price = Math.Abs(price) < 0.01 ? appointmentType.StandardPrice : price;
        }

        public Appointment(int id, DateTime dateAndTime, string note)
        {
            Id = id;
            DateAndTime = dateAndTime;
            Note = note;
        }
    }
}
