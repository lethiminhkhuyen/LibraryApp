using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class PasswordValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return new RegularExpressionAttribute(@"(?=.*[A-Z])(?=.*[0-9])(?=.*[<>\?\*\\/\|\.\-\\_]){8,50}.+$").IsValid(Convert.ToString(value).Trim());
        }
    }
}
