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
    }
}
