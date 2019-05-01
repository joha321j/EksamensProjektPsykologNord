﻿using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class DepartmentRepo
    {
        private static DepartmentRepo _instance;

        private readonly List<Department> _departments;

        private DepartmentRepo()
        {
            _departments = new List<Department>();
        }

        public static DepartmentRepo GetInstance()
        {
            return _instance ?? (_instance = new DepartmentRepo());
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

        public List<DateTime> GetAvailableTimesForDepartmtent(DateTime selectedDateValue, string departmentName)
        {
            throw new NotImplementedException();
        }
    }
}