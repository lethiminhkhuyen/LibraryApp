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
using System.IO;
using System.Globalization;

namespace LibraryApp
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
        }
        public void LoadDataForEdit(String UserName, DateTime UserBirthday)
        {
            try
            {
                using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                {
                    FirstNameTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonFirstName;
                    LastnameTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonLastName;
                    BirthdayTimePicker.Value = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).PersonDateOfBirth;
                    EmailTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserEmail;
                    TelTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).TelNumber;
                    PasswordTextbox.Text = context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserPassword;
                    if(!String.IsNullOrEmpty(context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressHousename))
                        HouseNameTextbox.Text = context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressHousename;
                    StreetTextbox.Text = context.Streets.FirstOrDefault(s => s.StreetName == context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(p => p.PersonFirstName == UserName && p.PersonDateOfBirth == UserBirthday).UserAddress).AddressStreetName).StreetName;
                    if (context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressHouseNumber != 0)
                        HouseNumberTextbox.Text = context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressHouseNumber.ToString();
                    if (context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressFlatNumber != 0)
                        HouseNumberTextbox.Text = context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressFlatNumber.ToString();
                    AreacodeTextbox.Text = context.AreaCodes.FirstOrDefault(a => a.AreaCodeCode == context.PostCodes.FirstOrDefault(p => p.PostCodeId == context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressPostCode).FirstCodePart).AreaCodeCode;
                    ArbitrarycodeTextbox.Text = context.ArbitraryCodes.FirstOrDefault(a => a.ArbitraryCodeCode == context.PostCodes.FirstOrDefault(p => p.PostCodeId == context.Addresses.FirstOrDefault(m => m.AddressID == context.Patrons.FirstOrDefault(s => s.PersonFirstName == UserName && s.PersonDateOfBirth == UserBirthday).UserAddress).AddressPostCode).SecondCodePart).ArbitraryCodeCode;
                    FirstNameTextbox.ReadOnly = true;
                    BirthdayTimePicker.Enabled = false;
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
                    int HouseVal = 0, FlatVal = 0;
                    if(int.TryParse(HouseNumberTextbox.Text, out int HouseTemp))
                        HouseVal = int.Parse(HouseNumberTextbox.Text);
                    if (int.TryParse(FlatNumberTextbox.Text, out int FlatTemp))
                        FlatVal = int.Parse(FlatNumberTextbox.Text);
                    context.Streets.AddOrUpdate(s => s.StreetName, new Street(StreetTextbox.Text));
                    context.AreaCodes.AddOrUpdate(s => s.AreaCodeCode, new AreaCode(AreacodeTextbox.Text));
                    context.ArbitraryCodes.AddOrUpdate(s => s.ArbitraryCodeCode, new ArbitraryCode(ArbitrarycodeTextbox.Text));
                    context.SaveChanges();
                    if (!context.PostCodes.Any(s => s.FirstCodePart == AreacodeTextbox.Text && s.SecondCodePart == ArbitrarycodeTextbox.Text))
                        context.PostCodes.AddOrUpdate(s => new {s.FirstCodePart, s.SecondCodePart}, new PostCode(context.AreaCodes.FirstOrDefault(s => s.AreaCodeCode == AreacodeTextbox.Text).AreaCodeCode, context.ArbitraryCodes.FirstOrDefault(s => s.ArbitraryCodeCode == ArbitrarycodeTextbox.Text).ArbitraryCodeCode));
                    context.SaveChanges();
                    if (!String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && !String.IsNullOrEmpty(FlatNumberTextbox.Text))
                    {
                        if (!context.Addresses.Any(s => s.AddressHousename == HouseNameTextbox.Text && s.AddressHouseNumber == HouseVal && s.AddressFlatNumber == FlatVal && s.AddressStreetName == StreetTextbox.Text && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId))
                            context.Addresses.AddOrUpdate(s => new { s.AddressStreetName, s.AddressHouseNumber, s.AddressFlatNumber, s.AddressPostCode },
                                                          new Address(HouseNameTextbox.Text, context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName, HouseVal, FlatVal, context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId));
                    }
                    else if (!String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && String.IsNullOrEmpty(FlatNumberTextbox.Text))
                    {
                        if (!context.Addresses.Any(s => s.AddressHousename == HouseNameTextbox.Text && s.AddressHouseNumber == HouseVal && s.AddressStreetName == StreetTextbox.Text && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId))
                            context.Addresses.AddOrUpdate(s => new { s.AddressStreetName, s.AddressHouseNumber, s.AddressPostCode },
                                                          new Address(HouseNameTextbox.Text, context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName, HouseVal, context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId));
                    }
                    else if (!String.IsNullOrEmpty(HouseNameTextbox.Text) && String.IsNullOrEmpty(HouseNumberTextbox.Text) && String.IsNullOrEmpty(FlatNumberTextbox.Text))
                    {
                        if (!context.Addresses.Any(s => s.AddressHousename == HouseNameTextbox.Text && s.AddressStreetName == StreetTextbox.Text && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId))
                            context.Addresses.AddOrUpdate(s => new {s.AddressHousename, s.AddressStreetName, s.AddressPostCode },
                                                          new Address(HouseNameTextbox.Text, context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName, context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId));
                    }
                    else if (String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && !String.IsNullOrEmpty(FlatNumberTextbox.Text))
                    {
                        if (!context.Addresses.Any(s => s.AddressHouseNumber == HouseVal && s.AddressFlatNumber == FlatVal && s.AddressStreetName == StreetTextbox.Text && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId))
                            context.Addresses.AddOrUpdate(s => new { s.AddressStreetName, s.AddressHouseNumber, s.AddressFlatNumber, s.AddressPostCode },
                                                          new Address(context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName, HouseVal, FlatVal, context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId));
                    }
                    if (String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && String.IsNullOrEmpty(FlatNumberTextbox.Text))
                    {
                        if (!context.Addresses.Any(s => s.AddressHouseNumber == HouseVal && s.AddressStreetName == StreetTextbox.Text && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId))
                            context.Addresses.AddOrUpdate(s => new { s.AddressStreetName, s.AddressHouseNumber, s.AddressPostCode },
                                                          new Address(context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName, HouseVal, context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId));
                    }
                    context.SaveChanges();
                    if (!String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && !String.IsNullOrEmpty(FlatNumberTextbox.Text))
                        context.Patrons.AddOrUpdate(s => new { s.PersonFirstName, s.PersonDateOfBirth }, new Patron(FirstNameTextbox.Text, LastnameTextbox.Text, BirthdayTimePicker.Value, EmailTextbox.Text, TelTextbox.Text, PasswordTextbox.Text, context.Addresses.FirstOrDefault(s => s.AddressHousename == HouseNameTextbox.Text && s.AddressStreetName == context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName && s.AddressHouseNumber == HouseVal && s.AddressFlatNumber == FlatVal && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId).AddressID));
                    else if (!String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && String.IsNullOrEmpty(FlatNumberTextbox.Text))
                        context.Patrons.AddOrUpdate(s => new { s.PersonFirstName, s.PersonDateOfBirth }, new Patron(FirstNameTextbox.Text, LastnameTextbox.Text, BirthdayTimePicker.Value, EmailTextbox.Text, TelTextbox.Text, PasswordTextbox.Text, context.Addresses.FirstOrDefault(s => s.AddressHousename == HouseNameTextbox.Text && s.AddressStreetName == context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName && s.AddressHouseNumber == HouseVal && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId).AddressID));
                    else if (!String.IsNullOrEmpty(HouseNameTextbox.Text) && String.IsNullOrEmpty(HouseNumberTextbox.Text) && String.IsNullOrEmpty(FlatNumberTextbox.Text))
                        context.Patrons.AddOrUpdate(s => new { s.PersonFirstName, s.PersonDateOfBirth }, new Patron(FirstNameTextbox.Text, LastnameTextbox.Text, BirthdayTimePicker.Value, EmailTextbox.Text, TelTextbox.Text, PasswordTextbox.Text, context.Addresses.FirstOrDefault(s => s.AddressHousename == HouseNameTextbox.Text && s.AddressStreetName == context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId).AddressID));
                    else if (String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && !String.IsNullOrEmpty(FlatNumberTextbox.Text))
                        context.Patrons.AddOrUpdate(s => new { s.PersonFirstName, s.PersonDateOfBirth }, new Patron(FirstNameTextbox.Text, LastnameTextbox.Text, BirthdayTimePicker.Value, EmailTextbox.Text, TelTextbox.Text, PasswordTextbox.Text, context.Addresses.FirstOrDefault(s => s.AddressStreetName == context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName && s.AddressHouseNumber == HouseVal && s.AddressFlatNumber == FlatVal && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId).AddressID));
                    else if (String.IsNullOrEmpty(HouseNameTextbox.Text) && !String.IsNullOrEmpty(HouseNumberTextbox.Text) && String.IsNullOrEmpty(FlatNumberTextbox.Text))
                        context.Patrons.AddOrUpdate(s => new { s.PersonFirstName, s.PersonDateOfBirth }, new Patron(FirstNameTextbox.Text, LastnameTextbox.Text, BirthdayTimePicker.Value, EmailTextbox.Text, TelTextbox.Text, PasswordTextbox.Text, context.Addresses.FirstOrDefault(s => s.AddressStreetName == context.Streets.FirstOrDefault(d => d.StreetName == StreetTextbox.Text).StreetName && s.AddressHouseNumber == HouseVal && s.AddressPostCode == context.PostCodes.FirstOrDefault(p => p.FirstCodePart == AreacodeTextbox.Text && p.SecondCodePart == ArbitrarycodeTextbox.Text).PostCodeId).AddressID));
                    context.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
