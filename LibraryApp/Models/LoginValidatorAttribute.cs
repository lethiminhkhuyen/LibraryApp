using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class LoginValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return new RegularExpressionAttribute(@"\w+\.+\w{1,50}").IsValid(Convert.ToString(value).Trim());
        }
    }
}
