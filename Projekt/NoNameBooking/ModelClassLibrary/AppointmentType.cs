using System;

namespace ModelClassLibrary
{
    public class AppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public double StandardPrice { get; set; }

        public AppointmentType(string name, double standardPrice, TimeSpan duration, int id = -1)
        {
            Id = id;
            Name = name;
            Duration = duration;
            StandardPrice = standardPrice;
        }
    }
}
