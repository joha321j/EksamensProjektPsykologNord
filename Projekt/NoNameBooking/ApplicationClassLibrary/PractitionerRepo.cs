using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    class PractitionerRepo
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

        public List<DateTime> GetAvailableDatesForPractitioner(string practitionerName)
        {
            throw new NotImplementedException();
        }

        public List<DateTime> GetAvailableTimesForPractitioner(DateTime selectedDateValue, string practitionerName)
        {
            throw new NotImplementedException();
        }
    }
}
