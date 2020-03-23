using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.AplicationCore.Entity
{
    public class Client
    {
        public Client()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public Address Address { get; set; }
        public ICollection<ClientProfession> ClientProfessions { get; set; }
    }
}