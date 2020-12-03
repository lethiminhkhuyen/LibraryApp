using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class DueDateValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Today = DateTime.Today;
            var DueDate = (DateTime)value;
            var days = (DueDate - Today).TotalDays;
            return days == 21 || days == 14;
        }
    }
}
