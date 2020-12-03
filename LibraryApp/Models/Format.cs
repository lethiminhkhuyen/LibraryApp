using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Format
    {
        public String FormatName { get; set; }

        public virtual ICollection<Item> items { get; set; }

        public Format() { }
        public Format(String Name)
        {
            this.FormatName = Name;
            this.FormatName = Name;
        }
    }
}
