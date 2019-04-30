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
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidPhoneNumberWhiteSpace()
        {
            InputValidator.EnsureValidPhoneNumber("  ");
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

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidSsnTestEmpty()
        {
            InputValidator.EnsureValidSsn(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidSsnTestWhiteSpace()
        {
            InputValidator.EnsureValidSsn("      ");
        }

        [TestMethod]
        public void EnsureValidZip()
        {
            InputValidator.EnsureValidZip("testvej 74; 9999; Testenhøj");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidZipInvalid()
        {
            InputValidator.EnsureValidZip("oaecrgp.)*{[&)*=}{[}fntueouoanuo32475976231; 213465{[})+[*{}g; 5646213{[)}");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidZipEmpty()
        {
            InputValidator.EnsureValidZip(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidInputException))]
        public void EnsureValidZipWhiteSpace()
        {
            InputValidator.EnsureValidZip("   ");
        }
    }
}
