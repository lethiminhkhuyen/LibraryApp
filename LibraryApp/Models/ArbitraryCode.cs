using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class ArbitraryCode
    {
        [MustHasThreeCharacters(ErrorMessage = "The Arbitrary Code should has 3 numbers")]
        public String ArbitraryCodeCode { get; set; }

        public virtual ICollection<PostCode> postCodes { get; set; }
        public ArbitraryCode() { }
        public ArbitraryCode(String Code)
        {
            this.ArbitraryCodeCode = Code;
        }
    }
}
