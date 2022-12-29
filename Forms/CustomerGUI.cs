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
//
namespace projectMIS
{
    public partial class CustomerGUI : Form
    {
        public CustomerGUI()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers ", con);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable tbl_Customers = new DataTable();
            tbl_Customers.Columns.Add("CompanyName");
            tbl_Customers.Columns.Add("ContactName");
            tbl_Customers.Columns.Add("Address");
            tbl_Customers.Columns.Add("City");
            tbl_Customers.Columns.Add("Region");
            tbl_Customers.Columns.Add("PostalCode");
            tbl_Customers.Columns.Add("Country");
            tbl_Customers.Columns.Add("Phone");
            //ContactName
            DataRow row;
            while (reader.Read())
            {
                row = tbl_Customers.NewRow();
                row["CompanyName"] = reader["CompanyName"];
                row["ContactName"] = reader["ContactName"];
                row["Address"] = reader["Address"];
                row["City"] = reader["City"];
                row["Region"] = reader["Region"];
                row["PostalCode"] = reader["PostalCode"];
                row["Country"] = reader["Country"];
                row["Phone"] = reader["Phone"];
                tbl_Customers.Rows.Add(row);
            }

            reader.Close();
            con.Close();

            SearchGRD.DataSource = tbl_Customers;
        }

        private void SearchBTN_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Customers WHERE CompanyName = @CompanyName", con);
            string company = SearchTXT.Text.ToString();
            cmd.Parameters.AddWithValue("@CompanyName", company);


            SqlDataReader reader2 = cmd.ExecuteReader();
            DataTable tbl_Customers = new DataTable();
            tbl_Customers.Columns.Add("CompanyName");
            tbl_Customers.Columns.Add("ContactName");
            tbl_Customers.Columns.Add("Address");
            tbl_Customers.Columns.Add("City");
            tbl_Customers.Columns.Add("Region");
            tbl_Customers.Columns.Add("PostalCode");
            tbl_Customers.Columns.Add("Country");
            tbl_Customers.Columns.Add("Phone");

            DataRow row;
            while (reader2.Read())
            {
                row = tbl_Customers.NewRow();
                row["CompanyName"] = reader2["CompanyName"];
                row["ContactName"] = reader2["ContactName"];
                row["Address"] = reader2["Address"];
                row["City"] = reader2["City"];
                row["Region"] = reader2["Region"];
                row["PostalCode"] = reader2["PostalCode"];
                row["Country"] = reader2["Country"];
                row["Phone"] = reader2["Phone"];
                tbl_Customers.Rows.Add(row);
            }

            reader2.Close();
            con.Close();

            SearchGRD.DataSource = tbl_Customers;
        }

        private void CustomerGUI_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            setter s = new setter();
            functions f = new functions();
            string companyname = TXT_CompanyName.Text.ToString();
            string ContactName = TXT_ContactName.Text.ToString();
            string Address = TXT_Address.Text.ToString();
            string City = TXT_City.Text.ToString();
            string PostalCode = f.ExtractNumbers(TXT_PostalCode.Text.ToString());
            string Country = TXT_Country.Text.ToString();
            string Phone = f.ExtractNumbers(TXT_Phone.Text.ToString());
            string Region = TXT_Region.Text.ToString();
            s.SETCustomers(companyname,ContactName,Address,City,int.Parse(PostalCode),Country,int.Parse(Phone),Region);
        }
    }
}