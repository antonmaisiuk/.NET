using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt.Models
{
    public class Role
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SiteUser> Users { get; set; }
        public Role()
        {
            Users = new List<SiteUser>();
        }
    }
}
