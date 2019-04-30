using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class Controller
    {
        private static Controller _instance;

        private Controller()
        {
        }

        public static Controller GetInstance()
        {
            return _instance ?? (_instance = new Controller());
        }

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, string clientSsn, string clientNote)
        {
            InputValidator.EnsureValidPhoneNumber(clientPhoneNumber);
            InputValidator.EnsureValidSsn(clientSsn);
            InputValidator.ensureValidZip(clientAddress);
        }
    }
}
