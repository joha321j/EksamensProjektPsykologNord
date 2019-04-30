using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for DepartmentUnitTest
    /// </summary>
    [TestClass]
    public class DepartmentUnitTest
    {
        private Department _testDepartment;
        private Room _testRoom;
        private Room _testRoomTwo;
        [TestInitialize]
        public void DepartmentTestSetup()
        {
            _testDepartment = new Department("TestDepartment", "Kaare's Seng");

            _testRoom = new Room("1");
            _testRoomTwo = new Room("2");

            _testDepartment.Rooms.Add(_testRoom);
            _testDepartment.Rooms.Add(_testRoomTwo);
            
        }
        [TestMethod]
        public void CreationTest()
        {
            Assert.IsNotNull(_testDepartment);
        }

        [TestMethod]
        public void RoomsPropertyTest()
        {
            Assert.IsTrue(_testDepartment.Rooms.Contains(_testRoom) && _testDepartment.Rooms.Contains(_testRoomTwo));
        }

        [TestMethod]
        public void GetAvailabilityTest()
        {
            User userOne = new User();
            User userTwo = new User();
            User userThree = new User();

            List<User> users = new List<User>();

            users.Add(userOne);
            users.Add(userTwo);
            users.Add(userThree);

            DateTime testDate = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, DateTime.Today.AddDays(2).Day, 12, 0, 0);
            AppointmentType appointmentType = new AppointmentType("Anders", 123.879, TimeSpan.FromHours(2));

            DateTime testDateTwo = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(1).Month, DateTime.Today.AddDays(5).Day, 10, 0, 0);

            Appointment testAppointment = new Appointment(testDate, users, appointmentType, _testDepartment.Rooms[0], "");
            Appointment testAppointmentTwo = new Appointment(testDateTwo, users, appointmentType, _testDepartment.Rooms[1], "");

            DateTime startDate = DateTime.Today.AddDays(1);

            DateTime endDate = DateTime.Today.AddMonths(3);

            List<DateTime> availableDateTimes = _testDepartment.GetAvailability(startDate, endDate);

            Assert.IsTrue(availableDateTimes.Contains(testAppointment.DateAndTime) && availableDateTimes.Contains(testAppointmentTwo.DateAndTime));
        }

        [TestMethod]
        public void GetAvailabilityTwoAppointmentsAtSameTimeTest()
        {
            User userOne = new User();
            User userTwo = new User();
            User userThree = new User();

            List<User> users = new List<User> {userOne, userTwo, userThree};




            DateTime testDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(2).Day, 10, 0, 0);
            AppointmentType appointmentType = new AppointmentType("Anders", 123.879, TimeSpan.FromHours(2));

            DateTime testDateTwo = new DateTime(2019, 5, 2, 10, 0, 0);

            Appointment testAppointment = new Appointment(testDate, users, appointmentType, _testDepartment.Rooms[0], "");
            Appointment testAppointmentTwo = new Appointment(testDateTwo, users, appointmentType, _testDepartment.Rooms[1], "");


            DateTime startDate = DateTime.Today.AddDays(1);

            DateTime endDate = DateTime.Today.AddMonths(1);

            List<DateTime> availableDateTimes = _testDepartment.GetAvailability(startDate, endDate);

            Assert.IsFalse(availableDateTimes.Contains(testAppointment.DateAndTime));
        }

    }
}
