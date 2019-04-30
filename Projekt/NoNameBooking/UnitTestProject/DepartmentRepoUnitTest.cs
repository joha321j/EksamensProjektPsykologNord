using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for DeparmentRepoUnitTest
    /// </summary>
    [TestClass]
    public class DepartmentRepoUnitTest
    {
        private DepartmentRepo _instance;

        [TestInitialize]
        public void DepartmentRepoSetup()
        {
            DepartmentRepo _instance = DepartmentRepo.GetInstance();
        }
        [TestMethod]
        public void GetInstanceTest()
        {
            DepartmentRepo testinstance = DepartmentRepo.GetInstance();

            Assert.AreEqual(_instance, testinstance);
        }
    }
}
