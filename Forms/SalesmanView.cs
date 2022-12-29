using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectMIS.Forms
{
    public partial class SalesmanView : Form
    {
        public SalesmanView()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            setter s = new setter();
            string CompanyName = TXT_NAME.Text.ToString();
            string ContactName = TXT_Owner.Text.ToString();
            string Address = TXT_Address.Text.ToString();
            string Phone = TXT_Phone.Text.ToString();
            string Budget = TXT_BUDGET.Text.ToString();
            string Email = TXT_EMAIL.Text.ToString();
            string notes = TXT_Notes.Text.ToString();
            s.SETOrders(1, 19, CompanyName, ContactName, Phone, Address , int.Parse(Budget) , Email, notes);
        }

    }
}
