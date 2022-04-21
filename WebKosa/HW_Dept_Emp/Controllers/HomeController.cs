using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using HW_Dept_Emp.Models;

namespace HW_Dept_Emp.Controllers
{
    public class HomeController : Controller
    {
        DeptDB deptDB = new DeptDB();
        public JsonResult EmpList(int ID)
        {
            return Json(deptDB.EmpByDeptno(ID), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Index()
        {
            
            List<Dept> deptList = deptDB.ListAll();
            ViewBag.DeptList = deptList;
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

            return View();
        }
    }
}