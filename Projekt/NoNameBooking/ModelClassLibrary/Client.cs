using System;

namespace ModelClassLibrary
{
    public class Client : User
    {
        private string SocialSecurityNumber { get; }
        public string Note { get; }
        public Journal Journal { get; }

        public Client(string clientName = "", string clientEmail = "", string clientPhoneNumber = "",
            string clientAddress = "", string socialSecurityNumber = "-1", string note = "", int id = -1)
            : base(clientName, clientAddress, clientPhoneNumber, clientEmail, id)
        {
            SocialSecurityNumber = socialSecurityNumber;
            Note = note;
            Journal = new Journal();
        }
    }
}
