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

    

    public class Update
    {

        public void updateEmployees(int EmployeeID , string firstName, string lastName, string Title, string password, string mobilePhone)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Employees SET firstName = @firstName, lastName = @lastName, Title = @Title, password = @password, mobilePhone = @mobilePhone WHERE EmployeeID = @EmployeeID", con);

            cmd.Parameters.AddWithValue("@EmployeeID", EmployeeID);
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
