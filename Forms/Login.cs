using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectMIS
{
    public partial class Login : Form
    {
        public int title = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void Loginbtn_Click(object sender, EventArgs e)
        {
            functions f = new functions();
            Action a = new Action();

            int username = int.Parse(txtUsername.Text);
            string password = TXTPassword.Text;

            int title = f.SelectTitle(username);

            


            bool loginstatus = a.Login(username.ToString(), password);
            if (loginstatus)
            {
                if (title != 1)
                {
                    Form1 form = new Form1();
                  
                    form.Show();
                }
                else {
                    AdminCP admin = new AdminCP();
                    
                    admin.Show();
                }
            }
            else
            {
                MessageBox.Show("Wrong credentials");
            }
        }
    }
}
