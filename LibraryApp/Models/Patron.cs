using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Models
{
    public enum AccountState { Active = 0, Frozen = 1, Closed = 2}
    class Patron : User
    {
        [TelValidator(ErrorMessage ="Tel must has 9 numbers")]
        public String TelNumber { get; set; }
        [MustExistBeforeValidator(ErrorMessage ="The opened date cannot be in the future!")]
        public DateTime AccountOpenDate { get; set; }
        public AccountState AccountStatus { get; set; }
        public Double Fine { get; set; }

        public virtual ICollection<BorrowRecord> borrowRecords { get; set; }
        public virtual ICollection<ReservationRecord> reservationRecords { get; set; }

        public Patron() { }

        public Patron(String FirstName, String LastName, DateTime DateOfBirth, String Email, String TelNumber, String Password, int Address)
        {
            this.PersonFirstName = FirstName;
            this.PersonLastName = LastName;
            this.PersonDateOfBirth = DateOfBirth;
            this.UserEmail = Email;
            this.UserLogin = FirstName.ToLower() + "." + LastName.ToLower();
            this.UserPassword = Password;
            this.UserAddress = Address;
            this.TelNumber = TelNumber;
            this.AccountOpenDate = DateTime.Today;
            this.AccountStatus = AccountState.Frozen;
        }
        public void CalculateAllFine()
        {
            foreach(BorrowRecord i in borrowRecords)
            {
                if (!i.isPaid)
                {
                    i.FineCalculation();
                    this.Fine += i.Fine;
                }
                    
            }
        }
        public void PaidFine()
        {
            foreach (BorrowRecord i in borrowRecords)
            {
                i.Fine = 0;
                i.isPaid = true;
            }
        }
        public void ChangeStatus(AccountState TheState)
        {
            this.AccountStatus = TheState;
        }
    }
}
