using System;
using System.Windows.Forms;

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

    }

}






