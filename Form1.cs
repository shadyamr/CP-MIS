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
            Action u = new Action();
            grd_Employees = u.FillDataGridView(grd_Employees);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Action u = new Action();
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
            u.demote("20", "1");
            // DateTime currentDate = DateTime.Now;
            //u.insertOrders(1,20, currentDate, currentDate, currentDate, 122.7,"Maro","betna","cairo","North",11814,"Cairo");
            // u.Feedback(20,5,5,1,"nice",5);
        }

        private void grd_Employees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}






