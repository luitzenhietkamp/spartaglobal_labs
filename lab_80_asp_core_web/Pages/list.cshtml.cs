using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab_80_asp_core_web.Pages
{
    public class listModel : PageModel
    {
        public List<string> items = new List<string>();

        public void OnGet()
        {
            items.Add("Here");
            items.Add("is");
            items.Add("a");
            items.Add("list");
            items.Add("with");
            items.Add("some");
            items.Add("data");
            items.Add(".");
        }
    }
}