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
                if (Request.Query.Count == 0)
                {
                    current = 1;
                }
                else
                {
                    current = Int32.Parse(Request.Query["page"]);
                }
                maxPage = (int)Math.Ceiling((double)db.Customers.Count() / perPage);
                current = Math.Max(current, 1);
                current = Math.Min(current,
                    maxPage);
                customers = db.Customers.Skip(perPage * (current - 1)).Take(perPage).ToList();
            }
        }
    }
}