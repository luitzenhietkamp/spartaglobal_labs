using System;
using System.Collections.Generic;
using System.Linq;
using challenge02_ASP_recap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace challenge02_ASP_recap.Pages
{
    public class GroupByModel : PageModel
    {
        public List<TaskStats> TaskStats;

        public void OnGet()
        {
            using (var db = new ToDoApp())
            {
                TaskStats =
                    (from t in db.Tasks
                     group t by t.CategoryID into categories
                     select new TaskStats
                     {
                         Count = categories.Count(),
                         CategoryID = categories.Key
                     })
                     .ToList();
            }
        }
    }

    public class TaskStats
    {
        public int Count { get; set; }
        public int? CategoryID { get; set; }
    }
}