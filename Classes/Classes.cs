/*
-----------------------------------------------------------------------------------------------------
*** Misr International University            | Faculty of Computer Science
***    | 
*** Developed on //22 by:                | Mohamed Khaled & Abdulrahman Sakr & Shady Amr & mostafa saleh.
-----------------------------------------------------------------------------------------------------
*/
using System;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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

        public int SalariesSum()
        {
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT SUM(salary) as TotalSalaries FROM Salaries", con);
                object result = cmd.ExecuteScalar();
                int sum = Convert.ToInt32(result);

                return sum;
            }
        }

        public int SponsoresSum()
        {
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT SUM(price * Duration_In_Days) as TotalPrice FROM Sponsors", con);
                object result = cmd.ExecuteScalar();
                int sum = Convert.ToInt32(result);

                return sum;
            }
        }

        public int CountOrders()
        {
            int count = 0;
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        public int CountDoneOrders()
        {
            int count = 0;
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Order_Details WHERE order_status > 0";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    count = (int)command.ExecuteScalar();
                }
            }

            return count;
        }

        public string Title(string status) {
            int title = int.Parse(status);

            if (title == 0)
            {
                return "Ex Employee";
            }
            else if (title == 1)
            {
                return "Employee Level 1";
            }
            else if (title == 2)
            {
                return "Employee Level 2";
            }
            else if (title == 3)
            {
                return "Employee Level 3";
            }
            else if (title == 4)
            {
                return "Employee Level 4";
            }
            else {
                return "undefined";
            }
        }

        public string ExtractNumbers(string input)
        {
            var regex = new Regex(@"\d+");
            var match = regex.Match(input);

            return match.Value;
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

        
    }

    public class DataGrid
    {
        functions f = new functions();
        public DataGridView Audits_Employee_ON_Employee_DataGrid(DataGridView gridTable)
        {
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string sql = @"SELECT e1.FirstName AS MakerFirstName, e1.LastName AS MakerLastName,
                         e2.FirstName AS MadeOnFirstName, e2.LastName AS MadeOnLastName,
                         a.Action_Maker_ID, a.Action, a.Action_Made_On_ID, a.Notes
                         FROM Employees e1
                         JOIN Audits a ON e1.EmployeeID = a.Action_Maker_ID
                         JOIN Employees e2 ON e2.EmployeeID = a.Action_Made_On_ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                    column1.HeaderText = "Action Maker";
                    column1.Name = "ActionMakerID";

                    DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
                    column2.HeaderText = "Action";
                    column2.Name = "Action";

                    DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
                    column3.HeaderText = "Action Made On";
                    column3.Name = "ActionMadeOnID";

                    DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
                    column4.HeaderText = "Notes";
                    column4.Name = "Notes";

                    gridTable.Columns.Add(column1);
                    gridTable.Columns.Add(column2);
                    gridTable.Columns.Add(column3);
                    gridTable.Columns.Add(column4);

                    while (reader.Read())
                    {
                        String MakerFirst = reader["MakerFirstName"].ToString();
                        String MakerSecond = reader["MakerLastName"].ToString();
                        String MaderFirst = reader["MadeOnFirstName"].ToString();
                        String MaderSecond = reader["MadeOnLastName"].ToString();

                        gridTable.Rows.Add(reader["Action_Maker_ID"]+ " " + MakerFirst + " " + MakerSecond, reader["Action"]
                                       , reader["Action_Made_On_ID"] + " " + MaderFirst + " " + MaderSecond, reader["Notes"]);
                    }
                }
            }

            return gridTable;
        }

        public DataGridView Employees_DataGrid(DataGridView gridTable)
        {
            string connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            string sql = "SELECT EmployeeID, FirstName, LastName, MobilePhone, EmployeeStatus FROM Employees Where EmployeeStatus >= 1";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
                    column1.HeaderText = "Employee ID";
                    column1.Name = "EmployeeID";

                    DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
                    column2.HeaderText = "Name";
                    column2.Name = "Name";

                    DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
                    column3.HeaderText = "MobilePhone";
                    column3.Name = "MobilePhone";

                    DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
                    column4.HeaderText = "Employee Status";
                    column4.Name = "EmployeeStatus";

                    gridTable.Columns.Add(column1);
                    gridTable.Columns.Add(column2);
                    gridTable.Columns.Add(column3);
                    gridTable.Columns.Add(column4);

                    while (reader.Read())
                    {
                        string LastName = reader["LastName"].ToString();
                        string Title = f.Title(reader["EmployeeStatus"].ToString());
                        gridTable.Rows.Add(reader["EmployeeID"], reader["FirstName"] + " " + LastName, reader["MobilePhone"], Title);
                    }
                }
            }

            return gridTable;
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

        public void SETEmployee(string firstName, string lastName, string Title, string password, string mobilePhone, string filePath)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();

            byte[] imageData = File.ReadAllBytes(filePath);

            SqlCommand cmd = new SqlCommand("INSERT INTO Employees (FirstName, LastName, Title, Password, MobilePhone , photo) " +
                "VALUES (@firstName, @lastName, @Title, @password, @mobilePhone ,@photo)", con);

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@password", hashedPassword);
            cmd.Parameters.AddWithValue("@mobilePhone", mobilePhone);
            cmd.Parameters.AddWithValue("@photo", filePath);

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

        public void SETrevisit(int OrderID, int CustomerID, int EmployeeID, double revisit_time, string revisit_reason, DateTime revisit_date) // updated
        {
            int status = 0;
            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO revisit (OrderID, CustomerID, quantity_ordered, revisit_time, revisit_reason, revisit_date , status) " +
                "VALUES (@OrderID, @ProductID, @UnitPriceOrder, @revisit_time, @revisit_reason, @revisit_date , @status)", con);

            cmd.Parameters.AddWithValue("@OrderID", OrderID);
            cmd.Parameters.AddWithValue("@CustomerID", CustomerID);
            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
            cmd.Parameters.AddWithValue("@revisit_time", revisit_time);
            cmd.Parameters.AddWithValue("@revisit_reason", revisit_reason);
            cmd.Parameters.AddWithValue("@revisit_date", revisit_date);
            cmd.Parameters.AddWithValue("@status", status);

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

    
    public class Update
    {





        public void updateSuppliers(int SupplierID, string CompanyName, string ContactName, string Address, string City, int PostalCode, string Country, int Phone)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Suppliers SET CompanyName = @CompanyName, ContactName = @ContactName, Address = @Address, City = @City, PostalCode = @PostalCode, Country = @Country, Phone = @Phone,  WHERE SupplierID = @SupplierID)", con);

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
        
        public void updateOrderDetails(int OrderID, int ProductID, double UnitPrice, int Quantity, double Discount)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Order Details SET ProductID = @ProductID, UnitPrice = @UnitPrice, Quantity = @Quantity, Discount = @Discount WHERE OrderID = @OrderID)", con);

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
        
        public void updateProducts(int ProductID, string ProductName, int SupplierID, int QuantityPerUnit, double UnitPrice, int UnitsInStock, int UnitsOnOrder, int ReorderLevel, bool Discontinued)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Products SET ProductName = @ProductName, SupplierID = @SupplierID, QuantityPerUnit = @QuantityPerUnit, UnitPrice = @UnitPrice, UnitsInStock = @UnitsInStock, UnitsOnOrder = @UnitsOnOrder, ReorderLevel = @ReorderLevel, Discontinued = @Discontinued,  WHERE ProductID = @ProductID)", con);

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
        
        public void updateproductPrice(int ProductID, int UnitPrice, int UnitPriceOrder)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE productPrice SET UnitPrice = @UnitPrice, UnitPriceOrders = @UnitPriceOrders WHERE ProductID = @ProductID)", con);

            cmd.Parameters.AddWithValue("@UnitPrice", UnitPrice);
            cmd.Parameters.AddWithValue("@UnitPriceOrder", UnitPriceOrder);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }
        
        public void updateProductStats(int ProductID, int UnitsInStock, int QuantityPerUnit, int UnitsOnOrder, int UnitsSold)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE ProductStats SET UnitsInStock = @UnitsInStock, QuantityPerUnit = @QuantityPerUnit, UnitsOnOrder = @UnitsOnOrder, UnitsSold = @UnitsSold, WHERE ProductID= @ProductID)", con);

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
        
        public void updateproducts_ordered(int OrderID, int ProductID, int quantity_ordered)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE product_ordered SET ProductID = @ProductID, quantity_ordered = @quantity_ordered WHERE OrderID = @OrderID)", con);

            cmd.Parameters.AddWithValue("@ProductID", ProductID);
            cmd.Parameters.AddWithValue("@quantity_ordered", quantity_ordered);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }
        
        public void updaterevisit(int OrderID, int CustomerID, int EmployeeID, double revisit_time, string revisit_reason, DateTime revisit_date)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE revisit SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, revisit_time = @revisit_time, revisit_reason = @revisit_reason, revisit_date = @revisit_date,  WHERE OrderID = @OrderID)", con);

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
        
        public void updateEmployees(int EmployeeID, string firstName, string lastName, string Title, string password, string mobilePhone)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Employees SET firstName = @firstName, lastName = @lastName, Title = @Title, password = @password, mobilePhone = @mobilePhone WHERE EmployeeID = @EmployeeID)", con);

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
        
        public void updateSalaries(int EmployeeID, double Salary_Change)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Salaries SET salary = @salary WHERE EmployeeID = @EmployeeID)", con);

            cmd.Parameters.AddWithValue("@Salary_Change", Salary_Change);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }
        public void updateSalary_Change(int EmployeeID, double Salary_Change, string notes)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Salary_Change SET Salary_Change = @Salary_Change, notes = @notes WHERE EmployeeID = @EmployeeID)", con);

            cmd.Parameters.AddWithValue("@Salary_Change", Salary_Change);
            cmd.Parameters.AddWithValue("@notes", notes);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }
        
        public void updateorder_details(int order_id, bool order_status, int employee_id, int visit_time, int end_of_visit_time, string notes, string feedback)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE order_details SET order_status = @order_status, employee_id = @employee_id, visit_time = @visit_time, end_of_visit_time = @end_of_visit_time, notes = @notes, feedback = @feedback,  WHERE order_id = @order_id)", con);

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
        
        public void updateCustomers(int CustomerID, string CompanyName, string ContactName, string Address, string City, int PostalCode, string Country, int Phone, string Region, string ContactTitle)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Customers SET CompanyName = @CompanyName, ContactName = @ContactName, Address = @Address, City = @City, PostalCode = @PostalCode, Country = @Country, Phone = @Phone, Region = @Region, ContactTitle = @ContactTitle,  WHERE CustomerID = @CustomerID)", con);

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

        public void updateSupplyProduct(int SupplyID, int productID)
        {

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE SupplyProduct SET productID = @productID WHERE SupplyID = @SupplyID)", con);

            cmd.Parameters.AddWithValue("@productID", productID);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i != 0)
            {
                MessageBox.Show("Data Saved");
            }
        }



    }

    public class getter 
    {
        public class Employee
        {
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MobilePhone { get; set; }
            public DateTime HireDate { get; set; }
            public DateTime FireDate { get; set; }
            public string photo { get; set; }


        }

        private readonly string _connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";

        public Employee GetEmployee(int employeeId)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Employees WHERE EmployeeID = @employeeId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employee
                            {
                                EmployeeID = (int)reader["EmployeeID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                MobilePhone = (string)reader["MobilePhone"],
                                HireDate = (DateTime)reader["HireDate"],
                                photo = (string)reader["Photo"]
                            };
                        }
                    }
                }
            }

            return employee;
        }

        public Employee GetFiredEmployee(int employeeId)
        {
            Employee employee = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Employees WHERE EmployeeID = @employeeId";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee = new Employee
                            {
                                EmployeeID = (int)reader["EmployeeID"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                MobilePhone = (string)reader["MobilePhone"],
                                HireDate = (DateTime)reader["HireDate"],
                                FireDate = (DateTime)reader["FireDate"],
                                photo = (string)reader["Photo"]
                            };
                        }
                    }
                }
            }

            return employee;
        }
    }

    }
