using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList
{
    class Contact
    {
        // Properties for contact
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Constructor
        public Contact(int id, string name, string email, string phone, string address)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }
    }
}
