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
        private ClientViewModel _clientView;

        [TestInitialize]
        public void ClientViewModelTestInitialize()
        {
            _clientView = new ClientViewModel();
        }
        [TestMethod]
        public void ClientViewModelCreation()
        {
            ClientViewModel testClientViewModel = new ClientViewModel();

            Assert.IsNotNull(testClientViewModel);
        }


        [TestMethod]
        public void ClientViewModelCreateClientMethod()
        {
            string clientName = "TestName";
            string clientEmail = "TestEmail@Test.com";
            string clientPhoneNumber = "testNumber";
            string clientAddress = "Testvej 12; dør 3; 4220; Testkøbing";
            int clientSSN = 12346578;
            string clientNote = "Dette er vores testnote.";

            _clientView.CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSSN, clientNote);

            Assert.AreEqual(_clientView.ClientName, clientName);
        }
    }
}
