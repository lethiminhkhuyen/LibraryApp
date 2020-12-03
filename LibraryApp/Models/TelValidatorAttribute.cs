using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class TelValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return new RegularExpressionAttribute(@"\d{9}").IsValid(Convert.ToString(value).Trim());
        }
    }
}
