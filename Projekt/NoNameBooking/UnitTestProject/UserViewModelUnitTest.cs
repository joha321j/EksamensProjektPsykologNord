using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using ViewModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class UserViewModelUnitTest
    {
        private UserViewModel _userViewModel;

        [TestInitialize]
        public void UserViewModelTestSetup()
        {
            _userViewModel = new UserViewModel();
        }
        [TestMethod]
        public void UserViewModelCreation()
        {
            Assert.IsNotNull(_userViewModel);
        }

        [TestMethod]
        public void CreateNewAppointmentMethod()
        {
            DateTime dateAndTime = new DateTime(1992, 03, 10, 10, 15, 0);

            List<User> participants = new List<User>();

            User userOne = new User();
            User userTwo = new User();

            participants.Add(userOne);
            participants.Add(userTwo);

            AppointmentType appointmentType = new AppointmentType("testType", 123.12, new TimeSpan(1,0,0));

            string note = "Dette er testnoten.";

            Room testRoom = new Room("Kaare's Lejlighed", new Department("HCØ", "Testvej 12, 2113 Sakstesting"));

            _userViewModel.CreateAppointment(dateAndTime, participants, appointmentType, note, testRoom);

            Assert.AreEqual(userOne.GetAppointment(), userTwo.GetAppointment());
        }
    }
}
