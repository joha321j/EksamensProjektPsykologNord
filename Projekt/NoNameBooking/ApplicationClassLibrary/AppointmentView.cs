using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class AppointmentView
    {  
        public int Id { get; set; }
        public DateTime dateAndTime { get; set; }
        public AppointmentView(int id, DateTime dateAndTime)
        {
            Id = id;
            this.dateAndTime = dateAndTime;
        }
    }
}
