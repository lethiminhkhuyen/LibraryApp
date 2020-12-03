using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Title
    {
        public int TitleID { get; set; }
        public int AuthorID { get; set; }
        public String TitleName { get; set; }
        public String GenreName { get; set; }
        public bool isBestseller { get; set; }

        public virtual Author author { get; set; }
        public virtual Genre genre { get; set; }
        public virtual ICollection<Item> items { get; set; }

        public Title() { }
        public Title(int Author, String Name, String Genre)
        {
            this.AuthorID = Author;
            this.TitleName = Name;
            this.GenreName = Genre;
            this.isBestseller = false;
        }
        public Title(int Author, String Name, String Genre, bool Bestseller)
        {
            this.AuthorID = Author;
            this.TitleName = Name;
            this.GenreName = Genre;
            this.isBestseller = Bestseller;
        }
    }
}
