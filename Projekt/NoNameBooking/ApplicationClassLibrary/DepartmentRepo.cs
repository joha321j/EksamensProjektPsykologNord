using System;
using System.Collections.Generic;
using ModelClassLibrary;
using PersistencyClassLibrary;

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

        public DepartmentView GetDepartmentViewFromRoomId(int id)
        {
            DepartmentView department;
            Department tempDepartment = _departments.Find(depart => depart.Rooms.Exists(room => room.Id == id));
            department = new DepartmentView(tempDepartment.Id,tempDepartment.Name);
            return department;
        }

        internal RoomView GetRoomByAppointmentId(int appointmentId, string departmentName)
        {
            Department tempDepartment = _departments.Find(depart => depart.Name == departmentName);            
            Room tempRoom = tempDepartment.GetRoomByAppointmnetId(appointmentId);
            RoomView roomView = new RoomView(tempRoom.Id, tempRoom.Name);
            return roomView;
        }
    }
}
