using System;
using System.Collections.Generic;
using System.Linq;
using challenge02_ASP_recap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace challenge02_ASP_recap.Pages
{
    public class CustomObjectModel : PageModel
    {
        public List<CustomTask> Tasks;
        public void OnGet()
        {
            using (var db = new ToDoApp())
            {
                Tasks =
                    (from t in db.Tasks
                     orderby t.TaskDescription ascending
                     select new CustomTask
                     {
                         TaskDescription = t.TaskDescription,
                         CategoryID = t.CategoryID
                     })
                     .ToList();
            }
        }
    }

    public class CustomTask
    {
        public string TaskDescription { get; set; }
        public int? CategoryID { get; set; }
    }
}