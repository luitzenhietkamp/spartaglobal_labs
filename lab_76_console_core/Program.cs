using System;
using System.Linq;
using System.Collections.Generic;

namespace lab_76_console_core
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products;
            List<Category> categories;

            using (var db = new Northwind())
            {
                categories = db.Categories.ToList();
                products = db.Products.ToList();

                foreach (var p in products)
                {
                    var category = db.Categories.Find(p.CategoryID);
                    Console.WriteLine($"{p.ProductID,-10}{p.ProductName,-35}{category.CategoryName}");
                }
            }


        }
    }
}