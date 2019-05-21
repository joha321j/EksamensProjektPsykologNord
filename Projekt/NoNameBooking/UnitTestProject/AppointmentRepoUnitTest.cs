using System;
using System.Text;
using System.Collections.Generic;
using ApplicationClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for AppointmentRepoUnitTest
    /// </summary>
    [TestClass]
    public class AppointmentRepoUnitTest
    {
        private AppointmentRepo _instance;
        private TestDbController _dbController;
        private Controller _controller;
        private DepartmentRepo _departmentRepo;
        List<User> users = new List<User>();
        List<Practitioner> practitioners = new List<Practitioner>();
        List<Department> departments = new List<Department>();

        [TestInitialize]
        public void AppointmentRepoSetup()
        {
            _dbController = new TestDbController();
            _controller = Controller.GetInstance();
            _departmentRepo = DepartmentRepo.GetInstance(_dbController, practitioners);
            departments = _departmentRepo.GetDepartments();
            users = _controller.GetUsers();
            _instance = AppointmentRepo.GetInstance(_dbController, users, departments);
        }

        [TestCleanup]
        public void AppointmentRepoCleanUp()
        {
            _instance.ResetInstance();
            _departmentRepo.ResetInstance();
        }
       
        [TestMethod]
        public void AppointmentRepoCreationTest()
        {
            AppointmentRepo compareInstance = AppointmentRepo.GetInstance(_dbController, users, departments);

            Assert.AreEqual(_instance, compareInstance);
        }

        [TestMethod]
        public void AddAppointmentTest()
        {
            DateTime date = new DateTime(2019,5,23,9,0,0);
            User testUserOne = new User("Kaare", "Kaares Hyble 23", "70302891", "ToCoolForYou@yourmom.com");
            User testUserTwo = new User("Sebastian", "Kaares Gård 23", "61709910", "MyBuddy@yourmom.com");
            List<User> users = new List<User>() {testUserOne, testUserTwo};
            AppointmentType tempAppointmentType = new AppointmentType("Help", 2500, TimeSpan.FromHours(10));
            Room testRoom = new Room("Beta");
            Appointment tempAppointment = new Appointment(date, users, tempAppointmentType, testRoom, "Hey");
            _instance.AddAppointment(tempAppointment);
        }

        [TestMethod]
        public void GetAppointmentsTest()
        {
            DateTime date = new DateTime(2019, 5, 23, 9, 0, 0);
            User testUserOne = new User("Kaare", "Kaares Hyble 23", "70302891", "ToCoolForYou@yourmom.com");
            User testUserTwo = new User("Sebastian", "Kaares Gård 23", "61709910", "MyBuddy@yourmom.com");
            List<User> users = new List<User>() { testUserOne, testUserTwo };
            AppointmentType tempAppointmentType = new AppointmentType("Help", 2500, TimeSpan.FromHours(10));
            Room testRoom = new Room("Beta");

            Appointment tempAppointment = new Appointment(date, users, tempAppointmentType, testRoom, "Hey");

            _instance.CreateAndAddAppointment(date, testRoom, users, tempAppointmentType, "Hey");

            List<Appointment> compareList = new List<Appointment>(){tempAppointment};
            Assert.IsTrue(_instance.GetAppointments().Exists(appointment => appointment.DateAndTime == date));
        }
    }
}
