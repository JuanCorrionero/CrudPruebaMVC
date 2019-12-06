using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Controllers
{
    public class HomeController : Controller
    {
        //get - LOAD
        public ActionResult Index()
        {
            return View();
        }
        //post - Negocio - Siempre tiene que recibir algo.
        //public ActionResult Index(int id)
        //{
        //    return View();
        //}
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}