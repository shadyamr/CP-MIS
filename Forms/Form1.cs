using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using FontAwesome.Sharp;

namespace projectMIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            int title = l.title;
            setter s = new setter();
            string CompanyName = TXT_NAME.Text.ToString();
            string ContactName = TXT_Owner.Text.ToString();
            string Address = TXT_Address.Text.ToString();
            string Phone = TXT_Phone.Text.ToString();
            string Budget = TXT_BUDGET.Text.ToString();
            string Email = TXT_EMAIL.Text.ToString();
            string notes = TXT_Notes.Text.ToString();
            s.SETOrders(1, 19, CompanyName, ContactName, Phone, Address, int.Parse(Budget), Email, notes);
        }
    }
}
