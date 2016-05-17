using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaltationSistemas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SaveChanges()
        {

            return View();

        }
        [HttpPost]
        public ActionResult Save()
        {
            new Services.ListService().SaveChanges();
            return Redirect("/");
        }
    }
}