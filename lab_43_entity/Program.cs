using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_43_entity
{
    class Program
    {

        static Customers customerToUpdate;
        static Customers findOneCustomer;

        static void Main(string[] args)
        {
            // automatically clean up database connection when done
            using (var db = new NorthwindEntities())
            {
                var customers = db.Customers.ToList();

                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.CustomerID);
                }

                foreach (var c in customers)
                {
                    Console.WriteLine($"ID is {c.CustomerID}, name is {c.ContactName}");
                }

                // update one customer
                customerToUpdate = db.Customers.Where(cust => cust.CustomerID == "ALFKI").FirstOrDefault();

                customerToUpdate.City = "London";
                db.SaveChanges();


            }

            using (var db = new NorthwindEntities())
            {
                findOneCustomer =
                    (from cust in db.Customers
                    where cust.CustomerID == "ALFKI"
                    select cust).FirstOrDefault();
                Console.WriteLine($"\n\nupdated customer has new city = {findOneCustomer.City}");
            }

                try
                {
                    // contact database
                }
                catch
                {
                    // any errors
                }
                finally
                {
                    // close database
                }
        }
    }
}
