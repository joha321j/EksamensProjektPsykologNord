using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class AppointmentType
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }

        public double StandardPrice { get; set; }

        public AppointmentType(string name, double standardPrice, TimeSpan duration)
        {
            Name = name;
            Duration = duration;
            StandardPrice = standardPrice;
        }
    }
}
