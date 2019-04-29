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
            Room testRoomThree = new Room("A");
            Room testRoomFour = new Room("B");

            _testDepartment.Rooms.Add(testRoomThree);
            _testDepartment.Rooms.Add(testRoomFour);

            Assert.IsTrue(_testDepartment.Rooms.Contains(testRoomThree) && _testDepartment.Rooms.Contains(testRoomFour));
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

            DateTime testDate = new DateTime(2020, 11, 12, 12, 0, 0);
            AppointmentType appointmentType = new AppointmentType("Anders", 123.879, TimeSpan.FromHours(2));

            DateTime testDateTwo = new DateTime(2019, 9, 11, 10, 0, 0);

            Appointment testAppointment = new Appointment(testDate, users, appointmentType, _testRoom, "");
            Appointment testAppointmentTwo = new Appointment(testDateTwo, users, appointmentType, _testRoomTwo, "");

            DateTime startDate = DateTime.Today.AddDays(1);

            DateTime endDate = DateTime.Today.AddMonths(2);

            List<DateTime> availableDateTimes = _testDepartment.GetAvailability(startDate, endDate);

            Assert.IsFalse(availableDateTimes.Contains(testAppointment.DateAndTime) && availableDateTimes.Contains(testAppointmentTwo.DateAndTime));
        }

    }
}
