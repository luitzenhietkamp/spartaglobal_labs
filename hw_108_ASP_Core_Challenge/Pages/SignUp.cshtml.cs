using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw_108_ASP_Core_Challenge.Classes;
using hw_108_ASP_Core_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw_108_ASP_Core_Challenge.Pages
{
    public class SignUpModel : PageModel
    {
        public void OnGet()
        {
            using (var db = new ChallengeDB())
            {
                var user = new User
                {
                    UserName = Request.Query["Username"],
                    PwHash = Hash.HashPW(Request.Query["Password"])
                };

                if (user.UserName == null || user.PwHash == null) return;

                db.Users.Add(user);

                db.SaveChanges();
            }
        }
    }
}