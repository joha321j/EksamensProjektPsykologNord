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
            DateTime testDateTime = new DateTime(2019, 04, 27, 10, 0, 0);
            AppointmentType testAppointmentType = new AppointmentType("Test", 1200, TimeSpan.FromHours(1));
            Room testRoom = new Room("A", new Department("Monkey", "Here"));

            List<User> users = new List<User> {testClient, _testPractitioner};
            Appointment appointmentOne = new Appointment(testDateTime, users, testAppointmentType, testRoom, "");
            _testPractitioner.AddAppointment(appointmentOne);

            DateTime tomorrow = DateTime.Today.AddDays(1);
            DateTime inOneYear = tomorrow.AddYears(2);
            List<DateTime> availableTimeSpans = _testPractitioner.GetAvailability(tomorrow, inOneYear);

            Assert.IsFalse(availableTimeSpans.Contains(testDateTime));
        }
    }
}
