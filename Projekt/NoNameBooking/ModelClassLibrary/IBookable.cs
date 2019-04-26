using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public interface IBookable
    {
        List<DateTime> GetAvailability(DateTime startDate, DateTime endDate);

        void AddAppointment(Appointment appointment);
    }
}