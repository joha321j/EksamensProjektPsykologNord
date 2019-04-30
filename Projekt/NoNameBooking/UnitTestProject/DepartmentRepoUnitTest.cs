using System;
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
            Assert.AreEqual(_departmentOne,_instance.GetDepartment("TestDepartmentOne"));
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
    
    }
}
