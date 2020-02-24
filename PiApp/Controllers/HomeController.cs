using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult app()
        {
            return PartialView();
        }
        public ActionResult Nav()
        {
            return PartialView();
        }
        public ActionResult header()
        {
            return PartialView();
        }
        public ActionResult ListFood()
        {
            return PartialView();
        }
        public ActionResult CreateFood()
        {
            return PartialView();
        }
        public ActionResult UpdateCategoryId()
        {
            return PartialView();
        }
    }
}
