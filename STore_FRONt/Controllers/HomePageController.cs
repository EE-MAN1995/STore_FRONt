using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace STore_FRONt.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult Contact_Information()
        {


            return View();
        }
    }
}