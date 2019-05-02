﻿using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ViewModelClassLibrary
{
    public class UserViewModel
    {
        public void CreateAppointment(DateTime dateAndTime, List<User> participants,
            AppointmentType appointmentType, string note, Room testRoom)
        {
            Appointment newAppointment = new Appointment(dateAndTime, participants, appointmentType, testRoom, note);

            foreach (User user in participants)
            {
                user.AddAppointment(newAppointment);
            }
        }
    }
}