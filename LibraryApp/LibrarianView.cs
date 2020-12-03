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
using System.Data.Entity.Migrations;

namespace LibraryApp
{
    public partial class LibrarianView : Form
    {
        String UserName;
        DateTime UserBirthday;
        Boolean ItemsViewing = false;
        Boolean PatronViewing = false;
        Boolean LibrarianViewing = false;
        public LibrarianView(String UserLogin, String UserPassword)
        {
            InitializeComponent();
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    this.UserName = context.Librarians.FirstOrDefault(s => s.UserLogin == UserLogin && s.UserPassword == UserPassword).PersonFirstName;
                    this.UserBirthday = context.Librarians.FirstOrDefault(s => s.UserLogin == UserLogin && s.UserPassword == UserPassword).PersonDateOfBirth;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            LoadingLibrarianData();
            DataFill();
            ItemsViewing = true;
            PatronViewing = false;
            LibrarianViewing = false;
            ShowStripMenu();
        }
        public void ShowStripMenu()
        {
            if(ItemsViewing)
            {
                editItemToolStripMenuItem.Visible = true;
                removeItemToolStripMenuItem.Visible = true;
                addAnotherCopyToolStripMenuItem.Visible = true;
                removeLibrarianToolStripMenuItem.Visible = false;
                activeAccountToolStripMenuItem.Visible = false;
                frozeAccountToolStripMenuItem.Visible = false;
                closeAccountToolStripMenuItem.Visible = false;
                calculateFineToolStripMenuItem.Visible = false;
                paidFineToolStripMenuItem.Visible = false;
            }
            else if (LibrarianViewing)
            {
                editItemToolStripMenuItem.Visible = false;
                removeItemToolStripMenuItem.Visible = false;
                addAnotherCopyToolStripMenuItem.Visible = false;
                removeLibrarianToolStripMenuItem.Visible = true;
                activeAccountToolStripMenuItem.Visible = false;
                frozeAccountToolStripMenuItem.Visible = false;
                closeAccountToolStripMenuItem.Visible = false;
                calculateFineToolStripMenuItem.Visible = false;
                paidFineToolStripMenuItem.Visible = false;
            }
            else if (PatronViewing)
            {
                editItemToolStripMenuItem.Visible = false;
                removeItemToolStripMenuItem.Visible = false;
                addAnotherCopyToolStripMenuItem.Visible = false;
                removeLibrarianToolStripMenuItem.Visible = false;
                activeAccountToolStripMenuItem.Visible = true;
                frozeAccountToolStripMenuItem.Visible = true;
                closeAccountToolStripMenuItem.Visible = true;
                calculateFineToolStripMenuItem.Visible = true;
                paidFineToolStripMenuItem.Visible = true;
            }
        }
        public void LoadingLibrarianData()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    this.UserName = context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonFirstName;
                    this.UserBirthday = context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonDateOfBirth;
                    UserNameTextbox.Text = context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonFirstName + " " + context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonLastName;
                    BirthdayTextbox.Text = context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonDateOfBirth.ToShortDateString();
                    EmailTextbox.Text = context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserEmail;
                    SalaryTextbox.Text = context.Librarians.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).Salary.ToString();
                    Address UserAddress = context.Addresses.FirstOrDefault(s => s.AddressID == context.Librarians.FirstOrDefault(u => u.PersonFirstName == UserName && u.PersonDateOfBirth == UserBirthday).UserAddress);
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
                                               TheAmount = a.Amount
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
                                                  TheAmount = a.Amount
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
                                               TheAmount = a.Amount
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
                                                  TheAmount = a.Amount
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
                                                        TheAmount = a.Amount
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
                                                        TheAmount = a.Amount
                                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillWithPatrons()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    ItemsDataGridView.DataSource = (from a in context.Patrons
                                                    join b in context.Addresses on a.UserAddress equals b.AddressID
                                                    join c in context.Streets on b.AddressStreetName equals c.StreetName
                                                    join d in context.PostCodes on b.AddressPostCode equals d.PostCodeId
                                                    join f in context.AreaCodes on d.FirstCodePart equals f.AreaCodeCode
                                                    join g in context.ArbitraryCodes on d.SecondCodePart equals g.ArbitraryCodeCode
                                                    orderby a.PersonLastName
                                                    select new
                                                    {
                                                        ID = a.PersonId,
                                                        Name = String.Concat(a.PersonFirstName, " ", a.PersonLastName),
                                                        Address = String.Concat(c.StreetName, " ", f.AreaCodeCode, "-", g.ArbitraryCodeCode),
                                                        Email = a.UserEmail,
                                                        Telephone = a.TelNumber,
                                                        OpenDate = a.AccountOpenDate,
                                                        Status = a.AccountStatus,
                                                        Borrowed = context.BorrowRecords.Count(s => s.PatronID == context.Patrons.FirstOrDefault(u => u.PersonId == a.PersonId).PersonId && s.ReturnedDate == null),
                                                        Reserved = context.ReservationRecords.Count(s => s.PatronID == context.Patrons.FirstOrDefault(u => u.PersonId == a.PersonId).PersonId && s.isResolved == false),
                                                        Owned = a.Fine
                                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void FillWithLibrarians()
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    ItemsDataGridView.DataSource = (from a in context.Librarians
                                                    join b in context.Addresses on a.UserAddress equals b.AddressID
                                                    join c in context.Streets on b.AddressStreetName equals c.StreetName
                                                    join d in context.PostCodes on b.AddressPostCode equals d.PostCodeId
                                                    join f in context.AreaCodes on d.FirstCodePart equals f.AreaCodeCode
                                                    join g in context.ArbitraryCodes on d.SecondCodePart equals g.ArbitraryCodeCode
                                                    orderby a.PersonLastName
                                                    select new
                                                    {
                                                        ID = a.PersonId,
                                                        Name = String.Concat(a.PersonFirstName, " ", a.PersonLastName),
                                                        Address = String.Concat(c.StreetName, " ", f.AreaCodeCode, "-", g.ArbitraryCodeCode),
                                                        Email = a.UserEmail,
                                                        Birthday = a.PersonDateOfBirth

                                                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GenreCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GenreCombobox.SelectedItem.ToString() != "All")
                DataFill(GenreCombobox.SelectedItem.ToString());
            else
                DataFill();
            ItemsViewing = true;
            PatronViewing = false;
            LibrarianViewing = false;
            ShowStripMenu();
        }

        private void AllPatronButton_Click(object sender, EventArgs e)
        {
            FillWithPatrons();
            ItemsViewing = false;
            PatronViewing = true;
            LibrarianViewing = false;
            ShowStripMenu();
        }

        private void AllLibrarianButton_Click(object sender, EventArgs e)
        {
            FillWithLibrarians();
            ItemsViewing = false;
            PatronViewing = false;
            LibrarianViewing = true;
            ShowStripMenu();
        }

        private void NewLibrarianButton_Click(object sender, EventArgs e)
        {
            var form2 = new RegisterLibrarianForm();
            form2.ShowDialog();
        }

        private void NewBookButton_Click(object sender, EventArgs e)
        {
            var form2 = new AddBookForm();
            form2.Closed += (s, args) => this.DataFill();
            form2.ShowDialog();
            ItemsViewing = true;
            PatronViewing = false;
            LibrarianViewing = false;
            ShowStripMenu();
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CategoryComboBox.SelectedItem.ToString() == "Borrowable")
                FillWithBorrowAble();
            else if (CategoryComboBox.SelectedItem.ToString() == "Non-borrowable")
                FillWithNonBorrowAble();
            else
                DataFill();
            ItemsViewing = true;
            PatronViewing = false;
            LibrarianViewing = false;
            ShowStripMenu();
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
                                               where c.PersonFirstName  == SearchTextbox.Text || c.PersonLastName == SearchTextbox.Text || String.Concat(c.PersonFirstName, " ", c.PersonLastName)== SearchTextbox.Text
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
                                                   TheAmount = a.Amount
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
                                                      TheAmount = a.Amount
                                                  }).ToList();
                        BorrowAbleItems.AddRange(NonBorrowAbleItems);
                        ItemsDataGridView.DataSource = BorrowAbleItems;
                    }
                    else if(TitleRadioButton.Checked)
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
                        ItemsViewing = true;
                        PatronViewing = false;
                        LibrarianViewing = false;
                        ShowStripMenu();
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
            var form3 = new RegisterLibrarianForm();
            form3.LoadDataForEdit(this.UserName, this.UserBirthday);
            form3.Closed += (s, args) => this.LoadingLibrarianData();
            form3.ShowDialog();
        }

        private void activeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String PatronName = ItemsDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        context.Patrons.FirstOrDefault(s => String.Concat(s.PersonFirstName, " ", s.PersonLastName) == PatronName).ChangeStatus(AccountState.Active);
                        context.SaveChanges();
                        this.FillWithPatrons();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frozeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String PatronName = ItemsDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        context.Patrons.FirstOrDefault(s => String.Concat(s.PersonFirstName, " ", s.PersonLastName) == PatronName).ChangeStatus(AccountState.Frozen);
                        context.SaveChanges();
                        this.FillWithPatrons();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void closeAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String PatronName = ItemsDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        context.Patrons.FirstOrDefault(s => String.Concat(s.PersonFirstName, " ", s.PersonLastName) == PatronName).ChangeStatus(AccountState.Closed);
                        context.SaveChanges();
                        this.FillWithPatrons();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void calculateFineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String PatronName = ItemsDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        context.Patrons.FirstOrDefault(s => String.Concat(s.PersonFirstName, " ", s.PersonLastName) == PatronName).CalculateAllFine();
                        context.SaveChanges();
                        this.FillWithPatrons();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void paidFineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String PatronName = ItemsDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        context.Patrons.FirstOrDefault(s => String.Concat(s.PersonFirstName, " ", s.PersonLastName) == PatronName).PaidFine();
                        context.SaveChanges();
                        this.FillWithPatrons();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String ItemName = ItemsDataGridView.SelectedRows[0].Cells["Title"].Value.ToString();
                String ItemAuthor = ItemsDataGridView.SelectedRows[0].Cells["Author"].Value.ToString();
                var form2 = new AddBookForm();
                form2.LoadDataForEdit(ItemName, ItemAuthor);
                form2.Closed += (s, args) => this.DataFill();
                form2.ShowDialog();
            }
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String ItemName = ItemsDataGridView.SelectedRows[0].Cells["Title"].Value.ToString();
                String ItemAuthor = ItemsDataGridView.SelectedRows[0].Cells["Author"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        if (context.BorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                        {
                            BorrowAble ToRemove = context.BorrowAbles.Single(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor);
                            context.BorrowAbles.Remove(ToRemove);
                        }
                            
                        else if (context.NonBorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                        {
                            NonBorrowAble ToRemove = context.NonBorrowAbles.Single(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor);
                            context.NonBorrowAbles.Remove(ToRemove);
                        }
                        context.SaveChanges();
                        this.DataFill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void addAnotherCopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                String ItemName = ItemsDataGridView.SelectedRows[0].Cells["Title"].Value.ToString();
                String ItemAuthor = ItemsDataGridView.SelectedRows[0].Cells["Author"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        if(context.BorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                            context.BorrowAbles.FirstOrDefault(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor).AddToAmout();
                        else if(context.NonBorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                            context.NonBorrowAbles.FirstOrDefault(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor).AddToAmout();
                        context.SaveChanges();
                        this.DataFill();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void removeLibrarianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ItemsDataGridView.SelectedRows.Count == 1)
            {
                DateTime LibBirthday = Convert.ToDateTime(ItemsDataGridView.SelectedRows[0].Cells["Birthday"].Value);
                String LibName = ItemsDataGridView.SelectedRows[0].Cells["Name"].Value.ToString();
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        Librarian ToRemove = context.Librarians.Single(s => String.Concat(s.PersonFirstName, " ", s.PersonLastName) == LibName && s.PersonDateOfBirth == LibBirthday);
                        context.Librarians.Remove(ToRemove);
                        context.SaveChanges();
                        this.FillWithLibrarians();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

    }
}
