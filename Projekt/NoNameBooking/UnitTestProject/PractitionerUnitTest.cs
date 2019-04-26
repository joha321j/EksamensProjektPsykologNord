using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class PractitionerUnitTest
    {
        private Practitioner _testPractitioner;
        [TestInitialize]
        public void PractitionerUnitTestSetup()
        {
            _testPractitioner = new Practitioner();
        }

        [TestMethod]
        public void PractitionerCreationTest()
        {
            
            Assert.IsNotNull(_testPractitioner);
        }

        [TestMethod]
        public void PractitionerUserInheritanceTest()
        {
            
            Assert.IsInstanceOfType(_testPractitioner, typeof(User));
        }

        [TestMethod]
        public void PractitionerAvailabilityTest()
        {
            DateTime starTime = new DateTime(1, 1, 1, 9, 0, 0);
            DateTime endTime = new DateTime(1, 1, 1, 21, 0, 0);
            _testPractitioner.Availability = endTime - starTime;

            Assert.AreEqual(new TimeSpan(12, 0, 0), _testPractitioner.Availability);
        }
    }
}
