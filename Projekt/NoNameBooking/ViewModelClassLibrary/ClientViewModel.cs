using System;
using ModelClassLibrary;

namespace ViewModelClassLibrary
{
    public class ClientViewModel
    {
        private Client _currentClient;
        private readonly ClientRepo _clientRepo = ClientRepo.GetInstance();
        public string ClientName => _currentClient.Name;

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, string clientSsn, string clientNote)
        {
            _currentClient = _clientRepo.CreateClient(clientName, clientEmail,
                                     clientPhoneNumber, clientAddress,
                                     clientSsn, clientNote);

        }
    }
}
