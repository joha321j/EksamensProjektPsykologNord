using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class ClientRepo
    {
        private static ClientRepo _instance;

        private readonly List<Client> _clients;

        public EventHandler NewClientEventHandler;

        private ClientRepo()
        {
            _clients = new List<Client>();
        }

        public static ClientRepo GetInstance()
        {
            return _instance ?? (_instance = new ClientRepo());
        }

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber,
            string clientAddress, string clientSsn, string clientNote)
        {
            Client newClient = new Client(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote);

            _clients.Add(newClient);

            NewClientEventHandler?.Invoke(newClient, EventArgs.Empty);
        }


        public int GetClientAmount()
        {
            return _clients.Count;
        }


        public List<Client> GetClients()
        {
            return _clients;
        }

        public Client GetClient(string clientName)
        {
            return _clients.Find(client => string.Equals(client.Name, clientName));
        }
    }
}
