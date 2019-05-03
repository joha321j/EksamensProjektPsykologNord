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

            Appointment testAppointment = new Appointment(testDate, users, appointmentType, _testDepartment.Rooms[0], "");
            Appointment testAppointmentTwo = new Appointment(testDate, users, appointmentType, _testDepartment.Rooms[1], "");


            DateTime startDate = DateTime.Today.AddDays(1);

            DateTime endDate = DateTime.Today.AddMonths(1);

            List<DateTime> availableDateTimes = _testDepartment.GetAvailability(startDate, endDate);

            Assert.IsFalse(availableDateTimes.Contains(testAppointment.DateAndTime));
        }

        [TestMethod]
        public void GetAvailableDatesTest()
        {
            Department testDepartment2 = new Department("Kaare sex dungeon", "Hej 24");
            AppointmentType testType = new AppointmentType("Kaare", 50, TimeSpan.FromHours(24));

            User testUserOne = new User("testMike", "TestVibevænget 24", "69696969", "Mike@Johannes.mike");
            User testUserTwo = new User("testMike2", "TestVibevænget 241", "69696968", "Mike@Cancer.Rasmus");
            List<User> testUsers = new List<User>() { testUserOne, testUserTwo };

            DateTime testDateTime = DateTime.Today.AddDays(1);

            Room testRoom = new Room("Youtube");

            testDepartment2.Rooms.Add(testRoom);

            Appointment testAppointment = new Appointment(testDateTime, testUsers, testType, testRoom, " ");

            List<DateTime> availableDateTimes = testDepartment2.GetAvailability(DateTime.Today, DateTime.Today.AddDays(7));

            Assert.IsFalse(availableDateTimes.Contains(testDateTime));
        }

        [TestMethod]
        public void AddPractitionerTest()
        {
            Practitioner prac = new Practitioner(DateTime.Today, TimeSpan.FromHours(9));
            _testDepartment.AddPractitioner(prac);
        }

        [TestMethod]
        public void GetPractitionersTest()
        {
            Practitioner prac1 = new Practitioner(DateTime.Today, TimeSpan.FromHours(9));
            Practitioner prac2 = new Practitioner(DateTime.Today, TimeSpan.FromHours(9));

            List<Practitioner> compareList = new List<Practitioner>(){prac1, prac2};

            _testDepartment.AddPractitioner(prac1);
            _testDepartment.AddPractitioner(prac2);

            CollectionAssert.AreEqual(compareList,_testDepartment.GetPractitioners());
            
        }

    }
}
