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
using LiveCharts;
using LiveCharts.Wpf;

namespace projectMIS
{
    public partial class Test : Form
    {
        public string imgpath = "";
        public Test()
        {
            InitializeComponent();
            functions f = new functions();
            Action u = new Action();
            getter g = new getter();
            getter getter = new getter();
            DataGrid Data = new DataGrid();
            grd_Employees = Data.Audits_Employee_ON_Employee_DataGrid(grd_Employees);


            getter.Employee employee = getter.GetEmployee(20);

            FirstName_TextBox.Text = employee.FirstName;
            LastName_Text.Text = employee.LastName;
            ID_Text.Text = employee.EmployeeID.ToString();
            Date_ext.Text = employee.HireDate.ToString();
            pictureBox1.ImageLocation = employee.photo;

        }

        public void LoginButton_Click(object sender, EventArgs e)
        {
            Action a = new Action();
            Update u = new Update();
            setter s = new setter();
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
             s.SETEmployee("Mohamed", "Khaled", "Employee", "123456", "01009593303" , imgpath);
            a.demote("20", "19");
            //u.updateEmployees(19,"sakr","Khaled","Title","123456","Mohamed");
            // DateTime currentDate = DateTime.Now;
            //u.insertOrders(1,20, currentDate, currentDate, currentDate, 122.7,"Maro","betna","cairo","North",11814,"Cairo");
            // u.Feedback(20,5,5,1,"nice",5);
        }

        private void grd_Employees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            functions f = new functions();

            DataGridViewCell cell = grd_Employees.CurrentCell;

            object cellValue = cell.Value;

            string cellValueString = cellValue.ToString();

            f.ExtractNumbers(cellValueString);

            MessageBox.Show(f.ExtractNumbers(cellValueString));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.bmp; *.png)|*.jpg;*.jpeg;*.bmp;*.png|All files (*.*)|*.*";

            // Show the OpenFileDialog and check if the user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Get the selected file path and display it in the text box
                //.Text = openFileDialog.FileName;

                MessageBox.Show("true img");
                imgpath = openFileDialog.FileName;
            }
        }

        private void Test_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectDataSet.Salaries' table. You can move, or remove it, as needed.
            this.salariesTableAdapter.Fill(this.projectDataSet.Salaries);

            pieChart.LegendLocation = LegendLocation.Bottom;

        }

private void button2_Click(object sender, EventArgs e)
        {

        }
        Func<ChartPoint, string> label = chartpoint => string.Format("{0} {1:P}", chartpoint.Y, (double)chartpoint.Participation);

        private void button2_Click_1(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            foreach (var obj in projectDataSet.Salaries)
                series.Add(new PieSeries() { Title = obj.EmployeeID.ToString(), Values = new ChartValues<int> { int.Parse(obj.salary.ToString())}, DataLabels = true, LabelPoint = label });
            pieChart.Series = series;
        }

        private void pieChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }

}






