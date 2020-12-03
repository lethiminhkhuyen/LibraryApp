using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class TodayDateValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Today = DateTime.Today;
            var ObjectDate = (DateTime)value;
            var result = DateTime.Compare(ObjectDate, Today);
            return result == 0;
        }
    }
}
