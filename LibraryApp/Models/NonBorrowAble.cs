using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp.Models
{
    class NonBorrowAble :Item
    {
        public bool isInUsed { get; set; }

        public NonBorrowAble() { }
        public NonBorrowAble(int Title, String ISBN, String Overview, String Publisher, DateTime PublishedDate, String Language, String Type, Double Price, String Format)
        {
            this.Amount = 1;
            this.remainAmount = 1;
            this.TitleID = Title;
            this.ISBN = ISBN;
            this.Overview = Overview;
            this.PublisherName = Publisher;
            this.PublishedDate = PublishedDate;
            this.LanguageName = Language;
            if (((Type == "Book" || Type == "Reference Book") && (Format == "Hardcover" || Format == "Paperback"))
                || (Type == "Magazine" && Format == "Paperback")
                || (Type == "Audiobook" && (Format == "Audio CD" || Format == "Mp3 CD")))
            {
                this.TypeName = Type;
                this.FormatName = Format;
            }
            else
            {
                MessageBox.Show("The Type and Format are not match");
            }
            this.Price = Price;
            this.isReserved = false;
            this.isInUsed = false;
        }
        public NonBorrowAble(int Title, String ISBN, String Overview, String Publisher, DateTime PublishedDate, String Language, String Type, Double Price, String Format, int Amount)
        {
            this.Amount = Amount;
            this.remainAmount = Amount;
            this.TitleID = Title;
            this.ISBN = ISBN;
            this.Overview = Overview;
            this.PublisherName = Publisher;
            this.PublishedDate = PublishedDate;
            this.LanguageName = Language;
            if (((Type == "Book" || Type == "Reference Book") && (Format == "Hardcover" || Format == "Paperback"))
                || (Type == "Magazine" && Format == "Paperback")
                || (Type == "Audiobook" && (Format == "Audio CD" || Format == "Mp3 CD")))
            {
                this.TypeName = Type;
                this.FormatName = Format;
            }
            else
            {
                MessageBox.Show("The Type and Format are not match");
            }
            this.Price = Price;
            this.isReserved = false;
            this.isInUsed = false;
        }
    }
}
