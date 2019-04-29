using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public class Department
    {
        public string Name { get; set; }
        public string Address { get; }
        public List<Room> Rooms { get; set; }


        public Department(string name, string address)
        {
            Name = name;
            Address = address;

            Rooms = new List<Room>();
        }


        public List<DateTime> GetAvailability(DateTime startDate, DateTime endDate)
        {
            List<DateTime> availableDateTimes = new List<DateTime>();

            foreach (Room room in Rooms)
            {
                List<DateTime> tempDateTimes = room.GetAvailability(startDate, endDate);

                CompareAvailability(ref availableDateTimes, tempDateTimes);
            }

            return availableDateTimes;
        }

        private void CompareAvailability(ref List<DateTime> availableDateTimes, List<DateTime> tempDateTimes)
        {
            foreach (DateTime dateTime in tempDateTimes)
            {
                if (!availableDateTimes.Contains(dateTime))
                {
                    availableDateTimes.Add(dateTime);
                }
            }
        }
    }
}