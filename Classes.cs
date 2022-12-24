using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BCrypt.Net;
using System.Data;

namespace projectMIS
{
    public class functions
    {
        public string RemoveLeadingZeros(string s)
        {
            int i = 0;
            while (i < s.Length && s[i] == '0')
            {
                i++;
            }
            return s.Substring(i);
        }
    }

    public class Action
    {
        functions f = new functions();
        setter s = new setter();

        public bool Login(string username, string password)
        {
            int count = f.RemoveLeadingZeros(username).Length;
            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();

            string hashedPassword = "";
            string query = "";
            if (count == 10)
            {
                query = "SELECT password FROM Employees WHERE MobilePhone = @username";
            }
            else
            {
                query = "SELECT password FROM Employees WHERE EmployeeID = @username";
            }
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@username", username);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hashedPassword = reader["password"].ToString();
                    }
                }
            }

            if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
            {
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }

        public void Promote(string id)
        {
            using (SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT EmployeeStatus FROM Employees WHERE EmployeeID = @username", con);
                cmd.Parameters.AddWithValue("@username", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int level = reader.GetInt32(reader.GetOrdinal("EmployeeStatus"));
                        level++;

                        string query = "UPDATE Employees SET EmployeeStatus = @value WHERE EmployeeID = @id";

                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@value", level);
                            command.Parameters.AddWithValue("@id", id);
                            reader.Close();

                            int i = command.ExecuteNonQuery();

                            if (i != 0)
                            {
                                MessageBox.Show("Promoted");
                            }
                            else
                            {
                                MessageBox.Show("Error");
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("The employee does not exists");
                    }

                }
            }
        }

        public void Fire_Employee(string id)
        {
            using (SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                con.Open();
                SqlCommand cmd_Name = new SqlCommand("Select FirstName , LastName from Employees Where EmployeeID = @username", con);
                cmd_Name.Parameters.AddWithValue("@username", id);
                using (SqlDataReader reader_Names = cmd_Name.ExecuteReader())
                {
                    if (reader_Names.Read())
                    {
                        string First_Name = reader_Names.GetString(0);
                        string Last_Name = reader_Names.GetString(1);
                        reader_Names.Close();

                        DialogResult Fire_Employee_Confirmation = MessageBox.Show(" you will kick " + First_Name + " " + Last_Name + ",Would you like to proceed?", "Confirmation", MessageBoxButtons.YesNo);

                        if (Fire_Employee_Confirmation == DialogResult.Yes)
                        {
                            DateTime currentDate = DateTime.Now;
                            SqlCommand cmd2 = new SqlCommand("UPDATE Employees SET FireDate = @date WHERE EmployeeID = @username", con);
                            cmd2.Parameters.AddWithValue("@date", currentDate);
                            cmd2.Parameters.AddWithValue("@username", id);
                            cmd2.ExecuteNonQuery();
                            int level = 0;

                            string query2 = "UPDATE Employees SET EmployeeStatus = @value WHERE EmployeeID = @id";

                            using (SqlCommand command = new SqlCommand(query2, con))
                            {
                                command.Parameters.AddWithValue("@value", level);
                                command.Parameters.AddWithValue("@id", id);

                                int i = command.ExecuteNonQuery();

                                if (i != 0)
                                {
                                    MessageBox.Show("Fired");
                                    con.Close();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("Error");
                                    con.Close();
                                    return;
                                }
                            }
                        }
                        else if (Fire_Employee_Confirmation == DialogResult.No)
                        {
                            con.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error");
                        con.Close();
                        return;
                    }
                }
            }
        }

        public void demote(string id, string makerid)
        {
            using (SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT EmployeeStatus FROM Employees WHERE EmployeeID = @username", con);
                cmd.Parameters.AddWithValue("@username", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int level = reader.GetInt32(reader.GetOrdinal("EmployeeStatus"));
                        reader.Close();
                        if (level == 1)
                        {// fire employee
                            Fire_Employee(id);
                            con.Close();
                            return;
                        }
                        level--;
                        string query = "UPDATE Employees SET EmployeeStatus = @value WHERE EmployeeID = @id";

                        using (SqlCommand command = new SqlCommand(query, con))
                        {
                            command.Parameters.AddWithValue("@value", level);
                            command.Parameters.AddWithValue("@id", id);

                            int i = command.ExecuteNonQuery();

                            if (i != 0)
                            {
                                SqlCommand cmd3 = new SqlCommand("SELECT FirstName , LastName FROM Employees WHERE EmployeeID = @username", con);
                                cmd3.Parameters.AddWithValue("@username", id);
                                SqlDataReader reader_Names = cmd3.ExecuteReader();
                                string FirstNameString = "";
                                string LastNameString = "";
                                if (reader_Names.Read())
                                {
                                    if (!reader_Names.IsDBNull(reader_Names.GetOrdinal("FirstName")))
                                    {
                                        object FirstName = reader_Names["FirstName"];
                                        FirstNameString = FirstName.ToString();
                                    }

                                    if (!reader_Names.IsDBNull(reader_Names.GetOrdinal("LastName")))
                                    {
                                        object LastName = reader_Names["LastName"];
                                        LastNameString = LastName.ToString();
                                    }
                                }
                                reader_Names.Close();
                                string message = Microsoft.VisualBasic.Interaction.InputBox("Why did You demote :" + FirstNameString + " " + LastNameString, "Message Box", "Default message");

                                if (message != "")
                                {
                                    s.SETAudit(makerid, "demote", id, message);
                                    MessageBox.Show("Demoted");
                                    con.Close();
                                    return;
                                }
                                else
                                {
                                    MessageBox.Show("You Did not write the reason and this may lead into errors and future problems please enter the reason!");
                                    string message2 = Microsoft.VisualBasic.Interaction.InputBox("Why did You demote :" + FirstNameString + " " + LastNameString, "Message Box", "Default message");
                                    s.SETAudit(makerid, "demote", id, message2);
                                    MessageBox.Show("Demoted");
                                    con.Close();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Error");
                                con.Close();
                                return;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("The employee does not exists");
                        con.Close();
                        return;
                    }

                }
            }
        }

       /* public DataGridView All_Audits_GridTable(DataGridView gridTable)
        {

            string firstName1 = "";
            string LastName1 = "";

            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string sql = "SELECT Action_Maker_ID, Action, Action_Made_On_ID, Notes FROM Audits";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Action_Maker_ID, Action, Action_Made_On_ID, Notes FROM Audits", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string actionMakerId = reader["Action_Maker_ID"].ToString();
                        string actionMadeOnId = reader["Action_Made_On_ID"].ToString();

                        string sql2 = "SELECT FirstName , LastName FROM Employees WHERE EmployeeID = @actionMakerId";

                        try
                        {
                            using (SqlCommand command2 = new SqlCommand(sql2, connection))
                            {
                                command2.Parameters.AddWithValue("@actionMakerId", actionMakerId);

                                reader.Close();
                                using (SqlDataReader reader2 = command2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        firstName1 = reader2["FirstName"].ToString();
                                        LastName1 = reader2["LastName"].ToString();

                                        // Exit the loop once you have found the row you are looking for
                                        break;
                                    }
                                }
                            }
                        }
                        catch (SqlException ex)
                        {
                            // Display an error message to the user
                            MessageBox.Show("An error occurred while executing the SQL query: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }

                using (SqlCommand command1 = new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command1))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    gridTable.DataSource = dataTable;
                }
            }

            return gridTable;
        } // still
       */

        public DataGridView All_Audits_GridTable(DataGridView gridTable)
        {
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string sql = "SELECT * FROM Audits";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    gridTable.DataSource = dataTable;
                }
            }

            return gridTable;
        }

        public void Select_Audit()
        {
        }

    }
    public class setter
    {

        public void SETFeedback(int OrderID, int Employee_Rate, int Products_Rate, int In_Time, string notes, int overall_Rate)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO feedback (OrderID, Employee_Rate, Products_Rate, In_Time, notes, overall_Rate) " +
                "VALUES (@OrderID, @EmployeeRate, @Products_Rate, @In_Time, @notes, @overall_Rate)", con);

            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@EmployeeRate", Employee_Rate);
            cmd.Parameters.AddWithValue("@Products_Rate", Products_Rate);
            cmd.Parameters.AddWithValue("@In_Time", In_Time);
            cmd.Parameters.AddWithValue("@notes", notes);
            cmd.Parameters.AddWithValue("@overall_Rate", overall_Rate);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETAudit(string Action_Maker_ID, string Action, string Action_Made_On_ID, string Notes)
        {
            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Audits (Action_Maker_ID, Action, Action_Made_On_ID, Notes, Action_Date) " +
                "VALUES (@Action_Maker_ID, @Action, @Action_Made_On_ID, @Notes, @currentDate)", con);
            DateTime currentDate = DateTime.Now;
            cmd.Parameters.AddWithValue("@Action_Maker_ID", Action_Maker_ID);
            cmd.Parameters.AddWithValue("@Action", Action);
            cmd.Parameters.AddWithValue("@Action_Made_On_ID", Action_Made_On_ID);
            cmd.Parameters.AddWithValue("@Notes", Notes);
            cmd.Parameters.AddWithValue("@currentDate", currentDate);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETEmployee(string firstName, string lastName, string Title, string password, string mobilePhone)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employees (FirstName, LastName, Title, Password, MobilePhone) " +
                "VALUES (@firstName, @lastName, @Title, @password, @mobilePhone)", con);

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@mobilePhone", mobilePhone);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETOrders(int CustomerID, int EmployeeID, DateTime OrderDate, DateTime RequiredDate, DateTime ShippedDate, double Price, string ShipName, string ShipAddress, string ShipCity, string ShipRegion, int ShipPostalCode, string ShipCountry)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Orders (CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, Price, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry) " +
                "VALUES (@CustomerID, @EmployeeID, @OrderDate, @RequiredDate, @ShippedDate, @Price, @ShipName, @ShipAddress, @ShipCity, @ShipRegion, @ShipPostalCode, @ShipCountry)", con);

            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@OrderDate", OrderDate);
            cmd.Parameters.AddWithValue("@ShippedDate", ShippedDate);
            cmd.Parameters.AddWithValue("@Price", Price);
            cmd.Parameters.AddWithValue("@ShipName", ShipName);
            cmd.Parameters.AddWithValue("@ShipAddress", ShipAddress);
            cmd.Parameters.AddWithValue("@ShipRegion", ShipRegion);
            cmd.Parameters.AddWithValue("@ShipPostalCode", ShipPostalCode);
            cmd.Parameters.AddWithValue("@ShipCountry", ShipCountry);
            cmd.Parameters.AddWithValue("@ShipCity", ShipCity);
            cmd.Parameters.AddWithValue("@RequiredDate", RequiredDate);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETSupply(int SupplierID, int SupplyPrice)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Supply (SupplierID, SupplyPrice) " +
                "VALUES (@SupplierID, @SupplyPrice,)", con);

            cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
            cmd.Parameters.AddWithValue("@SupplyPrice", SupplyPrice);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETSuppliers(string CompanyName, string ContactName, string Address, string City, int PostalCode, string Country, int Phone)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Suppliers (CompanyName, ContactName, Address, City, PostalCode, Country, Phone) " +
                "VALUES (@CompanyName, @ContactName, @Address, @City, @PostalCode, @Country, @Phone)", con);

            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@City", City);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETOrderDetails(int OrderID, int ProductID, double UnitPrice, int Quantity, double Discount)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Order Details (OrderID, ProductID, UnitPrice, Quantity, Discount) " +
                "VALUES (@OrderID, @ProductID, @UnitPrice, @Quantity, @Discount)", con);

            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            cmd.Parameters.AddWithValue("@Quantity", Quantity);
            cmd.Parameters.AddWithValue("@Discount", Discount);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETProducts(string ProductName, int SupplierID, int QuantityPerUnit, double UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Products (ProductName, SupplierID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                "VALUES (@ProductName, @SupplierID, @QuantityPerUnit, @UnitPrice, @UnitsInStock, @UnitsOnOrder, @ReorderLevel, @Discontinued)", con);

            cmd.Parameters.AddWithValue("@ProductName", ProductName);
            cmd.Parameters.AddWithValue("@SupplierID", SupplierID);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            cmd.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);
            cmd.Parameters.AddWithValue("@ReorderLevel", ReorderLevel);
            cmd.Parameters.AddWithValue("@Discontinued", Discontinued);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETProductStats(int ProductID, int UnitsInStock, int QuantityPerUnit, int UnitsOnOrder, int UnitsSold)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ProductStats (ProductID, UnitsInStock, QuantityPerUnit, UnitsOnOrder, UnitsSold) " +
                "VALUES (@ProductID, @UnitsInStock, @QuantityPerUnit, @UnitsOnOrder, @UnitsSold)", con);

            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@UnitsInStock", UnitsInStock);
            cmd.Parameters.AddWithValue("@UnitsSold", UnitsSold);
            cmd.Parameters.AddWithValue("@QuantityPerUnit", QuantityPerUnit);
            cmd.Parameters.AddWithValue("@UnitsOnOrder", UnitsOnOrder);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETproductPrice(int ProductID, int UnitPrice, int UnitPriceOrder)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO productPrice (ProductID, UnitPrice, UnitPriceOrder) " +
                "VALUES (@ProductID, @UnitPrice, @UnitPriceOrder)", con);

            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            cmd.Parameters.AddWithValue("@UnitPriceOrder", UnitPriceOrder);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETproducts_ordered(int OrderID, int ProductID, int quantity_ordered)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO products_ordered (OrderID, ProductID, quantity_ordered) " +
                "VALUES (@OrderID, @ProductID, @UnitPriceOrder)", con);

            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@quantity_ordered", quantity_ordered);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETrevisit(int OrderID, int CustomerID, int EmployeeID, double revisit_time, string revisit_reason, DateTime revisit_date)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO revisit (OrderID, CustomerID, quantity_ordered, revisit_time, revisit_reason, revisit_date) " +
                "VALUES (@OrderID, @ProductID, @UnitPriceOrder, @revisit_time, @revisit_reason, @revisit_date)", con);

            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@revisit_time", revisit_time);
            cmd.Parameters.AddWithValue("@revisit_reason", revisit_reason);
            cmd.Parameters.AddWithValue("@revisit_date", revisit_date);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETCustomers(string CompanyName, string ContactName, string Address, string City, int PostalCode, string Country, int Phone, string Region, string ContactTitle)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customers (CompanyName, ContactName, Address, City, PostalCode, Country, Phone, Region, ContactTitle) " +
                "VALUES (@CompanyName, @ContactName, @Address, @City, @PostalCode, @Country, @Phone, @Region, @ContactTitle)", con);

            cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
            cmd.Parameters.AddWithValue("@ContactName", ContactName);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@PostalCode", PostalCode);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@Phone", Phone);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Region", Region);
            cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETorder_details(int order_id, bool order_status, int employee_id, int visit_time, int end_of_visit_time, string notes, string feedback)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO order_details (order_id, order_status, employee_id, visit_time, end_of_visit_time, notes, feedback) " +
                "VALUES (@order_id, @order_status, @employee_id, @visit_time, @end_of_visit_time, @notes, @feedback)", con);

            cmd.Parameters.AddWithValue("@order_id", order_id);
            cmd.Parameters.AddWithValue("@order_status", order_status);
            cmd.Parameters.AddWithValue("@employee_id", employee_id);
            cmd.Parameters.AddWithValue("@visit_time", visit_time);
            cmd.Parameters.AddWithValue("@end_of_visit_time", end_of_visit_time);
            cmd.Parameters.AddWithValue("@notes", notes);
            cmd.Parameters.AddWithValue("@feedback", feedback);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETSalary_Change(int EmployeeID, double Salary_Change, string notes)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Salary_Change (EmployeeID, Salary_Change, notes) " +
                "VALUES (@EmployeeID, @Salary_Change, @notes)", con);

            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@Salary_Change", Salary_Change);
            cmd.Parameters.AddWithValue("@notes", notes);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }

        public void SETSalaries(int EmployeeID, double salary)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Salaries (EmployeeID, salary) " +
                "VALUES (@EmployeeID, @salary)", con);

            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@salary", salary);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }


    }
}
