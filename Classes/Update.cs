using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectMIS
{
    public class Update
    {

        public void updateEmployees(int EmployeeID, string firstName, string lastName, string Title, string password, string mobilePhone)
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
}
