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
    public partial class LogInForm : Form
    {
        String wrongDetails = "Something is wrong, please check your details and log in again.";
        String noLogin = "Please enter your user login.";
        String noPassword = "Please eneter your password.";
        public LogInForm()
        {
            InitializeComponent();
            warningText.Visible = false;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UserLoginTextBox.Text) && !String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                warningText.Text = noLogin;
                warningText.Visible = true;
            }
            else if (!String.IsNullOrEmpty(UserLoginTextBox.Text) && String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                warningText.Text = noPassword;
                warningText.Visible = true;
            }
            else if (!String.IsNullOrEmpty(UserLoginTextBox.Text) && !String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                try
                {
                    using (LibraryApp.Models.LibraryDB context = new LibraryDB())
                    {
                        if(!context.Patrons.Any(s => s.UserLogin == UserLoginTextBox.Text && s.UserPassword == PasswordTextBox.Text))
                        {
                            if (!context.Librarians.Any(s => s.UserLogin == UserLoginTextBox.Text && s.UserPassword == PasswordTextBox.Text))
                            {
                                warningText.Text = wrongDetails;
                                warningText.Visible = true;
                            }
                            else
                            {
                                this.Hide();
                                var form2 = new LibrarianView(UserLoginTextBox.Text, PasswordTextBox.Text);
                                form2.Closed += (s, args) => this.Close();
                                form2.Size = new Size(1600, 1000);
                                form2.ShowDialog();
                            }
                        }
                        else
                        {
                            this.Hide();
                            var form2 = new UserView(UserLoginTextBox.Text, PasswordTextBox.Text);
                            form2.Closed += (s, args) => this.Close();
                            form2.Size = new Size(1600, 1000);
                            form2.ShowDialog();
                        }
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
