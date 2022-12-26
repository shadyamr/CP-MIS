using System;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace projectMIS
{

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

}
