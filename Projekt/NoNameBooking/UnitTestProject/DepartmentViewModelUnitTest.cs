using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using ViewModelClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for DepartmentViewModelUnitTest
    /// </summary>
    [TestClass]
    public class DepartmentViewModelUnitTest
    {
        private DepartmentViewModel _testDepartmentViewModel;

        [TestInitialize]
        public void DepartmentViewModelTestSetup()
        {
            Department testDepartment = new Department("Johannes", "Testvej 12");
            _testDepartmentViewModel = new DepartmentViewModel(testDepartment);
        }

        [TestMethod]
        public void CreationUnitTest()
        {
            Assert.IsNotNull(_testDepartmentViewModel);
        }

        [TestMethod]
        public void GetAvailabilityTest()
        {
            User testUser = new User();
            Practitioner testPractitioner = new Practitioner(new DateTime(1, 1, 1, 9, 0, 0), TimeSpan.FromHours(12));
            List<User> users = new List<User>();

            DateTime testDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.AddDays(3).Day,
                12, 0, 0);

            AppointmentType testAppointmentType = new AppointmentType("Sebastian", 995.12, TimeSpan.FromHours(2));

            Room testRoom = new Room("Fisk");

            users.Add(testUser);
            users.Add(testPractitioner);

            Appointment testAppointment = new Appointment(testDate, users, testAppointmentType, testRoom, "");

            DateTime startDate = DateTime.Today.AddDays(1);
            DateTime endDate = DateTime.Today.AddMonths(1);

            List<DateTime> availableDateTimes = _testDepartmentViewModel.GetAvailability(startDate, endDate, testPractitioner);

            Assert.IsFalse(availableDateTimes.Contains(testAppointment.DateAndTime));
        }
    }
}
