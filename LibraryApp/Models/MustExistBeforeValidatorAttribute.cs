using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class MustExistBeforeValidatorAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Today = DateTime.Today;
            var PublishedDate = (DateTime)value;
            var result = DateTime.Compare(PublishedDate, Today);
            return result <= 0;
        }
    }
}
