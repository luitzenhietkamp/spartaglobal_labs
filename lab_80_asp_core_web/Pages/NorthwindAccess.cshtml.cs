using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;

using lab_80_asp_core_web.Models;

namespace lab_80_asp_core_web.Pages
{
    public class NorthwindAccessModel : PageModel
    {
        public List<Customer> customers;

        public void OnGet()
        {
            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();
            }
        }
    }
}