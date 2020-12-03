using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Language
    {
        public String LanguageName { get; set; }

        public virtual ICollection<Item> items { get; set; }

        public Language() { }
        public Language(String Name)
        {
            this.LanguageName = Name;
        }
    }
}
