using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UserUnitTest
    {
        private User _testUser;

        [TestInitialize]
        public void TestUserSetup()
        {
            string userName = "Test McTestersen";
            string address = "Testvej 13, 9999 Testerbo";
            string phoneNumber = "20642379";
            string email = "test@knapsåmegettest.testcom";

            _testUser = new User(userName, address, phoneNumber, email);
        }
        [TestMethod]
        public void UserCreationTest()
        {
            User testUser = new User();

            Assert.IsNotNull(testUser);
        }

        [TestMethod]
        public void UserPropertyNameTest()
        {
            string userName = "Test McTestersen";

            Assert.AreEqual(_testUser.Name, userName);
        }

        [TestMethod]
        public void UserPropertyAddressTest()
        { 
            string address = "Testvej 13, 9999 Testerbo";

            Assert.AreEqual(_testUser.Address, address);
        }

        [TestMethod]
        public void UserPropertyPhoneNumberTest()
        {
            string phoneNumber = "20642379";

            Assert.AreEqual(_testUser.PhoneNumber, phoneNumber);
        }

        [TestMethod]
        public void UserPropertyEmailTest()
        {
            string email = "test@knapsåmegettest.testcom";

            Assert.AreEqual(_testUser.Email, email);
        }

        [TestMethod]
        public void UserPropertyAppointmentsTest()
        {
            Appointment testAppointmentOne = new Appointment();
            Appointment testAppointmentTwo = new Appointment();

            _testUser.AddAppointment(testAppointmentOne);
            _testUser.AddAppointment(testAppointmentTwo);

            Assert.AreEqual(testAppointmentOne, _testUser.GetAppointment(testAppointmentOne));
        }

    }
}
