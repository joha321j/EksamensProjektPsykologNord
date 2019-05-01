﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationClassLibrary;
using ModelClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for DeparmentRepoUnitTest
    /// </summary>
    [TestClass]
    public class DepartmentRepoUnitTest
    {
        private DepartmentRepo _instance;
        private Department _departmentOne;
        private Department _departmentTwo;

        [TestCleanup]
        public void DepartmentRepoCleanUp()
        {
            _instance.ResetInstance();
        }

        [TestInitialize]
        public void DepartmentRepoSetup()
        {
            _instance = DepartmentRepo.GetInstance();
            _departmentOne = new Department("TestDepartmentOne", "TestAddressOne");
            _departmentTwo = new Department("TestDepartmentTwo", "TestAddressTwo");

        }

        [TestMethod]
        public void GetInstanceTest()
        {
            DepartmentRepo testinstance = DepartmentRepo.GetInstance();

            Assert.AreEqual(_instance, testinstance);
        }

        [TestMethod]
        public void AddDepartmentTest()
        {
            Department departmentOne = new Department("Test", "Test");
            _instance.AddDepartment(departmentOne);
        }

        [TestMethod]
        public void GetDepartmentTest()
        {
            _instance.AddDepartment(_departmentOne);
            Assert.AreEqual(_departmentOne, _instance.GetDepartment("TestDepartmentOne"));
        }

        [TestMethod]
        public void GetAllDepartmentsTest()
        {
            List<Department> testList = new List<Department> {_departmentOne, _departmentTwo};

            _instance.AddDepartment(_departmentOne);
            _instance.AddDepartment(_departmentTwo);

            List<Department> compare = _instance.GetDepartments();

            CollectionAssert.AreEquivalent(compare, testList);
        }

        [TestMethod]
        public void GetAvailableDatesForDepartmentTest()
        {
            AppointmentType testType = new AppointmentType("Kaare", 50, TimeSpan.FromHours(24));

            User testUserOne = new User("Mike", "TestBoulevard 24", "69696969", "Mike@Mikeson.mike");
            User testUserTwo = new User("Mike2", "TestBoulevard 241", "69696968", "Mike@Mikeson.Rasmus");
            List<User> testUsers = new List<User>() { testUserOne, testUserTwo };

            DateTime testDateTime = DateTime.Today.AddDays(1);

            _instance.AddDepartment(_departmentOne);
            Room testRoom = new Room("TestName");
            _departmentOne.Rooms.Add(testRoom);

            Appointment testAppointment = new Appointment(testDateTime, testUsers, testType, testRoom, " ");

            List<DateTime> availableDateTimes = _instance.GetAvailableDatesForDepartment("TestDepartmentOne", DateTime.Today, DateTime.Today.AddDays(7));

            Assert.IsFalse(availableDateTimes.Contains(testDateTime));
        }

        [TestMethod]
        public void GetAvailableTimesforDepartmentTest()
        {

        }

    }
}