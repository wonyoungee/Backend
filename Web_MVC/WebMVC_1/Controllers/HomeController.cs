using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC_1.Controllers
{
    public class HomeController : Controller
    {
        // http://localhost:52686/Home/Index
        public ActionResult Index()
        {
            return View();
        }
        // http://localhost:52686/Home/About
        public ActionResult About()
        {
            // ViewBag : 데이터를 담은 객체
            ViewBag.Message = "Your application description page.";

            return View();  // View 페이지 부름
        }
        // http://localhost:52686/Home/Contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}