using System;
using System.Collections.Generic;
using System.Text;

namespace DDD.AplicationCore.Entity
{
    public class Menu
    {
        public Menu()
        {
            
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public int? MenuId { get; set; }
        public ICollection<Menu> SubMenu { get; set; }
    }
}
