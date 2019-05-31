using System.Collections.Generic;
using System.Linq;
using hw_108_ASP_Core_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw_108_ASP_Core_Challenge.Pages
{
    public class FindUsersModel : PageModel
    {
        public IActionResult OnGet()
        {
            string username = Request.Query["q"];

            List<User> matchingUsers;

            using (var db = new ChallengeDB())
            {
                matchingUsers = db.Users.Where(u => u.UserName.StartsWith(username)).ToList();
            }

            return new JsonResult(matchingUsers);
        }
    }
}