using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_44_entity2
{
    class Program
    {
        static List<Customers> customerList;    // all
        //static Customers customer;              // one
        //static Customers newCustomer;           // add new

        static void Main(string[] args)
        {
            //// encapsulates database for easy cleanup afterwards
            //using (var db = new NorthwindEntities())
            //{
            //    // Standard LINQ query
            //    customerList = 
            //        (from c in db.Customers
            //        select c).ToList<Customers>();

            //    foreach(Customers c in customerList)
            //    {
            //        Console.WriteLine($"ID : {c.CustomerID}, Name : {c.ContactName}, City : {c.City}");
            //    }

            //    // select one customer and update
            //    customer = db.Customers.Where(cust => cust.CustomerID == "SIMOB").FirstOrDefault();
            //    customer.City = "Kobenhavn";
            //    db.SaveChanges();
            //}

            //using (var db = new NorthwindEntities())
            //{
            //    //foreach (Customers c in customerList)
            //    //{
            //    //    Console.WriteLine($"ID : {c.CustomerID}, Name : {c.ContactName}, City : {c.City}");
            //    //}

            //    // LING STANDARD
            //    customer =
            //        (from cust in db.Customers
            //         where cust.CustomerID == "SIMOB"
            //         select cust).FirstOrDefault();

            //    // LING LAMBDA QUERY
            //    customer = db.Customers.Where(cust => cust.CustomerID == "SIMOB").FirstOrDefault();
            //    Console.WriteLine($"{customer.CustomerID}, {customer.ContactName}, {customer.City}");
            //}

            //// insert new
            //using (var db = new NorthwindEntities())
            //{
            //    newCustomer = new Customers
            //    {
            //        CustomerID = "BOBSH",
            //        ContactName = "Bobby Tables",
            //        CompanyName = "SpartaGlobal",
            //        City = "London"
            //    };
            //    db.Customers.Add(newCustomer);
            //    db.SaveChanges();
            //}

            //using (var db = new NorthwindEntities())
            //{
            //    // LING STANDARD
            //    customer =
            //        (from cust in db.Customers
            //         where cust.CustomerID == "BOBSG"
            //         select cust).FirstOrDefault();
            //    Console.WriteLine($"{newCustomer.CustomerID}, {newCustomer.ContactName}, {newCustomer.City}");
            //}

            using (var db = new NorthwindEntities())
            {
                var delCustomer =
                    db.Customers.Where(cust => cust.CustomerID == "BOBSG").FirstOrDefault();
                db.Customers.Remove(delCustomer);
                db.SaveChanges();
            }

            using (var db = new NorthwindEntities())
            {
               // Standard LINQ query
               customerList =
                   (from c in db.Customers
                    select c).ToList<Customers>();

                foreach (Customers c in customerList)
                {
                    Console.WriteLine($"ID : {c.CustomerID}, Name : {c.ContactName}, City : {c.City}");
                }
            }
        }
    }
}
