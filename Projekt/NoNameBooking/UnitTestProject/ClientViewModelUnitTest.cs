using System;
using System.Net.Sockets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelClassLibrary;
using ViewModelClassLibrary;

namespace UnitTestProject
{
    [TestClass]
    public class ClientViewModelUnitTest
    {
        private ClientRepoViewModel _clientRepoView;

        [TestInitialize]
        public void ClientViewModelTestInitialize()
        {
            _clientRepoView = new ClientRepoViewModel();
        }
        [TestMethod]
        public void ClientViewModelCreation()
        {
            ClientRepoViewModel testClientRepoViewModel = new ClientRepoViewModel();

            Assert.IsNotNull(testClientRepoViewModel);
        }


        [TestMethod]
        public void ClientViewModelCreateClientMethod()
        {
            string clientName = "TestName";
            string clientEmail = "TestEmail@Test.com";
            string clientPhoneNumber = "testNumber";
            string clientAddress = "Testvej 12; dør 3; 4220; Testkøbing";
            string clientSSN = "12346578";
            string clientNote = "Dette er vores testnote.";

            _clientRepoView.CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSSN, clientNote);

            Assert.AreEqual(_clientRepoView.ClientName, clientName);
        }
    }
}
