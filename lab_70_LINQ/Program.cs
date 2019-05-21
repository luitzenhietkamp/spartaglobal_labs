using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_70_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindModel())
            {
                // LINQ SELECT
                // DATA TYPE IS IQUERYABLE which means DATA NOT LOADED UNTIL ACTUALLY NEEDED
                // LAZY LOADING
                var customers =
                    from customer in db.Customers
                    where customer.City == "Berlin" || customer.City == "London"
                    select customer;

                // DATA ACTUALLY LOADED HERE
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.CustomerID,-15} {customer.ContactName,-20} from {customer.City}");
                }

                // only works on primary key
                var oneCustomer = db.Customers.Find("ALFKI");

                Console.WriteLine($"One customer is {oneCustomer.ContactName} from {oneCustomer.City}");


                // order by
                var allCustomers =
                    from c in db.Customers
                    orderby c.City
                    select c;

                foreach (var customer in allCustomers)
                {
                    Console.WriteLine($"{customer.CustomerID,-15} {customer.ContactName,-20} from {customer.City}");
                }

                // CREATE NEW OUTPUT OBJECT
                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Creating Custom Objects{Environment.NewLine}{Environment.NewLine}"); // CREATE NEW OUTPUT OBJECT
                var customOutputObject =
                    from c in db.Customers
                    orderby c.Country descending, c.City descending
                    select c;

                foreach (var c in customOutputObject)
                {
                    Console.WriteLine($"{c.CustomerID,-15} {c.ContactName,-20} from {c.Country,-10}, {c.City}");
                }

                var customOutputObject2 =
                    from c in db.Customers
                    orderby c.Country, c.City
                    select new
                    {
                        ID = c.CustomerID,
                        Name = c.ContactName,
                        Location = c.City + " in " + c.Country
                    };

                foreach (var c in customOutputObject2)
                {
                    Console.WriteLine($"{c.ID,-10} {c.Name,-25} from {c.Location}");
                }

                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Now also create a custom type{Environment.NewLine}{Environment.NewLine}");
                //  WRAP IN BRACKETS TO MAKE A LIST
                var customOutputObject3 =
                    (from c in db.Customers
                     orderby c.Country, c.City
                     select new CustomObject
                     {
                         ID = c.CustomerID,
                         Name = c.ContactName,
                         Location = c.City + " in " + c.Country
                     }).ToList();

                customOutputObject3.ForEach(c => Console.WriteLine($"{c.ID,-10} {c.Name,-25} from {c.Location}"));



                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}LINQ Group By{Environment.NewLine}{Environment.NewLine}");

                // Create 'cities' object holding customers by city
                var CountCustomerByCity =
                    from c in db.Customers
                    group c by c.City into cities
                    orderby cities.Count() descending
                    select new
                    {
                        City = cities.Key,
                        Count = cities.Count()
                    };

                foreach (var item in CountCustomerByCity)
                {
                    Console.WriteLine($"{item.City,-20} count: {item.Count}");
                }
   
            }
        }
    }

    class CustomObject
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

  
}
