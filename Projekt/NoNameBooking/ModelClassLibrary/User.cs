using System;
using System.Collections.Generic;
using System.Text;

namespace ModelClassLibrary
{
    public class User
    {
        public string Name { get; }
        public string PhoneNumber { get; }
        public string Address { get; }
        public string Email { get; }

        public User(string name = "", string address = "", string phoneNumber = "", string email ="")
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
