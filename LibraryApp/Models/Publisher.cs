using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Publisher
    {
        public String PublisherName { get; set; }

        public virtual ICollection<Item> items { get; set; }
        public Publisher() { }
        public Publisher(String Name)
        {
            this.PublisherName = Name;
        }
    }
}
