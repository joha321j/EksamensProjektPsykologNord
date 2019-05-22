using System;
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
        private readonly AppointmentNotification _updateAppointmentNotification;

        private List<Appointment> _appointments;

        public event EventHandler NewAppointmentEventHandler;

        private AppointmentRepo(IPersistable persistable, List<User> users, List<Department> departments)
        {
            _persistable = persistable;
            _appointments = _persistable.GetAppointments(users, departments);
            _updateAppointmentNotification = new AppointmentNotification(_appointments, this, _persistable);
        }

        public static AppointmentRepo GetInstance(IPersistable persistable, List<User> users, List<Department> departments)
        {
            return _instance ?? (_instance = new AppointmentRepo(persistable, users, departments));
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public void CreateAndAddAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note, TimeSpan notificationTime, Boolean emailNotification, Boolean smsNotification)
        {
            Appointment tempAppointment = CreateAppointment(dateAndTime, users, appointmentType, room, note, notificationTime, emailNotification, smsNotification);
            AddAppointment(tempAppointment);
            _persistable.SaveAppointment(dateAndTime, room, users, appointmentType, note, notificationTime, emailNotification, smsNotification);
            NewAppointmentEventHandler?.Invoke(tempAppointment, EventArgs.Empty);
        }

        private Appointment CreateAppointment(DateTime dateAndTime, List<User> users, AppointmentType appointmentType, Room room, string note, TimeSpan notificationTime, Boolean emailNotification, Boolean smsNotification)
        {
            return new Appointment(dateAndTime, users, appointmentType, room, note, notificationTime, emailNotification, smsNotification);
        }

        public void ResetInstance()
        {
            _instance = null;
        }

        public List<Appointment> GetAppointments()
        {
            return _appointments;
        }

        public List<AppointmentView> GetAppointmentsByPractitionerId(int id)
        {
            
            List<AppointmentView> appointments = new List<AppointmentView>();
            foreach (Appointment appointment in _appointments)
            {
                foreach (User person in appointment.Participants)
                {
                    if (person.Id == id)
                    {
                        List<UserView> userViews = new List<UserView>();
                        foreach (User user in appointment.Participants)
                        {
                            UserView view = new UserView(user.Id, user.Name, user.PhoneNumber, user.Address, user.Email);
                            userViews.Add(view);
                        }
                        RoomView roomView = new RoomView(appointment.Location.Id, appointment.Location.Name);
                        AppointmentView appView = new AppointmentView(appointment.Id, appointment.DateAndTime, userViews,
                            new AppointmentTypeView(appointment.AppointmentType.Id, appointment.AppointmentType.Name,
                                appointment.AppointmentType.Duration, appointment.AppointmentType.StandardPrice), roomView, appointment.Note, appointment.Price, appointment.NotficationTime, appointment.EmailNotification, appointment.SMSNotification);

                        appointments.Add(appView);
                    }
                }
            }
            return appointments;
        }

        public void RemoveAppointment(int appointmentId)
        {            
            _persistable.RemoveAppointment(appointmentId);
            Appointment appointment = _appointments.Find(appo => appo.Id == appointmentId);
            _appointments.Remove(appointment);
            
            NewAppointmentEventHandler?.Invoke(appointmentId, EventArgs.Empty);
        }

        public AppointmentView GetAppointmentById(int appoId)
        {
            Appointment appointment = _appointments.Find(app => app.Id == appoId);
            List<UserView> userViews = new List<UserView>();

            foreach (User user in appointment.Participants)
            {
                UserView view = new UserView(user.Id, user.Name, user.PhoneNumber, user.Address, user.Email);
                userViews.Add(view);
            }

            AppointmentTypeView typeView = new AppointmentTypeView(appointment.AppointmentType.Id, appointment.AppointmentType.Name, appointment.AppointmentType.Duration, appointment.AppointmentType.StandardPrice);
            RoomView roomView = new RoomView(appointment.Location.Id, appointment.Location.Name);
            AppointmentView appointmentView = new AppointmentView(appointment.Id, appointment.DateAndTime, userViews, typeView, roomView, appointment.Note, appointment.Price, appointment.NotficationTime, appointment.EmailNotification, appointment.SMSNotification);
                                    
            return appointmentView;
        }

        public void EditAppointment(AppointmentView appointmentView)
        {            
            Appointment appointment = new Appointment(appointmentView.Id, appointmentView.DateAndTime, appointmentView.Note);
            Appointment tempAppo = _appointments.Find(appointmentOne => appointmentOne.Id == appointmentView.Id);

            tempAppo.DateAndTime = appointmentView.DateAndTime;
            tempAppo.Note = appointmentView.Note;

            _persistable.EditAppointment(appointment);
            NewAppointmentEventHandler?.Invoke(appointment, EventArgs.Empty);
        }

        public void SendEmail()
        {
            _updateAppointmentNotification.EmailUpdateThread();
        }

        public void Update()
        {
            _appointments = GetAppointments();
        }
    }
}
