using System;
using System.Collections.Generic;
using System.Text;
using ModelClassLibrary;

namespace ApplicationClassLibrary
{
    public class Controller
    {
        private static Controller _instance;
        private readonly ClientRepo _clientRepo;

        public EventHandler NewClientCreatedEventHandler;

        private Controller()
        {
            _clientRepo = ClientRepo.GetInstance();
            _clientRepo.NewClientEventHandler += NewClientEventHandler;
        }

        private void NewClientEventHandler(object sender, EventArgs e)
        {
            NewClientCreatedEventHandler.Invoke(((Client) sender).Name, e);
        }

        public static Controller GetInstance()
        {
            return _instance ?? (_instance = new Controller());
        }

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, string clientSsn, string clientNote)
        {
            InputValidator.EnsureValidPhoneNumber(clientPhoneNumber);
            InputValidator.EnsureValidSsn(clientSsn);
            InputValidator.EnsureValidZip(clientAddress);

            _clientRepo.CreateClient(clientName, clientEmail, clientPhoneNumber, clientAddress, clientSsn, clientNote);
        }

        public List<string> GetClientNames()
        {
            List<Client> clients = _clientRepo.GetClients();

            return clients.ConvertAll(client => client.Name);
        }
    }
}
