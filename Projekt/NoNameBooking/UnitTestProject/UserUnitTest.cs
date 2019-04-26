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
        private Appointment _testAppointmentOne;
        private Appointment _testAppointmentTwo;

        [TestInitialize]
        public void TestUserSetup()
        {
            string userName = "Test McTestersen";
            string address = "Testvej 13, 9999 Testerbo";
            string phoneNumber = "20642379";
            string email = "test@knapsåmegettest.testcom";

            _testUser = new User(userName, address, phoneNumber, email);


            _testAppointmentOne = new Appointment();
            _testAppointmentTwo = new Appointment();

            _testUser.AddAppointment(_testAppointmentOne);
            _testUser.AddAppointment(_testAppointmentTwo);
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

            Assert.AreEqual(_testAppointmentOne, _testUser.GetAppointment(_testAppointmentOne));
        }

        [TestMethod]
        public void UserGetLastAppointmentMethod()
        {
            Assert.AreEqual(_testAppointmentTwo, _testUser.GetAppointment());
        }

    }
}
