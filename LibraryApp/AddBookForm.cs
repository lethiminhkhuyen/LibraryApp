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
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    GenreCombobox.DataSource = context.Genres.Select(s => s.GenreName).ToList();
                    LanguageCombobox.DataSource = context.Languages.Select(s => s.LanguageName).ToList();
                    TypeCombobox.DataSource = context.Types.Select(s => s.TypeName).ToList();
                    FormatCombobox.DataSource = context.Formats.Select(s => s.FormatName).ToList();
                    String[] Categories = { "Borrowable", "Non-borrowable" };
                    CategoryCombobox.DataSource = Categories;
                    SendButton.Visible = true;
                    BorrowButton.Visible = false;
                    ReserveButton.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDataForEdit(String ItemName, String ItemAuthor)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    if (context.BorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                    {
                        BorrowAble ToEdit = context.BorrowAbles.Single(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor);
                        TitleTextbox.Text = context.Titles.FirstOrDefault(s => s.TitleID == ToEdit.TitleID).TitleName;
                        ISBNTextbox.Text = ToEdit.ISBN;
                        OverviewTextbox.Text = ToEdit.Overview;
                        PublisherTextbox.Text = context.Publishers.FirstOrDefault(s => s.PublisherName == ToEdit.PublisherName).PublisherName;
                        GenreCombobox.SelectedIndex = GenreCombobox.Items.IndexOf(context.Genres.FirstOrDefault(g => g.GenreName == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).GenreName).GenreName);
                        LanguageCombobox.SelectedIndex = LanguageCombobox.Items.IndexOf(context.Languages.FirstOrDefault(l => l.LanguageName == ToEdit.LanguageName).LanguageName);
                        TypeCombobox.SelectedIndex = TypeCombobox.Items.IndexOf(context.Types.FirstOrDefault(t => t.TypeName == ToEdit.TypeName).TypeName);
                        FormatCombobox.SelectedIndex = FormatCombobox.Items.IndexOf(context.Formats.FirstOrDefault(f => f.FormatName == ToEdit.FormatName).FormatName);
                        CategoryCombobox.SelectedIndex = CategoryCombobox.Items.IndexOf("Borrowable");
                        PriceTextbox.Text = ToEdit.Price.ToString();
                        PublishedDateTimePicker.Value = ToEdit.PublishedDate;
                        AuthorNameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonFirstName;
                        AuthorSurnameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonLastName;
                        AuthorBioTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).Biography;
                        AuthorBirthdayTimePicker.Value = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonDateOfBirth;
                    }
                    else if (context.NonBorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                    {
                        NonBorrowAble ToEdit = context.NonBorrowAbles.Single(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor);
                        TitleTextbox.Text = context.Titles.FirstOrDefault(s => s.TitleID == ToEdit.TitleID).TitleName;
                        ISBNTextbox.Text = ToEdit.ISBN;
                        OverviewTextbox.Text = ToEdit.Overview;
                        PublisherTextbox.Text = context.Publishers.FirstOrDefault(s => s.PublisherName == ToEdit.PublisherName).PublisherName;
                        GenreCombobox.SelectedIndex = GenreCombobox.Items.IndexOf(context.Genres.FirstOrDefault(g => g.GenreName == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).GenreName).GenreName);
                        LanguageCombobox.SelectedIndex = LanguageCombobox.Items.IndexOf(context.Languages.FirstOrDefault(l => l.LanguageName == ToEdit.LanguageName).LanguageName);
                        TypeCombobox.SelectedIndex = TypeCombobox.Items.IndexOf(context.Types.FirstOrDefault(t => t.TypeName == ToEdit.TypeName).TypeName);
                        FormatCombobox.SelectedIndex = FormatCombobox.Items.IndexOf(context.Formats.FirstOrDefault(f => f.FormatName == ToEdit.FormatName).FormatName);
                        CategoryCombobox.SelectedIndex = CategoryCombobox.Items.IndexOf("Borrowable");
                        PriceTextbox.Text = ToEdit.Price.ToString();
                        PublishedDateTimePicker.Value = ToEdit.PublishedDate;
                        AuthorNameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonFirstName;
                        AuthorSurnameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonLastName;
                        AuthorBioTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).Biography;
                        AuthorBirthdayTimePicker.Value = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonDateOfBirth;
                    }
                    TitleTextbox.ReadOnly = true;
                    ISBNTextbox.ReadOnly = true;
                    PublisherTextbox.ReadOnly = true;
                    LanguageCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    TypeCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    FormatCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    PriceTextbox.ReadOnly = true;
                    PublishedDateTimePicker.Enabled = false;
                    AuthorNameTextbox.ReadOnly = true;
                    AuthorSurnameTextbox.ReadOnly = true;
                    AuthorBirthdayTimePicker.Enabled = false;
                    TitleTextbox.BorderStyle = BorderStyle.None;
                    ISBNTextbox.BorderStyle = BorderStyle.None;
                    PublisherTextbox.BorderStyle = BorderStyle.None;
                    PriceTextbox.BorderStyle = BorderStyle.None;
                    AuthorNameTextbox.BorderStyle = BorderStyle.None;
                    AuthorSurnameTextbox.BorderStyle = BorderStyle.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void LoadDataForView(String ItemName, String ItemAuthor)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    if (context.BorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                    {
                        BorrowAble ToEdit = context.BorrowAbles.Single(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor);
                        TitleTextbox.Text = context.Titles.FirstOrDefault(s => s.TitleID == ToEdit.TitleID).TitleName;
                        ISBNTextbox.Text = ToEdit.ISBN;
                        OverviewTextbox.Text = ToEdit.Overview;
                        PublisherTextbox.Text = context.Publishers.FirstOrDefault(s => s.PublisherName == ToEdit.PublisherName).PublisherName;
                        GenreCombobox.SelectedIndex = GenreCombobox.Items.IndexOf(context.Genres.FirstOrDefault(g => g.GenreName == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).GenreName).GenreName);
                        LanguageCombobox.SelectedIndex = LanguageCombobox.Items.IndexOf(context.Languages.FirstOrDefault(l => l.LanguageName == ToEdit.LanguageName).LanguageName);
                        TypeCombobox.SelectedIndex = TypeCombobox.Items.IndexOf(context.Types.FirstOrDefault(t => t.TypeName == ToEdit.TypeName).TypeName);
                        FormatCombobox.SelectedIndex = FormatCombobox.Items.IndexOf(context.Formats.FirstOrDefault(f => f.FormatName == ToEdit.FormatName).FormatName);
                        CategoryCombobox.SelectedIndex = CategoryCombobox.Items.IndexOf("Borrowable");
                        PriceTextbox.Text = ToEdit.Price.ToString();
                        PublishedDateTimePicker.Value = ToEdit.PublishedDate;
                        AuthorNameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonFirstName;
                        AuthorSurnameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonLastName;
                        AuthorBioTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).Biography;
                        AuthorBirthdayTimePicker.Value = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonDateOfBirth;
                        if (ToEdit.isBorrowed)
                        {
                            if (!ToEdit.isReserved)
                            {
                                SendButton.Visible = false;
                                BorrowButton.Visible = false;
                                ReserveButton.Visible = true;
                            }
                        }
                        else if (!ToEdit.isBorrowed)
                        {
                            SendButton.Visible = false;
                            BorrowButton.Visible = true;
                            ReserveButton.Visible = false;
                        }
                        else
                        {
                            SendButton.Visible = true;
                            BorrowButton.Visible = false;
                            ReserveButton.Visible = false;
                            SendButton.Text = "OK";
                        }
                    }
                    else if (context.NonBorrowAbles.Any(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor))
                    {
                        NonBorrowAble ToEdit = context.NonBorrowAbles.Single(s => context.Titles.FirstOrDefault(t => t.TitleID == s.TitleID).TitleName == ItemName && String.Concat(context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonFirstName, " ", context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(ti => ti.TitleID == s.TitleID).AuthorID).PersonLastName) == ItemAuthor);
                        TitleTextbox.Text = context.Titles.FirstOrDefault(s => s.TitleID == ToEdit.TitleID).TitleName;
                        ISBNTextbox.Text = ToEdit.ISBN;
                        OverviewTextbox.Text = ToEdit.Overview;
                        PublisherTextbox.Text = context.Publishers.FirstOrDefault(s => s.PublisherName == ToEdit.PublisherName).PublisherName;
                        GenreCombobox.SelectedIndex = GenreCombobox.Items.IndexOf(context.Genres.FirstOrDefault(g => g.GenreName == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).GenreName).GenreName);
                        LanguageCombobox.SelectedIndex = LanguageCombobox.Items.IndexOf(context.Languages.FirstOrDefault(l => l.LanguageName == ToEdit.LanguageName).LanguageName);
                        TypeCombobox.SelectedIndex = TypeCombobox.Items.IndexOf(context.Types.FirstOrDefault(t => t.TypeName == ToEdit.TypeName).TypeName);
                        FormatCombobox.SelectedIndex = FormatCombobox.Items.IndexOf(context.Formats.FirstOrDefault(f => f.FormatName == ToEdit.FormatName).FormatName);
                        CategoryCombobox.SelectedIndex = CategoryCombobox.Items.IndexOf("Borrowable");
                        PriceTextbox.Text = ToEdit.Price.ToString();
                        PublishedDateTimePicker.Value = ToEdit.PublishedDate;
                        AuthorNameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonFirstName;
                        AuthorSurnameTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonLastName;
                        AuthorBioTextbox.Text = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).Biography;
                        AuthorBirthdayTimePicker.Value = context.Authors.FirstOrDefault(a => a.PersonId == context.Titles.FirstOrDefault(t => t.TitleID == ToEdit.TitleID).AuthorID).PersonDateOfBirth;
                        if (!ToEdit.isReserved)
                            SendButton.Text = "Reserved";
                        else if (ToEdit.isReserved)
                            SendButton.Text = "OK";
                    }
                    TitleTextbox.ReadOnly = true;
                    ISBNTextbox.ReadOnly = true;
                    OverviewTextbox.ReadOnly = true;
                    PublisherTextbox.ReadOnly = true;
                    GenreCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    LanguageCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    TypeCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    FormatCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    CategoryCombobox.DropDownStyle = ComboBoxStyle.Simple;
                    PriceTextbox.ReadOnly = true;
                    PublishedDateTimePicker.Enabled = false;
                    AuthorNameTextbox.ReadOnly = true;
                    AuthorSurnameTextbox.ReadOnly = true;
                    AuthorBioTextbox.ReadOnly = true;
                    AuthorBirthdayTimePicker.Enabled = false;
                    TitleTextbox.BorderStyle = BorderStyle.None;
                    ISBNTextbox.BorderStyle = BorderStyle.None;
                    OverviewTextbox.BorderStyle = BorderStyle.None;
                    PublisherTextbox.BorderStyle = BorderStyle.None;
                    PriceTextbox.BorderStyle = BorderStyle.None;
                    AuthorNameTextbox.BorderStyle = BorderStyle.None;
                    AuthorSurnameTextbox.BorderStyle = BorderStyle.None;
                    AuthorBioTextbox.BorderStyle = BorderStyle.None;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SendButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    Double ItemPrice = 0;
                    if (Double.TryParse(PriceTextbox.Text, out Double PriceTemp))
                        ItemPrice = Double.Parse(PriceTextbox.Text);
                    context.Publishers.AddOrUpdate(s => s.PublisherName, new Publisher(PublisherTextbox.Text));
                    context.Authors.AddOrUpdate(s => new { s.PersonFirstName, s.PersonLastName}, new Author(AuthorNameTextbox.Text, AuthorSurnameTextbox.Text, AuthorBirthdayTimePicker.Value, AuthorBioTextbox.Text));
                    context.SaveChanges();
                    context.Titles.AddOrUpdate(s => new { s.TitleName, s.AuthorID }, new Title(context.Authors.FirstOrDefault(s => s.PersonFirstName == AuthorNameTextbox.Text && s.PersonLastName == AuthorSurnameTextbox.Text && s.PersonDateOfBirth == AuthorBirthdayTimePicker.Value).PersonId, TitleTextbox.Text, context.Genres.FirstOrDefault(s => s.GenreName == GenreCombobox.SelectedItem.ToString()).GenreName));
                    context.SaveChanges();
                    if (CategoryCombobox.SelectedItem.ToString() == "Borrowable")
                        context.BorrowAbles.AddOrUpdate(s => s.ISBN, new BorrowAble(context.Titles.FirstOrDefault(t => t.TitleName == TitleTextbox.Text && t.AuthorID == context.Authors.FirstOrDefault(a => a.PersonFirstName == AuthorNameTextbox.Text && a.PersonLastName == AuthorSurnameTextbox.Text && a.PersonDateOfBirth == AuthorBirthdayTimePicker.Value).PersonId).TitleID, ISBNTextbox.Text, OverviewTextbox.Text, context.Publishers.FirstOrDefault(p => p.PublisherName == PublisherTextbox.Text).PublisherName, PublishedDateTimePicker.Value, context.Languages.FirstOrDefault(l => l.LanguageName == LanguageCombobox.SelectedItem.ToString()).LanguageName, context.Types.FirstOrDefault(t => t.TypeName == TypeCombobox.SelectedItem.ToString()).TypeName, ItemPrice, context.Formats.FirstOrDefault(f => f.FormatName == FormatCombobox.SelectedItem.ToString()).FormatName));
                    else if (CategoryCombobox.SelectedItem.ToString() == "Non-borrowable")
                        context.NonBorrowAbles.AddOrUpdate(s => s.ISBN, new NonBorrowAble(context.Titles.FirstOrDefault(t => t.TitleName == TitleTextbox.Text && t.AuthorID == context.Authors.FirstOrDefault(a => a.PersonFirstName == AuthorNameTextbox.Text && a.PersonLastName == AuthorSurnameTextbox.Text && a.PersonDateOfBirth == AuthorBirthdayTimePicker.Value).PersonId).TitleID, ISBNTextbox.Text, OverviewTextbox.Text, context.Publishers.FirstOrDefault(p => p.PublisherName == PublisherTextbox.Text).PublisherName, PublishedDateTimePicker.Value, context.Languages.FirstOrDefault(l => l.LanguageName == LanguageCombobox.SelectedItem.ToString()).LanguageName, context.Types.FirstOrDefault(t => t.TypeName == TypeCombobox.SelectedItem.ToString()).TypeName, ItemPrice, context.Formats.FirstOrDefault(f => f.FormatName == FormatCombobox.SelectedItem.ToString()).FormatName));
                    context.SaveChanges();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ReserveButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    /*if (CategoryCombobox.SelectedItem.ToString() == "Borrowable")
                        context.ReservationRecords.AddOrUpdate(s => new { s.ItemID, s.PatronID }, new ReservationRecord(context.BorrowAbles.FirstOrDefault(b => b.TitleID == context.Titles.FirstOrDefault(t => t.TitleName == TitleTextbox.Text && t.AuthorID == context.Authors.FirstOrDefault(a => a.PersonFirstName == AuthorNameTextbox.Text && a.PersonLastName == AuthorSurnameTextbox.Text && a.PersonDateOfBirth == AuthorBirthdayTimePicker.Value).PersonId).TitleID).ItemID), );
                    else if (CategoryCombobox.SelectedItem.ToString() == "Non-borrowable")
                        context.NonBorrowAbles.AddOrUpdate(s => s.ISBN, new NonBorrowAble(context.Titles.FirstOrDefault(t => t.TitleName == TitleTextbox.Text && t.AuthorID == context.Authors.FirstOrDefault(a => a.PersonFirstName == AuthorNameTextbox.Text && a.PersonLastName == AuthorSurnameTextbox.Text && a.PersonDateOfBirth == AuthorBirthdayTimePicker.Value).PersonId).TitleID, ISBNTextbox.Text, OverviewTextbox.Text, context.Publishers.FirstOrDefault(p => p.PublisherName == PublisherTextbox.Text).PublisherName, PublishedDateTimePicker.Value, context.Languages.FirstOrDefault(l => l.LanguageName == LanguageCombobox.SelectedItem.ToString()).LanguageName, context.Types.FirstOrDefault(t => t.TypeName == TypeCombobox.SelectedItem.ToString()).TypeName, ItemPrice, context.Formats.FirstOrDefault(f => f.FormatName == FormatCombobox.SelectedItem.ToString()).FormatName));
                    context.SaveChanges();*/
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BorrowButton_Click(object sender, EventArgs e)
        {

        }
    }
}
