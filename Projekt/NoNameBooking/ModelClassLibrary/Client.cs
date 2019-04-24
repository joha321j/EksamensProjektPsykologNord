using System;

namespace ModelClassLibrary
{
    public class Client
    {
        public string ClientName { get; }
        public string ClientEmail { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientAddress { get; }
        internal int ClientSsn { get; }
        public string ClientNote { get; }
        public Journal Journal { get; }

        public Client(string clientName = "", string clientEmail = "", string clientPhoneNumber = "", string clientAddress = "", int clientSsn = Int32.MinValue, string clientNote = "")
        {
            ClientName = clientName;
            ClientEmail = clientEmail;
            ClientPhoneNumber = clientPhoneNumber;
            ClientAddress = clientAddress;
            ClientSsn = clientSsn;
            ClientNote = clientNote;
            Journal = new Journal();
        }
    }
}
