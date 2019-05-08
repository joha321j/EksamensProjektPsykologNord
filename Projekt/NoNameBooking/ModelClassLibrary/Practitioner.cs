using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class Practitioner : User, IBookable
    {
        public DateTime Start { get; set; }
        public TimeSpan DayLength { get; set; }

        public List<AppointmentType> AppointmentTypes { get; private set; }

        public Practitioner(DateTime start, TimeSpan dayLength, string practitionerName = "", string practitionerEmail = "", string practitionerPhoneNumber = "",
            string practitionerAddress = "") : base(practitionerName, practitionerAddress, practitionerPhoneNumber, practitionerEmail)
        {
            Start = start;
            DayLength = dayLength;
            AppointmentTypes = new List<AppointmentType>();
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
                DateTime tempDate = appointment.DateAndTime;
                for (int i = 0; i < appointment.AppointmentType.Duration.TotalHours; i++)
                {
                    availableDateTimes.Remove(tempDate);
                    tempDate = tempDate.AddHours(1);
                }
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

        public List<DateTime> GetAvailableTimes(DateTime selectedDateValue)
        {
            return GetAvailability(selectedDateValue, selectedDateValue.AddDays(1));
        }

        public AppointmentType GetAppointmentType(string appointmentTypeString)
        {
            return AppointmentTypes.Find(appointment => String.Equals(appointment.Name, appointmentTypeString));
        }

        public AppointmentType GetAppointmentType(int appointmentType)
        {
            return AppointmentTypes.Find(type => type.Id == appointmentType);
        }
    }
}
