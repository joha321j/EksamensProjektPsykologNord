using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class RoomUnitTest
    {
        private Room _testRoom;
        [TestInitialize]
        public void RoomTestSetup()
        {
            _testRoom = new Room("TestRoom");
        }
        [TestMethod]
        public void RoomCreationUnitTest()
        {
            Assert.IsNotNull(_testRoom);
        }

        [TestMethod]
        public void RoomNamePropertyTest()
        {
            string roomName = "TestRoom";

            Assert.AreEqual(roomName, _testRoom.Name);
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

            DateTime testDate = new DateTime(2019, 5, 1, 12, 0, 0);
            AppointmentType appointmentType = new AppointmentType("Anders", 123.879, TimeSpan.FromHours(2));

            Appointment testAppointment = new Appointment(testDate, users, appointmentType, _testRoom, "", TimeSpan.FromHours(5), false, false);


            DateTime startDate = DateTime.Today.AddDays(1);

            DateTime endDate = DateTime.Today.AddMonths(2);

            List<DateTime> availableTimes = _testRoom.GetAvailability(startDate, endDate);

            Assert.IsFalse(availableTimes.Contains(testDate));
        }

        [TestMethod]
        public void IsAvailableTest()
        {
            AppointmentType testType = new AppointmentType("Kaare", 50, TimeSpan.FromHours(2));

            User testUserOne = new User("testMike", "TestVibevænget 24", "69696969", "Mike@Johannes.mike");
            User testUserTwo = new User("testMike2", "TestVibevænget 241", "69696968", "Mike@Cancer.Rasmus");
            List<User> testUsers = new List<User>() { testUserOne, testUserTwo };

            DateTime testDateTime = DateTime.Today.AddDays(1).AddHours(10);

            Room testRoom = new Room("Youtube");

            Appointment testAppointment = new Appointment(testDateTime, testUsers, testType, testRoom, " ", TimeSpan.FromHours(5), false, false);

            DateTime newTime = testDateTime.AddHours(3);

            Assert.IsTrue(testRoom.IsAvailable(newTime, testType.Duration));
        }

        [TestMethod]
        public void NotAvailableTest()
        {
            AppointmentType testType = new AppointmentType("Kaare", 50, TimeSpan.FromHours(2));

            User testUserOne = new User("testMike", "TestVibevænget 24", "69696969", "Mike@Johannes.mike");
            User testUserTwo = new User("testMike2", "TestVibevænget 241", "69696968", "Mike@Cancer.Rasmus");
            List<User> testUsers = new List<User>() { testUserOne, testUserTwo };

            DateTime testDateTime = DateTime.Today.AddDays(1).AddHours(10);

            Room testRoom = new Room("Youtube");

            Appointment testAppointment = new Appointment(testDateTime, testUsers, testType, testRoom, " ", TimeSpan.FromHours(5), false, false);

            DateTime newTime = testDateTime;

            Assert.IsFalse(testRoom.IsAvailable(newTime, testType.Duration));
        }
    }
}
