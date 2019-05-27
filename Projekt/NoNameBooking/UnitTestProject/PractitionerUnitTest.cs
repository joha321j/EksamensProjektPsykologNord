using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class PractitionerUnitTest
    {
        private Practitioner _testPractitioner;
        [TestInitialize]
        public void PractitionerUnitTestSetup()
        {
            DateTime starTime = new DateTime(1, 1, 1, 9, 0, 0);
            DateTime endTime = new DateTime(1, 1, 1, 21, 0, 0);

            TimeSpan daySpan = endTime - starTime;

            _testPractitioner = new Practitioner(starTime, daySpan);
        }

        [TestMethod]
        public void PractitionerCreationTest()
        {
            
            Assert.IsNotNull(_testPractitioner);
        }

        [TestMethod]
        public void PractitionerUserInheritanceTest()
        {
            
            Assert.IsInstanceOfType(_testPractitioner, typeof(User));
        }

        [TestMethod]
        public void PractitionerAvailabilityTest()
        {
            Assert.AreEqual(new TimeSpan(12, 0, 0), _testPractitioner.DayLength);
        }

        [TestMethod]
        public void GetAvailabilityTest()
        {
            Client testClient = new Client();
            DateTime testDateTime = new DateTime(2019, 05, 12, 10, 0, 0);
            AppointmentType testAppointmentType = new AppointmentType("Test", 1200, TimeSpan.FromHours(1));
            Room testRoom = new Room("A");

            List<User> users = new List<User> {testClient, _testPractitioner};
            Appointment appointmentOne = new Appointment(testDateTime, users, testAppointmentType, testRoom, "", TimeSpan.FromHours(5), false, false);

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime inOneYear = tomorrow.AddYears(1);
            List<DateTime> availableTimeSpans = _testPractitioner.GetAvailability(tomorrow, inOneYear);

            Assert.IsFalse(availableTimeSpans.Contains(testDateTime));
        }

        [TestMethod]
        public void GetAvailableTimesTest()
        {
            Client testClient = new Client();
            DateTime testDateTime = new DateTime(2019, 06, 17, 9, 0, 0);
            AppointmentType testAppointmentType = new AppointmentType("TestAppointment", 70, TimeSpan.FromHours(2));
            Room testRoom = new Room("B");

            List<User> users = new List<User> { testClient, _testPractitioner };
            Appointment appointmentOne = new Appointment(testDateTime, users, testAppointmentType, testRoom, "", TimeSpan.FromHours(5), false, false);

            List<DateTime> availableTimes = _testPractitioner.GetAvailableTimes(testDateTime.Date);

            Assert.IsFalse(availableTimes.Contains(testDateTime.AddHours(1)));
        }

        [TestMethod]
        public void GetAppointmentTypeTest()
        {
            AppointmentType testAppointmentType =
                new AppointmentType("TestAppointment", 1200.00, TimeSpan.FromHours(1));
            _testPractitioner.AppointmentTypes.Add(testAppointmentType);

            Assert.AreEqual(testAppointmentType, _testPractitioner.GetAppointmentType("TestAppointment"));
        }
    }
}

