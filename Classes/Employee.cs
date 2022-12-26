using System;
using System.Data.SqlClient;

namespace projectMIS
{
        public class Employee
        {
            private readonly string _connectionString = "Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True";
            public int EmployeeID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MobilePhone { get; set; }
            public DateTime HireDate { get; set; }
            public DateTime FireDate { get; set; }
            public string photo { get; set; }


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
