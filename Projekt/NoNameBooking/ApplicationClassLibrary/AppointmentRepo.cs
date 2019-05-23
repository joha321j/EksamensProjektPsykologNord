using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    public class AppointmentRepo
    {
        private readonly IPersistable _persistable;
        private static AppointmentRepo _instance;
        private readonly AppointmentNotification _updateAppointmentNotification;
        
        private readonly object _lockingObject = new object();

        private List<Appointment> _appointments;

        public event EventHandler AppointmentsChangedEventHandler;

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
            lock (_lockingObject)
            {
                _appointments.Add(appointment);
            }
        }

        public void CreateAndAddAppointment(DateTime dateAndTime, Room room, List<User> users, AppointmentType appointmentType, string note, TimeSpan notificationTime, Boolean emailNotification, Boolean smsNotification)
        {
            lock (_lockingObject)
            {
                Appointment tempAppointment = CreateAppointment(dateAndTime, users, appointmentType, room, note, notificationTime, emailNotification, smsNotification);
                AddAppointment(tempAppointment);

                _updateAppointmentNotification.AppointmentCreatedNotification(tempAppointment);

                _persistable.SaveAppointment(dateAndTime, room, users, appointmentType, note, notificationTime, emailNotification, smsNotification);

                AppointmentsChangedEventHandler?.Invoke(tempAppointment, EventArgs.Empty);
            }
            
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
            lock (_lockingObject)
            {
                return _appointments;
            }
        }

        public List<AppointmentView> GetAppointmentsByPractitionerId(int id)
        {
            lock (_lockingObject)
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
                                    appointment.AppointmentType.Duration, appointment.AppointmentType.StandardPrice), roomView, appointment.Note, appointment.Price, appointment.NotificationTime, appointment.EmailNotification, appointment.SmsNotification);

                            appointments.Add(appView);
                        }
                    }
                }

                return appointments;
            }
        }

        public void RemoveAppointment(int appointmentId)
        {
            lock (_lockingObject)
            {
                _persistable.RemoveAppointment(appointmentId);
                Appointment appointment = _appointments.Find(appointment1 => appointment1.Id == appointmentId);

                _updateAppointmentNotification.AppointmentDeletedNotification(appointment);
                _appointments.Remove(appointment);
            }
            
            AppointmentsChangedEventHandler?.Invoke(appointmentId, EventArgs.Empty);
        }

        public AppointmentView GetAppointmentById(int appointmentId)
        {
            lock (_lockingObject)
            {
                Appointment appointment = _appointments.Find(app => app.Id == appointmentId);
                List<UserView> userViews = new List<UserView>();

                foreach (User user in appointment.Participants)
                {
                    UserView view = new UserView(user.Id, user.Name, user.PhoneNumber, user.Address, user.Email);
                    userViews.Add(view);
                }

                AppointmentTypeView typeView = new AppointmentTypeView(appointment.AppointmentType.Id, appointment.AppointmentType.Name, appointment.AppointmentType.Duration, appointment.AppointmentType.StandardPrice);
                RoomView roomView = new RoomView(appointment.Location.Id, appointment.Location.Name);
                AppointmentView appointmentView = new AppointmentView(appointment.Id, appointment.DateAndTime, userViews, typeView, roomView, appointment.Note, appointment.Price, appointment.NotificationTime, appointment.EmailNotification, appointment.SmsNotification);

                return appointmentView;
            }
            
        }

        public void EditAppointment(AppointmentView appointmentView)
        {
            lock (_lockingObject)
            {
                Appointment appointment = new Appointment(appointmentView.Id, appointmentView.DateAndTime, appointmentView.Note, appointmentView.NotficationTime,appointmentView.EmailNotification,appointmentView.SMSNotification);
                Appointment tempAppointment = _appointments.Find(appointmentOne => appointmentOne.Id == appointmentView.Id);

                tempAppointment.DateAndTime = appointmentView.DateAndTime;
                tempAppointment.Note = appointmentView.Note;
                tempAppointment.EmailNotification = appointment.EmailNotification;
                tempAppointment.SmsNotification = appointment.SmsNotification;
                tempAppointment.NotificationTime = appointment.NotificationTime;

                _updateAppointmentNotification.AppointmentUpdatedNotification(tempAppointment);

                _persistable.EditAppointment(tempAppointment);
                AppointmentsChangedEventHandler?.Invoke(appointment, EventArgs.Empty);
            }
        }

        public void Update(object sender, EventArgs eventArgs)
        {
            lock (_lockingObject)
            {
                _appointments = (List<Appointment>) sender;
                AppointmentsChangedEventHandler?.Invoke(_appointments, EventArgs.Empty);
            }
            
        }
    }
}
