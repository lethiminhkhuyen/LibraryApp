using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Models
{
    class BorrowRecord
    {
        public int BorrowRecordID { get; set; }
        public int ItemID { get; set; }
        public int PatronID { get; set; }
        [TodayDateValidator(ErrorMessage = "The borrowed date has to be today!")]
        public System.DateTime BorrowedDate { get; set; }
        [TodayDateValidator(ErrorMessage = "The return date has to be today!")]
        public System.DateTime ReturnedDate { get; set; }
        [DueDateValidator(ErrorMessage = "The item can be borrowed for 3 weeks for normal items and 2 weeks for bestsellers!")]
        public System.DateTime DueDate { get; set; }
        public bool isRenewed { get; set; }
        public bool isPaid { get; set; }
        public Double Fine { get; set; }

        public virtual BorrowAble borrowAble { get; set; }
        public virtual Patron patron { get; set; }
        public BorrowRecord() { }
       public BorrowRecord(int BorrowRecordID, int ItemID, int PatronID)
        {
            this.BorrowRecordID = BorrowRecordID;
            this.ItemID = ItemID;
            this.PatronID = PatronID;
            this.BorrowedDate = DateTime.Today;
            if (!borrowAble.tile.isBestseller) this.DueDate = this.BorrowedDate.AddDays(21);
            else this.DueDate = this.BorrowedDate.AddDays(14);
            this.isRenewed = false;
            this.isPaid = false;
            this.Fine = 0;
        }
        public void Renew()
        {
            if (!isRenewed)
            {
                isRenewed = true;
                if (!borrowAble.tile.isBestseller) DueDate = DateTime.Today.AddDays(21);
                else DueDate = DateTime.Today.AddDays(14);
            }
            else
            {
                MessageBox.Show("You cannot renew this item again!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //ModelState.AddModelError("Name", $"The Name '{viewModel.Name}' is already in use, please enter a different name.");
                //return View(nameof(CreateUser), viewModel);
                //Console.WriteLine("Already renewed!");
            }
        }
        public void FineCalculation()
        {
            Double Value = 0;
            if(DateTime.Compare(ReturnedDate, DueDate) > 0)
                Value = (ReturnedDate - DueDate).TotalDays * 0.1;
            if (Value <= borrowAble.Price)
                Fine = Value;
            else
                Fine = borrowAble.Price;
        }
    }
}
