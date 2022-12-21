using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
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

        public void InsertEmployee(string firstName, string lastName, string Title, string password, string mobilePhone)
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

                SqlCommand cmd = new SqlCommand("SELECT Employment_Level FROM Employees WHERE EmployeeID = @username", con);
                cmd.Parameters.AddWithValue("@username", id);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int level = reader.GetInt32(reader.GetOrdinal("Employment_Level"));
                        level++;

                        string query = "UPDATE Employees SET Employment_Level = @value WHERE EmployeeID = @id";

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
    }
}
