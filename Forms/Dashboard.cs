using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            functions f = new functions();
            int sponsors = f.SponsoresSum();
            int salaries = f.SalariesSum();

            int countorders = f.CountOrders();
            LabelOrders.Text = countorders.ToString();
            int countDoneorders = f.CountDoneOrders();
            LabelCompletedOrders.Text = countDoneorders.ToString();
            pieChart1.Series.Add(new PieSeries
            {
                Title = "Sponsors",
                Values = new ChartValues<double> { sponsors },
                StrokeThickness = 2
            });
            pieChart1.Series.Add(new PieSeries
            {
                Title = "Salaries",
                Values = new ChartValues<double> { salaries },
                StrokeThickness = 2
            });
            pieChart1.DataClick += PieChart_DataClick;

            this.Controls.Add(pieChart1);
        }

        private void PieChart_DataClick(object sender, ChartPoint chartPoint)
        {
            MessageBox.Show($"You clicked on {chartPoint.SeriesView.Title}, which has a value of {chartPoint.Y}");
        }


        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Salaries' table. You can move, or remove it, as needed.
            this.salariesTableAdapter.Fill(this.projectDataSet.Salaries);

        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
