using System;
using System.Collections.Generic;


namespace ModelClassLibrary
{
    public class Room : IBookable
    {
        public int Id { get; set; }
        public readonly List<Appointment> Appointments;
        public string Name { get; set; }

        private readonly int _dayLength;
        private readonly DateTime _startTime;

        public Room(string name, DateTime startHour = default(DateTime), int dayLength = 24, int id = -1)
        {
            Name = name;

            Id = id;

            Appointments = new List<Appointment>();

            _dayLength = dayLength;

            if (startHour == default(DateTime))
            {
                _startTime = new DateTime(startHour.Year, startHour.Month, startHour.Day, 0, 0, 0);
            }

        }

        public List<DateTime> GetAvailability(DateTime startDate, DateTime endDate)
        {
            // Get all possible available DateTimes.
            List<DateTime> availableDateTimes = GetAvailableDateTimes(startDate, endDate);

            // Remove available DateTimes that have appointments at the same time.

            availableDateTimes = RemoveBookedDateTimes(availableDateTimes);

            return availableDateTimes;
        }

        private List<DateTime> RemoveBookedDateTimes(List<DateTime> availableDateTimes)
        {
            foreach (Appointment appointment in Appointments)
            {
                DateTime temp = appointment.DateAndTime;
                for (int i = 0; i < appointment.AppointmentType.Duration.TotalHours; i++)
                {
                    availableDateTimes.Remove(temp);
                    temp = temp.AddHours(1);
                }
                
            }

            return availableDateTimes;
        }

        private List<DateTime> GetAvailableDateTimes(DateTime startDate, DateTime endDate)
        {
            List<DateTime> availableDateTimes = new List<DateTime>();
            DateTime tempDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, _startTime.Hour, _startTime.Minute, _startTime.Second);
            for (int i = 0; i < (endDate - startDate).TotalDays; i++)
            {
                for (int j = 0; j < _dayLength; j++)
                {
                    availableDateTimes.Add(new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, tempDate.Hour, 0, 0));
                    tempDate = tempDate.AddHours(1);
                }

                tempDate = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, _startTime.Hour, 0, 0);
            }

            return availableDateTimes;
        }

        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }

        public bool IsAvailable(DateTime dateAndTime, TimeSpan appointmentDuration)
        {
            List<DateTime> availableDateTimes = GetAvailability(dateAndTime.Date, dateAndTime.Date.AddDays(1));

            bool isAvailable = false;

            for (int i = 0; i < appointmentDuration.Hours; i++)
            {
                isAvailable = availableDateTimes.Contains(dateAndTime);
                dateAndTime = dateAndTime.AddHours(1);
            }

            return isAvailable;
        }
    }
}
