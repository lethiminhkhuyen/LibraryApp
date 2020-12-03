using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class Item
    {
        public int Amount { get; set; }
        public int remainAmount { get; set; }
        public int ItemID { get; set; }
        public int TitleID { get; set; }
        [ISBNValidator(ErrorMessage ="ISBN should be start with ISBN followed by 13 numbers ")]
        public String ISBN { get; set; }
        public String Overview { get; set; }
        public String PublisherName { get; set; }
        [MustExistBeforeValidator(ErrorMessage ="The published date is in te future!")]
        public System.DateTime PublishedDate { get; set; }
        public String LanguageName { get; set; }
        public String TypeName { get; set; }
        public String FormatName { get; set; }
        public Double Price { get; set; }
        public bool isReserved { get; set; }

        public virtual Title tile { get; set; }
        public virtual Publisher publisher { get; set; }
        public virtual Language language { get; set; }
        public virtual Type type { get; set; }
        public virtual Format format { get; set; }
        public virtual ICollection<ReservationRecord> reservationRecords { get; set; }
        public void AddToAmout()
        {
            this.Amount++;
        }
    }
}
