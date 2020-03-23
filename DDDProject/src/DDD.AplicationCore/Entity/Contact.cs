using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.AplicationCore.Entity
{
    public class Contact
    {
        public Contact()
        {

        }

        public int Id { get; set; }
        public string Name{ get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
