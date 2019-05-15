using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class AppointmentTypeView
    {
        public int Id { get; }
        public string Name { get; }
        public TimeSpan Duration { get; }
        public double StandardPrice { get; }

        public AppointmentTypeView(int id, string name, TimeSpan duration, double standardPrice)
        {
            Id = id;
            Name = name;
            Duration = duration;
            StandardPrice = standardPrice;
        }
    }
}
