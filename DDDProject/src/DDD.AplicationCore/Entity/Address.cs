using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.AplicationCore.Entity
{
    public class Address
    {
        public Address()
        {

        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Zipcode { get; set; }
        public string Reference { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
