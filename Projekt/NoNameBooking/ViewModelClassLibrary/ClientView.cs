using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModelClassLibrary
{
    public class ClientView
    {
        public string Name { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public string Email { get; }
        internal string ClientSsn { get; }
        public string ClientNote { get; }
        public JournalView Journal { get; }

        public ClientView(string name, string phoneNumber, string address, string email, string clientSsn, string clientNote, JournalView journal = null)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            ClientSsn = clientSsn;
            ClientNote = clientNote;

            Journal = journal ?? new JournalView();
        }
    }
}
