using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class FivePlusAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Today = DateTime.Today;
            var Birthdate = (DateTime)value;
            var age = Today.Year - Birthdate.Year;
            if (Birthdate > Today.AddYears(-age)) age--;
            return age >= 5;
        }
    }
}
