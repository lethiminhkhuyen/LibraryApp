using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Librarian : User
    {
        public Double Salary { get; set; }

        public Librarian() { }
        public Librarian(String FirstName, String LastName, DateTime DateOfBirth, String Email, String Password, Double Salary, int Address)
        {
            this.PersonFirstName = FirstName;
            this.PersonLastName = LastName;
            this.PersonDateOfBirth = DateOfBirth;
            this.UserEmail = Email;
            this.UserLogin = FirstName.ToLower() + "." + LastName.ToLower();
            this.UserPassword = Password;
            this.UserAddress = Address;
            this.Salary = Salary;
        }
    }
}
