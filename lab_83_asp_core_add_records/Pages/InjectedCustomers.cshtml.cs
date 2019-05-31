using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab_83_asp_core_add_records.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_83_asp_core_add_records.Pages
{
    public class InjectedCustomersModel : PageModel
    {
        private Northwind db;
        public List<Customer> customers;

        // Bind Property is required for the POSTING of data from FORM
        [BindProperty]
        public Customer customer { get; set; }

        // Constructor to instantiate this db
        // Instantiate Northwind just once : use for Get() and Post()
        public InjectedCustomersModel(Northwind injectedContext)
        {
            db = injectedContext;
        }

        public void OnGet()
        {
            customers = db.Customers.Skip(20).Take(10).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToPage("/AllCustomers");
            }
            return Page();
        }
    }
}