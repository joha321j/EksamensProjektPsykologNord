using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class ClientUnitTest
    {
        [TestMethod]
        public void ClientCreation()
        {
            Client testClient = new Client();

            Assert.IsNotNull(testClient);
        }

        [TestMethod]
        public void JournalCreation()
        {
            Client testClient = new Client();
            Assert.IsNotNull(testClient.Journal);
        }
    }
}
