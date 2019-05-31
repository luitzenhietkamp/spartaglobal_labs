using System;
using System.Collections.Generic;
using System.Linq;
using challenge02_ASP_recap.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace challenge02_ASP_recap.Pages
{
    public class ToDoAppModel : PageModel
    {
        public List<User> Users;
        public List<Task> Tasks;

        public void OnGet()
        {
            using (var db = new ToDoApp())
            {
                Users = db.Users.ToList();
                Tasks = db.Tasks.Include("User").Include("Category").ToList();
            }
        }
    }
}