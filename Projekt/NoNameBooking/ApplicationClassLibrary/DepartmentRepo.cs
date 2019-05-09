using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class DepartmentRepo
    {
        private readonly IPersistable _persistable;
        private static DepartmentRepo _instance;

        private readonly List<Department> _departments = new List<Department>();

        private DepartmentRepo(IPersistable persistable, List<Practitioner> practitioners)
        {
            _persistable = persistable;
            _departments = _persistable.GetDepartments(practitioners);
        }

        public static DepartmentRepo GetInstance(IPersistable persistable, List<Practitioner> practitioners)
        {
            return _instance ?? (_instance = new DepartmentRepo(persistable, practitioners));
        }

        public List<Department> GetDepartments()
        {
            return _departments;
        }

        public Department GetDepartment(string departmentName)
        {
            return _departments.Find(department => string.Equals(department.Name, departmentName));
        }

        public List<DateTime> GetAvailableDatesForDepartment(string departmentName, DateTime startDate,
            DateTime endDate)
        {
            Department tempDepartment = GetDepartment(departmentName);

            return tempDepartment.GetAvailability(startDate, endDate);
        }

        public void AddDepartment(Department department)
        {
            _departments.Add(department);
        }

        public void ResetInstance()
        {
            _instance = null;
        }

        public List<DateTime> GetAvailableTimesForDepartment(DateTime selectedDateValue, string departmentName)
        {
            Department tempDepartment = GetDepartment(departmentName);

            return tempDepartment.GetAvailableTimes(selectedDateValue);
        }
    }
}
