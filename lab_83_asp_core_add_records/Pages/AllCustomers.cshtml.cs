using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_83_asp_core_add_records.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_83_asp_core_add_records.Pages
{
    public class AllCustomersModel : PageModel
    {
        public List<Customer> customers;
        public int maxPage;
        public int current;     // Current page
        public int perPage = 10;

        public void OnGet()
        {
            using (var db = new Northwind())
            {
                // Delete customer from database
                if (Request.Query.ContainsKey("delete"))
                {
                    try
                    {
                        var customerToDelete = db.Customers.First(c => c.CustomerID == Request.Query["delete"]);
                        db.Customers.Remove(customerToDelete);
                        db.SaveChanges();
                    }
                    catch { }
                }

                // Figure out which page the user wants to view
                if (Request.Query.ContainsKey("page"))
                {
                    // Use TryParse instead of Parse so that the user can't cause any
                    // crashes by entering some garbage.
                    Int32.TryParse(Request.Query["page"], out current);
                }
                else
                {
                    // If the client does not provide a query string, display the default page
                    current = 1;
                }
                // Don't let the user navigate to pages that don't exist
                maxPage = (int)Math.Ceiling((double)db.Customers.Count() / perPage);
                current = Math.Max(current, 1);
                current = Math.Min(current, maxPage);

                // Build the customer list that will be used for display
                customers = db.Customers.Skip(perPage * (current - 1)).Take(perPage).ToList();
            }
        }
    }
}