﻿using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    public class AppointmentRepo
    {
        private IPersistable _persistable;
        private static AppointmentRepo _instance;

        private readonly List<Appointment> _appointments = new List<Appointment>();

        private AppointmentRepo(IPersistable persistable, List<User> users, List<Department> departments)
        {
            _persistable = persistable;
            _appointments = _persistable.GetAppointments(users, departments);
        }

        public static AppointmentRepo GetInstance(IPersistable persistable, List<User> users, List<Department> departments)
        {
            return _instance ?? (_instance = new AppointmentRepo(persistable, users, departments));
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void CreateAndAddAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note)
        {
            Appointment tempAppointment = CreateAppointment(dateAndTime, users, appointmentType, room, note);
            AddAppointment(tempAppointment);
            _persistable.SaveAppointment(dateAndTime, room, users, appointmentType, note);
        }

        private Appointment CreateAppointment(DateTime dateAndTime, List<User> users, AppointmentType appointmentType, Room room, string note)
        {
            return new Appointment(dateAndTime, users, appointmentType, room, note);
        }

        public void ResetInstance()
        {
            _instance = null;
        }

        public List<Appointment> GetAppointments()
        {
            return _appointments;
        }

        public List<AppointmentView> GetAppointmentsByPracId(int id)
        {
            
            List<AppointmentView> appointments = new List<AppointmentView>();
            foreach (Appointment item in _appointments)
            {
                foreach (User person in item.Participants)
                {
                    if (person.Id == id)
                    {
                        AppointmentView appView = new AppointmentView(item.Id, item.DateAndTime,
                            new AppointmentTypeView(item.AppointmentType.Id, item.AppointmentType.Name,
                                item.AppointmentType.Duration, item.AppointmentType.StandardPrice));

                        appointments.Add(appView);
                    }
                }
            }
            return appointments;
        }

        public void RemoveAppointment(int appointmentId)
        {            
            _persistable.RemoveAppointment(appointmentId);            
        }

        public AppointmentView GetAppointmentById(int appoId)
        {
            Appointment appo = new Appointment();
            appo = _appointments.Find(app => app.Id == appoId);
            List<UserView> userViews = new List<UserView>();
            int i = 0;
            foreach (User user in appo.Participants)
            {
                UserView view = new UserView(appo.Participants[i].Id, appo.Participants[i].Name, appo.Participants[1].PhoneNumber, appo.Participants[1].Address, appo.Participants[1].Email);
                userViews.Add(view);
                i++;
            }
            AppointmentTypeView typeView = new AppointmentTypeView(appo.AppointmentType.Id, appo.AppointmentType.Name, appo.AppointmentType.Duration, appo.AppointmentType.StandardPrice);
            RoomView roomView = new RoomView(appo.Location.Id, appo.Location.Name);
            AppointmentView appoView = new AppointmentView(appo.Id, appo.DateAndTime, userViews, typeView, roomView, appo.Note, appo.Price);
                                    
            return appoView;
        }

        public void EditAppointment(AppointmentView appointmentView)
        {            
            Appointment appointment = new Appointment(appointmentView.Id, appointmentView.DateAndTime);
            _persistable.EditAppointment(appointment);
        }
    }
}
