using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class NameValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            RegularExpressionAttribute rule = new RegularExpressionAttribute(@"(?=.*[#\[\]\@!$%^&()<>\?\*\\/\|\.\-\\_]){2,100}.+$");
            return !rule.IsValid(Convert.ToString(value).Trim());
        }
    }
}
