using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectMIS
{
    
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

    }
