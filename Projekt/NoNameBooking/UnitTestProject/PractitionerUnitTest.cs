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

        [TestMethod]
        public void PractitionerCreationTest()
        {
            Practitioner testPractitioner = new Practitioner();

            Assert.IsNotNull(testPractitioner);
        }

        [TestMethod]
        public void PractitionerUserInheritanceTest()
        {
            Practitioner testPractitioner = new Practitioner();
            
            Assert.IsInstanceOfType(testPractitioner, typeof(User));
        }
    }
}
