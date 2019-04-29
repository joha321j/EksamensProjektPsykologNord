using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Schema;

namespace ModelClassLibrary
{
    public class Room : IBookable
    {
        private readonly List<Appointment> _appointments;
        public string Name { get; set; }

        private int _dayLength;
        private DateTime _starTime;

        public Room(string name, DateTime startHour = default(DateTime), int dayLength = 24)
        {
            Name = name;

            _appointments = new List<Appointment>();

            _dayLength = dayLength;

            if (startHour == default(DateTime))
            {
                _starTime = new DateTime(startHour.Year, startHour.Month, startHour.Day, 0, 0, 0);
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
            foreach (Appointment appointment in _appointments)
            {
                availableDateTimes.Remove(appointment.DateAndTime);
            }

            return availableDateTimes;
        }

        private List<DateTime> GetAvailableDateTimes(DateTime startDate, DateTime endDate)
        {
            List<DateTime> availableDateTimes = new List<DateTime>();
            DateTime tempDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, _starTime.Hour, _starTime.Minute, _starTime.Second);
            for (int i = 0; i < (endDate - startDate).TotalDays; i++)
            {
                for (int j = 0; j < _dayLength; j++)
                {
                    availableDateTimes.Add(new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, tempDate.Hour, 0, 0));
                    tempDate = tempDate.AddHours(1);
                }

                tempDate = tempDate.Date.AddDays(1);
            }

            return availableDateTimes;
        }

        public void AddAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }
    }
}
