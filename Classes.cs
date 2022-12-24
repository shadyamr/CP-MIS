using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using BCrypt.Net;

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

    public class user
    {
        functions f = new functions();

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

                        DialogResult Fire_Employee_Confirmation = MessageBox.Show(" you will kick "+ First_Name + " " +Last_Name + ",Would you like to proceed?", "Confirmation", MessageBoxButtons.YesNo);

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
                    else {
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
                                        string message = Microsoft.VisualBasic.Interaction.InputBox("Why did You demote :"+ FirstNameString + " "+ LastNameString, "Message Box", "Default message");

                                if (message != "")
                                {
                                    Audit(makerid,"demote",id,message);
                                    MessageBox.Show("Demoted");
                                        con.Close();
                                    return;
                                }
                                else {
                                    MessageBox.Show("You Did not write the reason and this may lead into errors and future problems please enter the reason!");
                                    string message2 = Microsoft.VisualBasic.Interaction.InputBox("Why did You demote :" + FirstNameString + " " + LastNameString, "Message Box", "Default message");
                                    Audit(makerid, "demote", id, message2);
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

        public void Feedback(int OrderID, int Employee_Rate, int Products_Rate, int In_Time, string notes, int overall_Rate)
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

        public void insertOrders(int CustomerID, int EmployeeID, DateTime OrderDate, DateTime RequiredDate, DateTime ShippedDate, double Price, string ShipName, string ShipAddress, string ShipCity, string ShipRegion, int ShipPostalCode, string ShipCountry)
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

        public void Audit(string Action_Maker_ID , string Action , string Action_Made_On_ID , string Notes) {
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

        public void All_Audits() { 
        }

        public void Select_Audit() { 
        }

    }
}
