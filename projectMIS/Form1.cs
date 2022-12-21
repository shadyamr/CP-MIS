using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace projectMIS
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
          
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            user u = new user();
            /*
            if (u.Login("01009593303", "Sakr123"))
            {
                MessageBox.Show("true");
            }
            else {
                MessageBox.Show("Invalid username");
            }*/
            /*
              this.Hide();
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                            MessageBox.Show("Good");
            */
            // u.InsertEmployee("Mohamed", "Khaled", "Employee", "123456", "01009593303");
            u.Promote("20");
        }
    }

}
