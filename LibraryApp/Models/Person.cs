using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Person
    {
        public int PersonId { get; set; }
        [NameValidator(ErrorMessage ="Name cannot contains any special characters")]
        public String PersonFirstName { get; set; }
        public String PersonLastName { get; set; }
        [FivePlusAttribute(ErrorMessage = "You must be at leadt five years old to start to borrow book at our library!")]
        public System.DateTime PersonDateOfBirth { get; set; }

        public Person() { }
    }
}
