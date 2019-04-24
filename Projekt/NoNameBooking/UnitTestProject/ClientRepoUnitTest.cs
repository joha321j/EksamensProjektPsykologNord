using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class ClientRepoUnitTest
    {
        private ClientRepo _clientRepo;

        [TestInitialize]
        public void ClientRepoTestInitialize()
        {
            _clientRepo = ClientRepo.GetInstance();
        }

        [TestMethod]
        public void ClientRepoCreation()
        {
            ClientRepo testClientRepo = ClientRepo.GetInstance();

            Assert.IsNotNull(testClientRepo);
        }

        [TestMethod]
        public void ClientRepoSingleton()
        {
            ClientRepo firstRepo = ClientRepo.GetInstance();
            
            Assert.AreEqual(firstRepo, _clientRepo);
        }

        [TestMethod]
        public void ClientRepoCreateClientMethod()
        {
            string clientName = "AndetTestName";
            string clientEmail = "TestTest@Test.com";
            string clientPhoneNumber = "54758838";
            string clientAddress = "Krårupvej 12; dør 3; 4990; Maribo";
            int clientSSN = 12346578;
            string clientNote = "Dette er vores testnote.";

            _clientRepo.CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSSN, clientNote);

            Assert.AreEqual(_clientRepo.GetClientAmount(), 1);
        }

    }
}
