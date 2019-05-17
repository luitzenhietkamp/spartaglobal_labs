using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab_67_razor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewData["Message2"] = "Hello world";
            return View();
        }

        public ActionResult RazorHelloWorld()
        {
            ViewBag.Message = "ViewBag";
            ViewData["message2"] = "ViewData";
            var passThisString = "Send some data from controller to view";

            return View("RazorHelloWorld", passThisString);
        }
    }
}