using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    class ReservationRecord
    {
        public int ReservationRecordID { get; set; }
        public int ItemID { get; set; }
        public int PatronID { get; set; }
        [MustExistBeforeValidator(ErrorMessage = "The reservation date is in te future!")]
        public System.DateTime ReservationDate { get; set; }
        public bool isResolved { get; set; }

        public virtual Item item { get; set; }
        public virtual Patron patron { get; set; }

        public ReservationRecord() { }
        public ReservationRecord(int ReservationRecordID, int ItemID, int PatronID)
        {
            this.ReservationRecordID = ReservationRecordID;
            this.ItemID = ItemID;
            this.PatronID = PatronID;
            this.ReservationDate = DateTime.Today;
            this.isResolved = false;
        }
    }
}
