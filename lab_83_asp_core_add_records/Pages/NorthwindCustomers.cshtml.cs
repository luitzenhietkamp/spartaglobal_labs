using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_83_asp_core_add_records.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_83_asp_core_add_records.Pages
{
    public class NorthwindCustomersModel : PageModel
    {
        public List<Customer> customers;

        public void OnGet()
        {
            using (var db = new Northwind())
            {
                customers = db.Customers.Skip(10).Take(10).ToList();    // 11-20
            }
        }
    }
}