using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_72_LINQ_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                Console.WriteLine($"Orders By Customer Using LINQ Join{Environment.NewLine}{Environment.NewLine}");
                var custOrders =
                    from cust in db.Customers
                    join order in db.Orders
                    on cust.CustomerID equals order.CustomerID
                    orderby cust.ContactName, order.OrderDate
                    select new
                    {
                        cust.CustomerID,
                        Name = cust.ContactName,
                        order.OrderID,
                        order.OrderDate
                    };

                foreach (var c in custOrders)
                {
                    Console.WriteLine($"{c.CustomerID,-10}{c.Name,-25}{c.OrderID,-15}{c.OrderDate:d}");
                }

                Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Smart LINQ queries{Environment.NewLine}{Environment.NewLine}");
                Console.WriteLine($"{Environment.NewLine}Looking at Product Categories and all products per category{Environment.NewLine}{Environment.NewLine}");

                // print out all db.Categories
                var categories =
                    from cat in db.Categories
                    select cat;

                foreach (var cat in categories)
                {
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine($"| {cat.CategoryName, -15}| {cat.Description,-35}|");
                    Console.WriteLine("------------------------------------------------------");

                    // Include all products
                    var prodsInCat =
                        from prod in db.Products
                        where prod.CategoryID == cat.CategoryID
                        select prod;

                    int i = 0;
                    foreach (var prod in prodsInCat)
                    {
                        if (i++ == prodsInCat.Count() / 2)
                        {
                            Console.WriteLine($"|    Products    | {prod.ProductName,-35}|");
                        }
                        Console.WriteLine($"|                | {prod.ProductName,-35}|");
                    }
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\n\nLINQ Group Products By Category\n");
            using (var db = new NorthwindEntities())
            {
                var productsByCategory =
                    (from c in db.Categories
                     join product in db.Products on c.CategoryID equals product.CategoryID
                     select new
                     {
                         id = c.CategoryID,
                         category = c.CategoryName,
                         productID = product.ProductID,
                         name = product.ProductName
                     }).ToList();
                foreach (var p in productsByCategory)
                {
                    Console.WriteLine($"Category {p.category} with id {p.id} has product {p.name} with id {p.productID}");
                }
            }


            Console.WriteLine("\n\nNow try grouping\n\n");
            using (var db = new NorthwindEntities())
            {
                var productsByCategory =
                    (from c in db.Categories
                     join product in db.Products on c.CategoryID equals product.CategoryID
                     select new
                     {
                         id = c.CategoryID,
                         category = c.CategoryName,
                         productID = product.ProductID,
                         name = product.ProductName
                     }).GroupBy(category => category.category)
                        .Select(category => new {
                            name = category.Key,
                            count = category.Count()
                        }).ToList();

                foreach (var p in productsByCategory)
                {
                    Console.WriteLine($"Category {p.name} has count {p.count}");
                }
            }

            //using (var db = new NorthwindEntities())
            //{
            //    Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}Let's upgrade this to include all products");

            //    var prodsWithCat = 
            //        from db.Products
            //}
        }
    }
}
