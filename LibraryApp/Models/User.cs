using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class User : Person
    {
        [LoginValidator(ErrorMessage = "Login is in format name.surname!")]
        public String UserLogin { get; set; }
        [PasswordValidator(ErrorMessage = "Password must have at least 1 Uppercase, 1 number and 1 special charactesr <>?*\\/|.-_! and has from 8 to 50 characters")]
        public String UserPassword { get; set; }
        public int UserAddress { get; set; }
        [EmailValidator(ErrorMessage = "Invalid email address!")]
        public String UserEmail { get; set; }

        public virtual Address address { get; set; }

        public User() { }
    }
}
