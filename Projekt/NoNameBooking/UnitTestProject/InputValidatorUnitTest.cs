using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class InputValidatorUnitTest
    {
        [TestMethod]
        public void EnsureValidPhoneNumberTestValidPhoneNumber()
        {
            InputValidator.EnsureValidPhoneNumber("12345678");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidPhoneNumberTestInvalidPhoneNumber()
        {
            InputValidator.EnsureValidPhoneNumber("tnoasetuh&[{}(=*)+]!)*}124679+æøå");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidPhoneNumberEmpty()
        {
            InputValidator.EnsureValidPhoneNumber(string.Empty);
        }

        [TestMethod]
        public void EnsureValidSsnTestValidSsn()
        {
            InputValidator.EnsureValidSsn("0717741180");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidSsnTestInvalidSsn()
        {
            InputValidator.EnsureValidSsn("oaterustheaog+)}{[+))[{}+æøå");
        }
    }
}
