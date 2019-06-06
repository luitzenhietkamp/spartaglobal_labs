using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_83_asp_core_add_records.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw_108_ASP_Core_Challenge.Pages
{
    public class QuickEditModel : PageModel
    {
        public List<Customer> customers;

        public int current;     // Current page
        public int perPage = 10;
        public string highlight;

        public string affectedCustomerID;

        public void OnGet()
        {
            // Validate input
            if (!Request.Query.ContainsKey("oldCustomerID") ||
                !Request.Query.ContainsKey("CustomerID") ||
                !Request.Query.ContainsKey("CompanyName") ||
                !Request.Query.ContainsKey("ContactName"))
            {
                return;
            }
            using (var db = new Northwind())
            {
                try
                {
                    affectedCustomerID = Request.Query["oldCustomerID"];

                    Customer customer = db.Customers.First(c => c.CustomerID == affectedCustomerID);

                    customer.CustomerID = Request.Query["CustomerID"];
                    customer.CompanyName = Request.Query["CompanyName"];
                    customer.ContactName = Request.Query["ContactName"];

                    db.SaveChanges();

                    highlight = "class=success";
                }
                catch
                {
                    highlight = "class=danger";
                }

                int i = 0;
                do
                {
                    ++i;
                    // Build the customer list that will be used for display
                    customers = db.Customers.Skip(perPage * (i - 1)).Take(perPage).ToList();
                }
                while (!customers.Any(c => c.CustomerID == affectedCustomerID) && customers.Count != 0);
            }
        }
    }
}