using LibraryApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class UserView : Form
    {
        String UserName;
        DateTime UserBirthday;
        //String UserLogin;
        //String UserPassword;
        public UserView(String UserLogin, String UserPassword)
        {
            InitializeComponent();
            //this.UserLogin = UserLogin;
            //this.UserPassword = UserPassword;
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    this.UserName = context.Patrons.FirstOrDefault(s => s.UserLogin == UserLogin && s.UserPassword == UserPassword).PersonFirstName;
                    this.UserBirthday = context.Patrons.FirstOrDefault(s => s.UserLogin == UserLogin && s.UserPassword == UserPassword).PersonDateOfBirth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadingUserData();
            DataFill();
        }
        public void LoadingUserData()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    this.UserName = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonFirstName;
                    this.UserBirthday = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonDateOfBirth;
                    UserNameTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonFirstName + " " + context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonLastName;
                    BirthdayTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonDateOfBirth.ToShortDateString();
                    EmailTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserEmail;
                    TelTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).TelNumber;
                    Address UserAddress = context.Addresses.FirstOrDefault(s => s.AddressID == context.Patrons.FirstOrDefault(u => u.PersonFirstName == UserName && u.PersonDateOfBirth == UserBirthday).UserAddress);
                    String result = "";
                    if (!String.IsNullOrEmpty(UserAddress.AddressHousename))
                        result += UserAddress.AddressHousename + "\r\n";
                    result += UserAddress.AddressStreetName;
                    if (UserAddress.AddressHouseNumber != 0)
                        result += " " + UserAddress.AddressHouseNumber;
                    if (UserAddress.AddressFlatNumber != 0)
                        result += "/" + UserAddress.AddressFlatNumber;
                    result += "\r\n" + context.PostCodes.FirstOrDefault(s => s.PostCodeId == UserAddress.AddressPostCode).FirstCodePart + "-" + context.PostCodes.FirstOrDefault(s => s.PostCodeId == UserAddress.AddressPostCode).SecondCodePart + " Warsaw\r\nPoland";
                    AddressTextbox.Text = result;
                    BorrowedAmountTextbox.Text = context.BorrowRecords.Count(s => s.PatronID == context.Patrons.FirstOrDefault(u => u.PersonFirstName == UserName && u.PersonDateOfBirth == UserBirthday).PersonId && s.ReturnedDate == null).ToString();
                    ReservedTextbox.Text = context.ReservationRecords.Count(s => s.PatronID == context.Patrons.FirstOrDefault(u => u.PersonFirstName == UserName && u.PersonDateOfBirth == UserBirthday).PersonId && s.isResolved == false).ToString();
                    List<String> GenresName = new List<String>();
                    GenresName.Add("All");
                    GenresName.AddRange(context.Genres.Select(s => s.GenreName).ToList());
                    GenreCombobox.DataSource = GenresName;
                    String[] CategoriesName = { "All", "Borrowable", "Non-borrowable" };
                    CategoryComboBox.DataSource = CategoriesName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DataFill()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    var BorrowAbleItems = (from a in context.BorrowAbles
                                           join b in context.Titles on a.TitleID equals b.TitleID
                                           join c in context.Authors on b.AuthorID equals c.PersonId
                                           join d in context.Genres on b.GenreName equals d.GenreName
                                           join e in context.Publishers on a.PublisherName equals e.PublisherName
                                           join f in context.Languages on a.LanguageName equals f.LanguageName
                                           join g in context.Types on a.TypeName equals g.TypeName
                                           join h in context.Formats on a.FormatName equals h.FormatName
                                           orderby b.TitleName
                                           select new
                                           {
                                               ID = a.ItemID,
                                               Title = b.TitleName,
                                               Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                               Genre = d.GenreName,
                                               Publisher = e.PublisherName,
                                               Language = f.LanguageName,
                                               Type = g.TypeName,
                                               Format = a.FormatName,
                                               Availability = (!a.isBorrowed && !a.isReserved) ? "yes" : "no"
                                           }).ToList();
                    var NonBorrowAbleItems = (from a in context.NonBorrowAbles
                                              join b in context.Titles on a.TitleID equals b.TitleID
                                              join c in context.Authors on b.AuthorID equals c.PersonId
                                              join d in context.Genres on b.GenreName equals d.GenreName
                                              join e in context.Publishers on a.PublisherName equals e.PublisherName
                                              join f in context.Languages on a.LanguageName equals f.LanguageName
                                              join g in context.Types on a.TypeName equals g.TypeName
                                              join h in context.Formats on a.FormatName equals h.FormatName
                                              orderby b.TitleName
                                              select new
                                              {
                                                  ID = a.ItemID,
                                                  Title = b.TitleName,
                                                  Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                  Genre = d.GenreName,
                                                  Publisher = e.PublisherName,
                                                  Language = f.LanguageName,
                                                  Type = g.TypeName,
                                                  Format = a.FormatName,
                                                  Availability = (!a.isReserved) ? "yes" : "no"
                                              }).ToList();
                    BorrowAbleItems.AddRange(NonBorrowAbleItems);
                    ItemsDataGridView.DataSource = BorrowAbleItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DataFill(String GenreFilter)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    var BorrowAbleItems = (from a in context.BorrowAbles
                                           join b in context.Titles on a.TitleID equals b.TitleID
                                           join c in context.Authors on b.AuthorID equals c.PersonId
                                           join d in context.Genres on b.GenreName equals d.GenreName
                                           join e in context.Publishers on a.PublisherName equals e.PublisherName
                                           join f in context.Languages on a.LanguageName equals f.LanguageName
                                           join g in context.Types on a.TypeName equals g.TypeName
                                           join h in context.Formats on a.FormatName equals h.FormatName
                                           where d.GenreName == GenreFilter
                                           orderby b.TitleName
                                           select new
                                           {
                                               ID = a.ItemID,
                                               Title = b.TitleName,
                                               Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                               Genre = d.GenreName,
                                               Publisher = e.PublisherName,
                                               Language = f.LanguageName,
                                               Type = g.TypeName,
                                               Format = a.FormatName,
                                               Availability = (!a.isBorrowed && !a.isReserved) ? "yes" : "no"
                                           }).ToList();
                    var NonBorrowAbleItems = (from a in context.NonBorrowAbles
                                              join b in context.Titles on a.TitleID equals b.TitleID
                                              join c in context.Authors on b.AuthorID equals c.PersonId
                                              join d in context.Genres on b.GenreName equals d.GenreName
                                              join e in context.Publishers on a.PublisherName equals e.PublisherName
                                              join f in context.Languages on a.LanguageName equals f.LanguageName
                                              join g in context.Types on a.TypeName equals g.TypeName
                                              join h in context.Formats on a.FormatName equals h.FormatName
                                              where d.GenreName == GenreFilter
                                              orderby b.TitleName
                                              select new
                                              {
                                                  ID = a.ItemID,
                                                  Title = b.TitleName,
                                                  Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                  Genre = d.GenreName,
                                                  Publisher = e.PublisherName,
                                                  Language = f.LanguageName,
                                                  Type = g.TypeName,
                                                  Format = a.FormatName,
                                                  Availability = (!a.isReserved) ? "yes" : "no"
                                              }).ToList();
                    BorrowAbleItems.AddRange(NonBorrowAbleItems);
                    ItemsDataGridView.DataSource = BorrowAbleItems;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillWithBorrowAble()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    ItemsDataGridView.DataSource = (from a in context.BorrowAbles
                                                    join b in context.Titles on a.TitleID equals b.TitleID
                                                    join c in context.Authors on b.AuthorID equals c.PersonId
                                                    join d in context.Genres on b.GenreName equals d.GenreName
                                                    join e in context.Publishers on a.PublisherName equals e.PublisherName
                                                    join f in context.Languages on a.LanguageName equals f.LanguageName
                                                    join g in context.Types on a.TypeName equals g.TypeName
                                                    join h in context.Formats on a.FormatName equals h.FormatName
                                                    orderby b.TitleName
                                                    select new
                                                    {
                                                        ID = a.ItemID,
                                                        Title = b.TitleName,
                                                        Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                        Genre = d.GenreName,
                                                        Publisher = e.PublisherName,
                                                        Language = f.LanguageName,
                                                        Type = g.TypeName,
                                                        Format = a.FormatName,
                                                        Availability = (!a.isBorrowed && !a.isReserved) ? "yes" : "no"
                                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillWithNonBorrowAble()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    ItemsDataGridView.DataSource = (from a in context.NonBorrowAbles
                                                     join b in context.Titles on a.TitleID equals b.TitleID
                                                     join c in context.Authors on b.AuthorID equals c.PersonId
                                                     join d in context.Genres on b.GenreName equals d.GenreName
                                                     join e in context.Publishers on a.PublisherName equals e.PublisherName
                                                     join f in context.Languages on a.LanguageName equals f.LanguageName
                                                     join g in context.Types on a.TypeName equals g.TypeName
                                                     join h in context.Formats on a.FormatName equals h.FormatName
                                                    orderby b.TitleName
                                                    select new
                                                     {
                                                         ID = a.ItemID,
                                                         Title = b.TitleName,
                                                         Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                         Genre = d.GenreName,
                                                         Publisher = e.PublisherName,
                                                         Language = f.LanguageName,
                                                         Type = g.TypeName,
                                                         Format = a.FormatName,
                                                         Availability = (!a.isReserved) ? "yes" : "no"
                                                     }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedItem.ToString() == "Borrowable")
                FillWithBorrowAble();
            else if (CategoryComboBox.SelectedItem.ToString() == "Non-borrowable")
                FillWithNonBorrowAble();
            else
                DataFill();
        }

        private void GenreCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenreCombobox.SelectedItem.ToString() != "All")
                DataFill(GenreCombobox.SelectedItem.ToString());
            else
                DataFill();
        }

        private void SearchButton_Click(object sender, EventArgs k)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    if (AuthorRadioButton.Checked)
                    {
                        var BorrowAbleItems = (from a in context.BorrowAbles
                                               join b in context.Titles on a.TitleID equals b.TitleID
                                               join c in context.Authors on b.AuthorID equals c.PersonId
                                               join d in context.Genres on b.GenreName equals d.GenreName
                                               join e in context.Publishers on a.PublisherName equals e.PublisherName
                                               join f in context.Languages on a.LanguageName equals f.LanguageName
                                               join g in context.Types on a.TypeName equals g.TypeName
                                               join h in context.Formats on a.FormatName equals h.FormatName
                                               where c.PersonFirstName == SearchTextbox.Text || c.PersonLastName == SearchTextbox.Text || String.Concat(c.PersonFirstName, " ", c.PersonLastName) == SearchTextbox.Text
                                               orderby b.TitleName
                                               select new
                                               {
                                                   ID = a.ItemID,
                                                   Title = b.TitleName,
                                                   Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                   Genre = d.GenreName,
                                                   Publisher = e.PublisherName,
                                                   Language = f.LanguageName,
                                                   Type = g.TypeName,
                                                   Format = a.FormatName,
                                                   Availability = (!a.isBorrowed && !a.isReserved) ? "yes" : "no"
                                               }).ToList();
                        var NonBorrowAbleItems = (from a in context.NonBorrowAbles
                                                  join b in context.Titles on a.TitleID equals b.TitleID
                                                  join c in context.Authors on b.AuthorID equals c.PersonId
                                                  join d in context.Genres on b.GenreName equals d.GenreName
                                                  join e in context.Publishers on a.PublisherName equals e.PublisherName
                                                  join f in context.Languages on a.LanguageName equals f.LanguageName
                                                  join g in context.Types on a.TypeName equals g.TypeName
                                                  join h in context.Formats on a.FormatName equals h.FormatName
                                                  where c.PersonFirstName == SearchTextbox.Text || c.PersonLastName == SearchTextbox.Text || String.Concat(c.PersonFirstName, " ", c.PersonLastName) == SearchTextbox.Text
                                                  orderby b.TitleName
                                                  select new
                                                  {
                                                      ID = a.ItemID,
                                                      Title = b.TitleName,
                                                      Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                      Genre = d.GenreName,
                                                      Publisher = e.PublisherName,
                                                      Language = f.LanguageName,
                                                      Type = g.TypeName,
                                                      Format = a.FormatName,
                                                      Availability = (!a.isReserved) ? "yes" : "no"
                                                  }).ToList();
                        BorrowAbleItems.AddRange(NonBorrowAbleItems);
                        ItemsDataGridView.DataSource = BorrowAbleItems;
                    }
                    else if (TitleRadioButton.Checked)
                    {
                        var BorrowAbleItems = (from a in context.BorrowAbles
                                               join b in context.Titles on a.TitleID equals b.TitleID
                                               join c in context.Authors on b.AuthorID equals c.PersonId
                                               join d in context.Genres on b.GenreName equals d.GenreName
                                               join e in context.Publishers on a.PublisherName equals e.PublisherName
                                               join f in context.Languages on a.LanguageName equals f.LanguageName
                                               join g in context.Types on a.TypeName equals g.TypeName
                                               join h in context.Formats on a.FormatName equals h.FormatName
                                               where b.TitleName.Contains(SearchTextbox.Text)
                                               orderby b.TitleName
                                               select new
                                               {
                                                   ID = a.ItemID,
                                                   Title = b.TitleName,
                                                   Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                   Genre = d.GenreName,
                                                   Publisher = e.PublisherName,
                                                   Language = f.LanguageName,
                                                   Type = g.TypeName,
                                                   Format = a.FormatName,
                                                   Availability = (!a.isBorrowed && !a.isReserved) ? "yes" : "no"
                                               }).ToList();
                        var NonBorrowAbleItems = (from a in context.NonBorrowAbles
                                                  join b in context.Titles on a.TitleID equals b.TitleID
                                                  join c in context.Authors on b.AuthorID equals c.PersonId
                                                  join d in context.Genres on b.GenreName equals d.GenreName
                                                  join e in context.Publishers on a.PublisherName equals e.PublisherName
                                                  join f in context.Languages on a.LanguageName equals f.LanguageName
                                                  join g in context.Types on a.TypeName equals g.TypeName
                                                  join h in context.Formats on a.FormatName equals h.FormatName
                                                  where b.TitleName.Contains(SearchTextbox.Text)
                                                  orderby b.TitleName
                                                  select new
                                                  {
                                                      ID = a.ItemID,
                                                      Title = b.TitleName,
                                                      Author = String.Concat(c.PersonFirstName, " ", c.PersonLastName),
                                                      Genre = d.GenreName,
                                                      Publisher = e.PublisherName,
                                                      Language = f.LanguageName,
                                                      Type = g.TypeName,
                                                      Format = a.FormatName,
                                                      Availability = (!a.isReserved) ? "yes" : "no"
                                                  }).ToList();
                        BorrowAbleItems.AddRange(NonBorrowAbleItems);
                        ItemsDataGridView.DataSource = BorrowAbleItems;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            var form3 = new RegisterUserForm();
            form3.LoadDataForEdit(this.UserName, this.UserBirthday);
            form3.Closed += (s, args) => this.LoadingUserData();
            form3.ShowDialog();
        }

        private void viewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String ItemName = ItemsDataGridView.SelectedRows[0].Cells["Title"].Value.ToString();
                String ItemAuthor = ItemsDataGridView.SelectedRows[0].Cells["Author"].Value.ToString();
                var form2 = new AddBookForm();
                form2.LoadDataForView(ItemName, ItemAuthor);
                form2.Closed += (s, args) => this.DataFill();
                form2.ShowDialog();
            }
        }
    }
}
