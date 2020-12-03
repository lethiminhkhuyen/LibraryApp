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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new LogInForm();
            form2.Closed += (s, args) => this.Close();
            form2.ShowDialog();
            
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new RegisterUserForm();
            form2.Closed += (s, args) => this.Close();
            form2.ShowDialog();
        }
    }
}
