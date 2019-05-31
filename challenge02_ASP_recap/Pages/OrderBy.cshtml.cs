using System;
using System.Collections.Generic;
using System.Linq;
using challenge02_ASP_recap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace challenge02_ASP_recap.Pages
{
    public class OrderByModel : PageModel
    {
        public List<Task> Tasks;

        public void OnGet()
        {
            using (var db = new ToDoApp())
            {
                Tasks =
                    (from t in db.Tasks
                    orderby t.TaskDescription ascending
                    select t).Include("User").Include("Category").ToList();
            }
        }
    }
}