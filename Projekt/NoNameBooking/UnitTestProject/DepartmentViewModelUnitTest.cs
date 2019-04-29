using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            _testDepartmentViewModel = new DepartmentViewModel();
        }

        [TestMethod]
        public void CreationUnitTest()
        {
            Assert.IsNotNull(_testDepartmentViewModel);
        }

        [TestMethod]
        public void GetAvailabilityTest()
        {

        }
    }
}
