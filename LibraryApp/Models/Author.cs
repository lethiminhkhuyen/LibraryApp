using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Author : Person
    {
        public String Biography { get; set; }

        public virtual ICollection<Title> titles { get; set; }
        public Author() { }
        public Author(String FirstName, String LastName, DateTime DateOfBirth, String Bio)
        {
            this.PersonFirstName = FirstName;
            this.PersonLastName = LastName;
            this.PersonDateOfBirth = DateOfBirth;
            this.Biography = Bio;
        }
    }
}
