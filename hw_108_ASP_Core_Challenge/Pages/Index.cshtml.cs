using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw_108_ASP_Core_Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace hw_108_ASP_Core_Challenge.Pages
{
    public class IndexModel : PageModel
    {
        public Profile profile;

        public void OnGet()
        {
            //using (var db = new ChallengeDB())
            //{
            //    profile = db.Profiles.Include("User").ToList()[0];
            //}
        }
    }
}
