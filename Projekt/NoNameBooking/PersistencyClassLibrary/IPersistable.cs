﻿using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace PersistencyClassLibrary
{
    public interface IPersistable
    {
        List<Client> GetClients();
        List<Appointment> GetAppointments(List<User> users, List<Department> departments);
        List<Department> GetDepartments(List<Practitioner> practitioners);
        List<Practitioner> GetPractitioners();
        void SaveAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note);
        void RemoveAppointment(string clientName, DateTime dateAndTime);
        int SaveUser(string clientName, string clientAddress, string clientPhoneNumber, string clientEmail);
        void SaveClient(int clientId, string clientNote, string clientSsn);
    }
}