using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class UserView
    {
        public int Id { get;}
        public string Name { get; }
        public string PhoneNumber { get; }
        public string Adresse { get; }
        public string Email { get; }

        public UserView(int id, string name,string phoneNumber, string adresse,string email)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Adresse = adresse;
            Email = email;
        }

        public UserView()
        {
        }
    }
}
