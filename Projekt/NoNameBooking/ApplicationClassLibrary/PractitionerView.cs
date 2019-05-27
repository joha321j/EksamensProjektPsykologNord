using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class PractitionerView : UserView
    {
        public DateTime Start { get; }
        public TimeSpan DayLength { get; }

        public PractitionerView(int id, string name, string phoneNumber, string address, string email, DateTime start,
            TimeSpan dayLength) : base(id, name, phoneNumber, address, email)
        {
            Start = start;
            DayLength = dayLength;
        }
    }
}
