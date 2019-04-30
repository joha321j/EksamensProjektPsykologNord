using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class UserViewModel
    {
        public void CreateAppointment(DateTime dateAndTime, List<User> participants,
            AppointmentType appointmentType, string note, Room room)
        {
            Appointment newAppointment = new Appointment(dateAndTime, participants, appointmentType, room, note);

            foreach (User user in participants)
            {
                user.AddAppointment(newAppointment);
            }
        }
    }
}
