using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Genre
    {
        public String GenreName { get; set; }

        public virtual ICollection<Title> titles { get; set; }
        public Genre() { }
        public Genre(String Name)
        {
            this.GenreName = Name;
        }
    }
}
