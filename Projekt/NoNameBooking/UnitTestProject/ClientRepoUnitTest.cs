using System;
using System.Text;
using System.Collections.Generic;
using ApplicationClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersistencyClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class ClientRepoUnitTest
    {
        private ClientRepo _clientRepo;
        private IPersistable _dbController;

        [TestInitialize]
        public void ClientRepoTestInitialize()
        {
            _dbController = new TestDBController();
            _clientRepo = ClientRepo.GetInstance(_dbController);
        }

        [TestMethod]
        public void ClientRepoCreation()
        {
            ClientRepo testClientRepo = ClientRepo.GetInstance(_dbController);

            Assert.IsNotNull(testClientRepo);
        }

        [TestMethod]
        public void ClientRepoSingleton()
        {
            ClientRepo firstRepo = ClientRepo.GetInstance(_dbController);
            
            Assert.AreEqual(firstRepo, _clientRepo);
        }

        [TestMethod]
        public void ClientRepoCreateClientMethod()
        {
            string clientName = "AndetTestName";
            string clientEmail = "TestTest@Test.com";
            string clientPhoneNumber = "54758838";
            string clientAddress = "Krårupvej 12; dør 3; 4990; Maribo";
            string clientSSN = "12346578";
            string clientNote = "Dette er vores testnote.";

            _clientRepo.CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSSN, clientNote);

            Assert.AreEqual(_clientRepo.GetClient(clientName).Name, clientName);
            Assert.AreEqual(_clientRepo.GetClient(clientName).Address, clientAddress);
        }

    }
}
