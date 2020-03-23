using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.AplicationCore.Entity
{
    public class Profession
    {
        public Profession()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CBO { get; set; }
        public ICollection<ClientProfession> ClientProfessions { get; set; }
    }
}
