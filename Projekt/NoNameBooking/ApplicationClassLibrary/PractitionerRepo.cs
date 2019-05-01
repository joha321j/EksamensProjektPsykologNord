using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class PractitionerRepo
    {
        private List<Practitioner> _practitioners;
        private static PractitionerRepo _instance;

        private PractitionerRepo()
        {
            _practitioners = new List<Practitioner>();

        }
        public static PractitionerRepo GetInstance()
        {
            return _instance ?? (_instance = new PractitionerRepo());
        }

        public Practitioner GetPractitioner(string practitionerName)
        {
            return _practitioners.Find(practitioner => string.Equals(practitioner.Name, practitionerName));
        }

        public List<DateTime> GetAvailableDatesForPractitioner(string practitionerName, DateTime startDate, DateTime endDate)
        {
            Practitioner tempPractitioner = GetPractitioner(practitionerName);

            return tempPractitioner.GetAvailability(startDate, endDate);
        }

        public List<DateTime> GetAvailableTimesForPractitioner(DateTime selectedDateValue, string practitionerName)
        {
            Practitioner tempPractitioner = GetPractitioner(practitionerName);

            return tempPractitioner.GetAvailableTimes(selectedDateValue);
        }

        public void AddPractitioner(Practitioner practitioner)
        {
            _practitioners.Add(practitioner);
        }



        public void ResetInstance()
        {
            _instance = null;
        }
    }
}
