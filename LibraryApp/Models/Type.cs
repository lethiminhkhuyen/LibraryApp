using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Type
    {
        public String TypeName { get; set; }

        public virtual ICollection<Item> items { get; set; }
        public Type() { }
        public Type(String Name)
        {
            this.TypeName = Name;
        }
    }
}
