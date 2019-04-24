using System;
using System.Collections.Generic;

namespace ModelClassLibrary
{
    public class ClientRepo
    {
        private static ClientRepo _instance;

        private readonly List<Client> _clients;

        private ClientRepo()
        {
            _clients = new List<Client>();
        }

        public static ClientRepo GetInstance()
        {
            return _instance ?? (_instance = new ClientRepo());
        }

        public Client CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, int clientSsn, string clientNote)
        {
            Client newClient = new Client(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote);

            _clients.Add(newClient);

            return newClient;
        }


        public int GetClientAmount()
        {
            return _clients.Count;
        }


    }
}
