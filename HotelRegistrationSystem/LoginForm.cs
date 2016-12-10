using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelRegistrationSystem
{
    public partial class LoginForm : Form
    {
        private HotelSystemDbContext dbContext;
        private string username;
        private string password;
        
        public LoginForm()
        {
            //init the EF dbContext
            this.dbContext = new HotelSystemDbContext();

            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            this.username = this.usernameTextBox.Text;
            this.password = this.passwordTextBox.Text;

            var user = this.dbContext.Operators
                .SingleOrDefault(o => o.Username == this.username && o.Password == this.password);

            if (user == null)
            {
                //if the user is not found, throw error message box
                MessageBox.Show("Потребителят не е намерен.", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var mainForm = new MainForm();
                mainForm.Show();

                //Close the form after init the main form
                this.Hide();
            }
        }

        //TODO: validate username
        private void usernameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        //TODO: validate password
        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
