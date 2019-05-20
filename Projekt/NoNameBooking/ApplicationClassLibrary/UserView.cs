using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class UserView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Adresse { get; set; }
        public string Email { get; set; }

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
