using System;
using System.Text;
using System.Collections.Generic;
using ApplicationClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for PractitionerRepoUnitTest
    /// </summary>
    [TestClass]
    public class PractitionerRepoUnitTest
    {
        private PractitionerRepo testInstance;
        private Practitioner testPractitionerOne;
        private Practitioner testPractitionerTwo;

        [TestInitialize]
        public void PractitionerRepoSetup()
        {
            testInstance = PractitionerRepo.GetInstance();


            testPractitionerOne = new Practitioner(DateTime.Today, TimeSpan.FromHours(9),"pracNameOne");
            testPractitionerTwo = new Practitioner(DateTime.Today, TimeSpan.FromHours(9), "pracNameTwo");
        }

        [TestCleanup]
        public void PractitionerRepoCleanUp()
        {
            testInstance.ResetInstance();
        }

        [TestMethod]
        public void CreationTest()
        {
            PractitionerRepo compareTestRepo = PractitionerRepo.GetInstance();
            
            Assert.AreEqual(testInstance, compareTestRepo);
        }

        [TestMethod]
        public void AddPractitionerTest()
        {
            testInstance.AddPractitioner(testPractitionerOne);
            testInstance.AddPractitioner(testPractitionerTwo);
        }

        [TestMethod]
        public void GetPractionersTest()
        {
            testInstance.AddPractitioner(testPractitionerOne);

            Assert.AreEqual(testPractitionerOne, testInstance.GetPractitioner("pracNameOne"));

        }
        
    }
}
