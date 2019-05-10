using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public class Department
    {
        private readonly List<Practitioner> _practitioners;
        public int Id { get; }
        public string Name { get; set; }
        public string Address { get; }
        public List<Room> Rooms { get; set; }


        public Department(string name, string address, int id =-1)
        {
            _practitioners = new List<Practitioner>();

            Name = name;
            Address = address;

            Id = id;

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

        public List<Practitioner> GetPractitioners()
        {
            return _practitioners;
        }

        public void AddPractitioner(Practitioner practitioner)
        {
            _practitioners.Add(practitioner);
        }

        public List<DateTime> GetAvailableTimes(DateTime selectedDateValue)
        {
            return GetAvailability(selectedDateValue, selectedDateValue.AddDays(1));
        }

        public Room GetAvailableRoom(DateTime dateAndTime)
        {
            throw new NotImplementedException();
        }
    }
}