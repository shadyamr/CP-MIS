using System;
using System.IO;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace projectMIS
{
    public class setter
    {
        public SqlConnection con = new SqlConnection("Data Source=MOHAMED-LAPTOP\\SQLEXPRESS;Initial Catalog=project;Integrated Security=True");
        public void SETFeedback(int OrderID, int Employee_Rate, int Products_Rate, int In_Time, string notes, int overall_Rate)
        {
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

        public void SETEmployee(string firstName, string lastName, string password, string mobilePhone, string filePath)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            con.Open();

            byte[] imageData = File.ReadAllBytes(filePath);

            SqlCommand cmd = new SqlCommand("INSERT INTO Employees (FirstName, LastName, Title, Password, MobilePhone , photo) " +
                "VALUES (@firstName, @lastName, @Title, @password, @mobilePhone ,@photo)", con);

            cmd.Parameters.AddWithValue("@firstName", firstName);
            cmd.Parameters.AddWithValue("@lastName", lastName);
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
