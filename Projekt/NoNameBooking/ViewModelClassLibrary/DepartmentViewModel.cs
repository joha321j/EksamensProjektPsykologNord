using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ViewModelClassLibrary
{
    public class DepartmentViewModel
    {

        private readonly Department _department;

        public DepartmentViewModel(Department department)
        {
            _department = department;
        }
        public List<DateTime> GetAvailability(DateTime startDate, DateTime endDate, Practitioner practitioner)
        {
            List<DateTime> departmentAvailableDateTimes = _department.GetAvailability(startDate, endDate);

            List<DateTime> practitionerAvailableDateTimes = practitioner.GetAvailability(startDate, endDate);

            return CompareAvailability(departmentAvailableDateTimes, practitionerAvailableDateTimes);

        }

        private static List<DateTime> CompareAvailability(List<DateTime> departmentAvailableDateTimes, List<DateTime> practitionerAvailableDateTimes)
        {
            List<DateTime> combinedAvailableDateTimes = new List<DateTime>();

            foreach (DateTime departmentAvailableDateTime in departmentAvailableDateTimes)
            {
                if (!practitionerAvailableDateTimes.Contains(departmentAvailableDateTime))
                {
                    combinedAvailableDateTimes.Add(departmentAvailableDateTime);
                }
            }

            return combinedAvailableDateTimes;
        }
    }
}