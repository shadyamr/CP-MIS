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
    public partial class CustomerGUI : Form
    {
        public CustomerGUI()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=MLAB-011-IBM09;Initial Catalog=Northwind;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE CompanyName = @CompanyName", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable SearchEMP = new DataTable();
            SearchEMP.Columns.Add("CompanyName");

            DataRow row;
            while (reader.Read())
            {
                row = SearchEMP.NewRow();
                row["CompanyName"] = reader["CompanyName"];
                SearchEMP.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            SearchGRD.DataSource = SearchEMP;
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MLAB-011-IBM09;Initial Catalog=Northwind;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Employees WHERE CompanyName = @CompanyName", con);
            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);


            SqlDataReader reader2 = cmd.ExecuteReader();
            DataTable SearchEMP = new DataTable();
            SearchEMP.Columns.Add("CompanyName");

            DataRow row;
            while (reader2.Read())
            {
                row = SearchEMP.NewRow();
                row["CompanyName"] = reader2["CompanyName"];
                SearchEMP.Rows.Add(row);
            }

            reader2.Close();
            con.Close();

            SearchGRD.DataSource = SearchEMP;
        }
    }
}

/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace lab9
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(
    "Data Source=MLAB-011-IBM09;Initial Catalog=Northwind;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select LastName,FirstName from Employees", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tbl_Employees = new DataTable();
            tbl_Employees.Columns.Add("FirstName");
            tbl_Employees.Columns.Add("LastName");

            DataRow row;
            while (reader.Read())
            {
                row = tbl_Employees.NewRow();
                row["FirstName"] = reader["FirstName"];
                row["LastName"] = reader["LastName"];
                tbl_Employees.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            grd_Employees.DataSource = tbl_Employees;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(
   "Data Source=MLAB-011-IBM09;Initial Catalog=Northwind;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select FirstName, LastName from Employees where City = @cityparam", con);
            cmd.Parameters.AddWithValue("@cityparam", City.Text);


            SqlDataReader reader2 = cmd.ExecuteReader();
            DataTable tbl_Employees = new DataTable();
            tbl_Employees.Columns.Add("FirstName");
            tbl_Employees.Columns.Add("LastName");

            DataRow row;
            while (reader2.Read())
            {
                row = tbl_Employees.NewRow();
                row["FirstName"] = reader2["FirstName"];
                row["LastName"] = reader2["LastName"];
                tbl_Employees.Rows.Add(row);
            }

            reader2.Close();
            con.Close();

            grd_Employees.DataSource = tbl_Employees;
        }

    }
}*/
