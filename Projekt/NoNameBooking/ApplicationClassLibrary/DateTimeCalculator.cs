using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ApplicationClassLibrary
{
    public class DateTimeCalculator
    {
        /// <summary>
        /// Returns a list of DateTimes where the practitioner is not available
        /// </summary>
        /// <param name="practitionerAvailableDates"></param>
        /// <param name="departmentAvailableDates"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<DateTime> GetBusyDates(List<DateTime> practitionerAvailableDates,
            List<DateTime> departmentAvailableDates, DateTime startDate, DateTime endDate)
        {
            List<DateTime> busyDates = PopulateDateList(startDate, endDate);


            IEnumerable<DateTime> availableDateTimes = from date in practitionerAvailableDates
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

        public static List<DateTime> GetAvailableTimes(List<DateTime> firstTimeList, List<DateTime> secondTimeList)
        {
            IEnumerable<DateTime> availableDateTimes = from date in firstTimeList
                join practitionerDate in secondTimeList on date equals
                    practitionerDate
                select date;

            return availableDateTimes.ToList();
        }

        /// <summary>
        /// Returns the weeknumber as an int.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        /// <summary>
        /// Finds out which date of the week in the system is first.
        /// </summary>
        /// <param name="year"></param>
        /// <param name="weekOfYear"></param>
        /// <returns></returns>
        public static DateTime FirstDateOfWeek(int year, int weekOfYear)
        {
            DateTime jan1 = new DateTime(year, 1, 1);

            int daysOffset = (int)CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;

            DateTime firstMonday = jan1.AddDays(daysOffset);

            int firstWeek = CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(jan1, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);

            if (firstWeek <= 1)
            {
                weekOfYear -= 1;
            }

            return firstMonday.AddDays(weekOfYear * 7);
        }
    }
}