using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    
    class PostCode
    {
     public int PostCodeId { get; set; }
     public String FirstCodePart { get; set; }
     public String SecondCodePart { get; set; }

     public virtual AreaCode areaCode { get; set; }
     public virtual ArbitraryCode arbitraryCode { get; set; }
     public virtual ICollection<Address> addresses { get; set; }

        public PostCode() { }
        public PostCode(String First, String Second)
        {
            this.FirstCodePart = First;
            this.SecondCodePart = Second;
        }
    }
}
