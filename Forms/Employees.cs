using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static projectMIS.getter;

namespace projectMIS
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            functions f = new functions();
            Action u = new Action();
            getter g = new getter();
            getter getter = new getter();
            DataGrid Data = new DataGrid();
            dataGridView1 = Data.Employees_DataGrid(dataGridView1);
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            functions f = new functions();

            DataGridViewCell cell = dataGridView1.CurrentCell;

            object cellValue = cell.Value;

            string cellValueString = cellValue.ToString();

            f.ExtractNumbers(cellValueString);

            MessageBox.Show(f.ExtractNumbers(cellValueString));
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            DataGrid Data = new DataGrid();
            dataGridView1 = Data.Employees_BY_ID_DataGrid(dataGridView1, int.Parse(SearchTXT.Text));
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string FirstName = TXT_FirstName.Text.ToString();
            string LastName = TXT_LastName.Text.ToString();
            string password = TXT_password.Text.ToString();
            string MobilePhone = TXT_MobilePhone.Text.ToString();
            string notes = TXT_Notes.Text.ToString();
            setter s = new setter();
            s.SETEmployee(FirstName, LastName, password, MobilePhone, notes);
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
