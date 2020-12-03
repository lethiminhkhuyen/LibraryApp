using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Street
    {
        public String StreetName { get; set; }
        public virtual ICollection<Address> addresses { get; set; }

        public Street() { }
        public Street(String Name)
        {
            this.StreetName = Name;
        }
    }
}
