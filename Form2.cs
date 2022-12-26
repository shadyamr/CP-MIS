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
using System.Windows.Forms.DataVisualization.Charting;



namespace projectMIS
{
    public partial class AdminCP : Form
    {
        public AdminCP()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AdminCP_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Audits' table. You can move, or remove it, as needed.
            this.auditsTableAdapter.Fill(this.projectDataSet.Audits);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
