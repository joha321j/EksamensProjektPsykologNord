using System;

namespace ModelClassLibrary
{
    public class Client : User
    {
        internal string ClientSsn { get; }
        public string ClientNote { get; }
        public Journal Journal { get; }

        public Client(string clientName = "", string clientEmail = "", string clientPhoneNumber = "",
            string clientAddress = "", string clientSsn = "-1", string clientNote = "", int id = -1)
            : base(clientName, clientAddress, clientPhoneNumber, clientEmail, id)
        {
            ClientSsn = clientSsn;
            ClientNote = clientNote;
            Journal = new Journal();
        }
    }
}
