using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationClassLibrary
{
    internal class AvailabilityCalculator
    {
        public static List<DateTime> GetBusyDates(List<DateTime> practitionerAvailableDates,
            List<DateTime> departmentAvailableDates, DateTime startDate, DateTime endDate)
        {
            List<DateTime> busyDates = PopulateDateList(startDate, endDate);


            var availableDateTimes = from date in practitionerAvailableDates
                join practitionerDate in departmentAvailableDates on date equals
                    practitionerDate
                select date;

            List<DateTime> availableDates = ConvertAvailableDateTimesToAvailableDates(availableDateTimes);

            busyDates = busyDates.Except(availableDates).ToList();

            return busyDates;
        }

        private static List<DateTime> ConvertAvailableDateTimesToAvailableDates(IEnumerable<DateTime> availableDateTimes)
        {
            List<DateTime> availableDates = new List<DateTime>();

            foreach (DateTime availableDate in availableDateTimes)
            {
                DateTime tempDate = new DateTime(availableDate.Year, availableDate.Month, availableDate.Day);
                if (!availableDates.Contains(tempDate))
                {
                    availableDates.Add(tempDate);
                }
            }

            return availableDates;
        }

        private static List<DateTime> PopulateDateList(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();

            DateTime tempDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);

            for (int i = 0; i < (endDate - startDate).TotalDays; i++)
            {
                dates.Add(new DateTime());

                tempDate = tempDate.AddDays(1);
            }

            return dates;
        }
    }
}