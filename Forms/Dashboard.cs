using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Drawing;
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

            int countemployees = f.countemployees();
            employeestxt.Text = countemployees.ToString();
            int firedemployees = f.firedcount();
            firedtxt.Text = firedemployees.ToString();

            int countorders = f.CountOrders();
            LabelOrders.Text = countorders.ToString();
            int countDoneorders = f.CountDoneOrders();
            LabelCompletedOrders.Text = countDoneorders.ToString();

            int countproducts = f.countproducts();
            Produc.Text = countproducts.ToString();
            int countdisproducts = f.countdiscproducts();
            unavail.Text = countdisproducts.ToString();

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

            gauge1.From = 0;
            gauge1.To = 100;
            gauge1.Value = countDoneorders;
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

        private void Products_Click(object sender, EventArgs e)
        {

        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
