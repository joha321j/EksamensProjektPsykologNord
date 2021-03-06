﻿using System;
using System.Collections.Generic;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    public class PractitionerRepo
    {
        private readonly IPersistable _persistable;
        private List<Practitioner> _practitioners;
        private static PractitionerRepo _instance;

        private PractitionerRepo(IPersistable persistable)
        {
            _persistable = persistable;
            _practitioners = _persistable.GetPractitioners();

        }
        public static PractitionerRepo GetInstance(IPersistable persistable)
        {
            return _instance ?? (_instance = new PractitionerRepo(persistable));
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

        public List<Practitioner> GetPractitioners()
        {
            return _practitioners;
        }

        internal bool IsPractitioner(UserView user)
        {
            return _practitioners.Exists(practitioner => practitioner.Id == user.Id);
        }

        internal AppointmentType GetTreatmentByTreatmentName(string typeName, string practitionerName)
        {
            Practitioner tempPrac = _practitioners.Find(prac => prac.Name == practitionerName);
            AppointmentType appoType = tempPrac.GetAppointmentType(typeName);
            return appoType;
        }
    }
}
