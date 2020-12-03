using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class AreaCode
    {
        [MustHasTwoCharacters(ErrorMessage = "The Area Code should has 2 numbers")]
        public String AreaCodeCode { get; set; }

        public virtual ICollection<PostCode> postCodes { get; set; }
        public AreaCode() { }
        public AreaCode(String Code)
        {
            this.AreaCodeCode = Code;
        }
    }
}
