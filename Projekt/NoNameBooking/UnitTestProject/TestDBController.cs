﻿using System;
using System.Collections.Generic;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace UnitTestProject
{
    class TestDbController : IPersistable
    {
        public List<Client> GetClients()
        {
            return new List<Client>();
        }

        public List<Appointment> GetAppointments(List<User> users, List<Department> departments)
        {
            return new List<Appointment>();
        }

        public List<Department> GetDepartments(List<Practitioner> practitioners)
        {
            return new List<Department>();
        }

        public List<Practitioner> GetPractitioners()
        {
            return new List<Practitioner>();
        }

        public void SaveAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note, TimeSpan notificationTime, bool emailNotification, bool smsNotification)
        {
            //Done
        }

        public void RemoveAppointment(int appointmentId)
        {
            throw new NotImplementedException();
        }

        public void RemoveAppointment(string clientName, DateTime dateAndTime)
        {
            //Done
        }

        public int SaveUser(string clientName, string clientAddress, string clientPhoneNumber, string clientEmail)
        {
            return -1;
        }

        public void SaveClient(int clientId, string clientNote, string clientSsn)
        {
           //done
        }

        public void EditAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
