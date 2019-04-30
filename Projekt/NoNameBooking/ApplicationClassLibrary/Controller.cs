using System;
using System.Collections.Generic;
using System.Text;

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
            NewClientCreatedEventHandler.Invoke(sender.ToString(), e);
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
            throw new NotImplementedException();
        }
    }
}
