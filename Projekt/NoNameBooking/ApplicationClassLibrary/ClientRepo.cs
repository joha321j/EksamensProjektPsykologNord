using System;
using System.Collections.Generic;
using ModelClassLibrary;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    public class ClientRepo
    {
        private static IPersistable _persistable;
        private static ClientRepo _instance;

        private List<Client> _clients;

        public EventHandler NewClientEventHandler;

        private ClientRepo(IPersistable persistable)
        {
            _persistable = persistable;
            _clients = _persistable.GetClients();
        }

        public static ClientRepo GetInstance(IPersistable persistable)
        {
            return _instance ?? (_instance = new ClientRepo(persistable));
        }

        public void CreateAndAddClient(string clientName, string clientEmail, string clientPhoneNumber,
            string clientAddress, string clientSsn, string clientNote)
        {
            int clientId = _persistable.SaveUser(clientName, clientAddress, clientPhoneNumber, clientEmail);
            _persistable.SaveClient(clientId, clientNote, clientSsn);

            Client newClient = CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote, clientId);
            
            _clients.Add(newClient);

            NewClientEventHandler?.Invoke(newClient, EventArgs.Empty);
        }

        private Client CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, string clientSsn, string clientNote, int clientId)
        {
            return new Client(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote, clientId);
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

        public bool IsClient(UserView user)
        {
            return _clients.Exists(client => client.Id == user.Id);
        }
        
        public void Reset()
        {
            _instance = null;
        }

        public void Update()
        {
            _clients = _persistable.GetClients();
        }
    }
}
