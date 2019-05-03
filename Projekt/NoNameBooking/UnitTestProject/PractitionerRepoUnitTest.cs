using System;
using System.Text;
using System.Collections.Generic;
using ApplicationClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for PractitionerRepoUnitTest
    /// </summary>
    [TestClass]
    public class PractitionerRepoUnitTest
    {
        private PractitionerRepo testInstance;
        private Practitioner testPractitionerOne;
        private Practitioner testPractitionerTwo;

        [TestInitialize]
        public void PractitionerRepoSetup()
        {
            testInstance = PractitionerRepo.GetInstance();


            testPractitionerOne = new Practitioner(DateTime.Today.AddHours(9), TimeSpan.FromHours(12),"pracNameOne");
            testPractitionerTwo = new Practitioner(DateTime.Today.AddHours(9), TimeSpan.FromHours(12), "pracNameTwo");

            testInstance.AddPractitioner(testPractitionerOne);
            testInstance.AddPractitioner(testPractitionerTwo);
        }

        [TestCleanup]
        public void PractitionerRepoCleanUp()
        {
            testInstance.ResetInstance();
        }

        [TestMethod]
        public void CreationTest()
        {
            PractitionerRepo compareTestRepo = PractitionerRepo.GetInstance();
            
            Assert.AreEqual(testInstance, compareTestRepo);
        }

        [TestMethod]
        public void AddPractitionerTest()
        {
            testInstance.AddPractitioner(testPractitionerOne);
            testInstance.AddPractitioner(testPractitionerTwo);
        }

        [TestMethod]
        public void GetPractionersTest()
        {
            testInstance.AddPractitioner(testPractitionerOne);
            Assert.AreEqual(testPractitionerOne, testInstance.GetPractitioner("pracNameOne"));
        }

        [TestMethod]
        public void GetAvailableDatesForPractitionerTest()
        {

            AppointmentType testType = new AppointmentType("Kaare", 50, testPractitionerOne.DayLength);

            User testUserOne = new User("Mike", "TestBoulevard 24", "69696969", "Mike@Mikeson.mike");
            User testUserTwo = new User("Mike2", "TestBoulevard 241", "69696968", "Mike@Mikeson.Rasmus");
            List<User> testUsers = new List<User>() { testUserOne, testUserTwo, testPractitionerOne };

            DateTime testDateTime = DateTime.Today.AddDays(1).AddHours(testPractitionerOne.Start.Hour);

            Room testRoom = new Room("TestName");

            Appointment testAppointment = new Appointment(testDateTime, testUsers, testType, testRoom, " ");

            List<DateTime> availableDateTimes = testInstance.GetAvailableDatesForPractitioner("pracNameOne", DateTime.Today, DateTime.Today.AddDays(7));

            Assert.IsFalse(availableDateTimes.Contains(testDateTime));
        }

        [TestMethod]
        public void GetAvailableTimesForPractitionerTest()
        {
            AppointmentType testType = new AppointmentType("Kaare", 50, TimeSpan.FromHours(1));

            User testUserOne = new User("TesterOne", "TestRoad 24", "12345678", "Email@Email.Email");
            User testUserTwo = new User("TesterTwo", "TestRoad 241", "87654321", "Mail@Mail.Mail");
            List<User> testUsers = new List<User>() { testUserOne, testUserTwo, testPractitionerOne };

            DateTime testDateTime = DateTime.Today.AddDays(1).AddHours(testPractitionerOne.Start.Hour);

            Room testRoom = new Room("TestName");

            Appointment testAppointment = new Appointment(testDateTime, testUsers, testType, testRoom, " ");

            List<DateTime> availableTimes =
                testInstance.GetAvailableTimesForPractitioner(testDateTime.Date, "pracNameOne");
            Assert.IsFalse(availableTimes.Contains(testDateTime));
        }
    }
}
