using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace lab_61_raw_sql
{
    class Program
    {
        static List<Customer> _customers;

        static void Main(string[] args)
        {
            // add new customer
            try
            {
                Console.WriteLine($"{AddCustomer("Blog1", "Company1", "JoeBloggs1")} rows added");
            }
            catch(Exception)
            {
                Console.WriteLine("Customer already in database");
            }
            // update customer
            Console.WriteLine($"{UpdateCustomer("Blog1", "Company2", "JoeBloggs2")} rows updated");

            // delete customer
            Console.WriteLine($"{DeleteCustomer("Blog1")} entries deleted.");


            // read customers
            Console.WriteLine();
            PrintCustomers(FindCustomers());

        }

        // C
        public static int AddCustomer(string CustomerID, string CompanyName, string ContactName)
        {
            int ret;

            using (var connection = new SqlConnection(@"Data Source=localhost;
                    Initial Catalog=Northwind;Persist Security Info=True;
                    User ID=SA; Password=Passw0rd2018"))
            {
                connection.Open();

                string SQLInsert = "insert into Customers " +
                    "(CustomerID,CompanyName,ContactName) " +
                    $"values ('{CustomerID}','{CompanyName}', '{ContactName}')";

                using (var command = new SqlCommand(SQLInsert, connection))
                {
                    ret = command.ExecuteNonQuery();
                }
            }
            return ret;
        }
        // R
        public static List<Customer> FindCustomers(int n = 10)
        {
            var ret = new List<Customer>();
            using (var connection = new SqlConnection(@"Data Source=localhost;
                    Initial Catalog=Northwind;Persist Security Info=True;
                    User ID=SA; Password=Passw0rd2018"))
            {
                connection.Open();
                string SQLSelect = $"select top {n} * from Customers";
                using (var command = new SqlCommand(SQLSelect, connection))
                {
                    SqlDataReader sqlreader = command.ExecuteReader();

                    while (sqlreader.Read())
                    {
                        string CustomerID = sqlreader["CustomerID"].ToString();
                        string CompanyName = sqlreader["CompanyName"].ToString();
                        string ContactName = sqlreader["ContactName"].ToString();

                        ret.Add(new Customer(CustomerID, CompanyName, ContactName));
                    }
                }
            }
            return ret;
        }
        // U
        public static int UpdateCustomer(string CustomerID, string CompanyName, string ContactName)
        {
            int ret;
            using (var connection = new SqlConnection(@"Data Source=localhost;
                    Initial Catalog=Northwind;Persist Security Info=True;
                    User ID=SA; Password=Passw0rd2018"))
            {
                connection.Open();
                string SQLUpdate = $"update Customers " +
                    $"set CompanyName='{CompanyName}', ContactName='{ContactName}' " +
                    $"where CustomerID='{CustomerID}'";
                using (var command = new SqlCommand(SQLUpdate, connection))
                {
                    ret = command.ExecuteNonQuery();
                }
            }
            return ret;
        }
        // D
        public static int DeleteCustomer(string CustomerID)
        {
            int ret;
            using (var connection = new SqlConnection(@"Data Source=localhost;
                    Initial Catalog=Northwind;Persist Security Info=True;
                    User ID=SA; Password=Passw0rd2018"))
            {
                connection.Open();
                string SQLDelete = $"delete from Customers where CustomerID='{CustomerID}'";
                using (var command = new SqlCommand(SQLDelete, connection))
                {
                    ret = command.ExecuteNonQuery();
                }
            }
            return ret;
        }

        // Other
        public static void PrintCustomers(List<Customer> customers)
        {
            Console.WriteLine($"Customer ID\tCompany Name\t\t\tContact Name");
            Console.WriteLine("------------------------------------------------------------------------");
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15}{c.CompanyName,-35}{c.ContactName}"));
        }

    }

    internal class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }

        public Customer(string CustomerID, string CompanyName, string ContactName)
        {
            this.CustomerID = CustomerID;
            this.CompanyName = CompanyName;
            this.ContactName = ContactName;
        }

        public Customer()
        {
        }
    }
}
