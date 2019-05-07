﻿using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public interface IPersistable
    {
        List<Client> GetClients();
        List<Appointment> GetAppointments(List<User> users);
        List<Department> GetDepartments();
        List<Practitioner> GetPractitioners();
        void SaveAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note);
        void RemoveAppointment(string clientName, DateTime dateAndTime);        
    }
}