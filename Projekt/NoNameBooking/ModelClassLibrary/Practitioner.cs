using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class Practitioner : User, IBookable
    {
        public DateTime Start { get; set; }
        public TimeSpan DayLength { get; set; }

        public List<AppointmentType> TreatmentTypes { get; private set; }

        public Practitioner(DateTime start, TimeSpan dayLength)
        {
            Start = start;
            DayLength = dayLength;
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
            DateTime tempDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, Start.Hour, 0, 0);
            for (int i = 0; i < (endDate - startDate).TotalDays; i++)
            {
                for (int j = 0; j < DayLength.TotalHours; j++)
                {
                    availableDateTimes.Add(new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, tempDate.Hour, 0, 0));
                    tempDate = tempDate.AddHours(1);
                }

                tempDate = tempDate.Date.AddDays(1).AddHours(Start.Hour);
            }

            return availableDateTimes;
        }
    }
}
