using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MyApp.Models; // 추가

namespace MyApp.Controllers
{
    public class HelloWorldController : Controller
    {
        // http://localhost:49779/HelloWorld
        public ActionResult Index()
        {
            return View();  // Views 폴더 >  HelloWorld > index.cshtml 뷰로 정의
        }

        /*
        // http://localhost:49779/HelloWorld
         public string Index()
         {
              return "<h3>My HelloWorld site</h3>";
         }
        */


        // http://localhost:49779/HelloWorld/welcome
        //url: "{controller}/{action}/{id}"
        //HelloWorld : {controller}
        // welcome : {action} (컨트롤러의 메소드)

        /*
        // Parameter 설정
        // http://localhost:49779/HelloWorld/welcome?name=kglim&numtime=10
        public string welcome(string name, int numtime=1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + " , numtime : " + numtime);  // http 공격을 막을 수 있는 방법(?)
        }
        */

        // url: "{controller}/{action}/{id}"
        // http://localhost:49779/HelloWorld/welcome/12?name=kglim
        // 12 : {id}
        public string welcome(string name, int ID = 1)
        {
            return HttpUtility.HtmlEncode("Hello " + name + " , ID : " + ID);  // http 공격을 막을 수 있는 방법(?)
        }

        // http://localhost:49779/HelloWorld/welcome/world/100      >>  Hello world , ID : 100
        //  http://localhost:49779/HelloWorld/welcome/100/world     >>  Hello 100 , ID : 1          >> default값 1 출력

        [HttpPost]
        public JsonResult ajaxMethod(string name)
        {

            PersonModel person = new PersonModel
            {
                Name = name,
                DateTime = DateTime.Now.ToString()
            };
            return Json(person);
        }

        public JsonResult empMethod()
        {
            Employee emp = new Employee()
            {
                ID = "Emp23",
                Name = "Steven Clark",
                Mobile = "825415426"
            };
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

        public ActionResult kosaWorld(string name, int num = 1)
        {
            ViewBag.Message = "Hello World"+name;    // view bag - 클라이언트에게 전달
            ViewBag.num = num;

            return View();
        }

        public ActionResult UserData()
        {
            // 1. 요청함수(Action)쪽에서 만든 데이터를 View 까지 전달

            // 1. 요청 받기

            // 2. 데이터 처리
            // 2.1 클라이언트에서 넘어온 데이터      
            //  >> parameter로 받는 방법 :  public ActionResult UserData(string a, string b)
            //  >>  url을 통해 받는 방법 : http://localhost:49779/HelloWorld/UserData/100/200/300
            //  
            // 2.2 DAO를 통해서 생성된 데이터
            // Model 에 객체 요청 >> EmpData.cs >> CRUD 구현
            // EmpData emp = new EmpData();


            // 3. 데이터 전달 (View에다가)      >>      *.cshtml (Razor 문법)
            // 3.1 전달 방법 : ViewBag.emp = emplist
            // 3.2 전달방법 : return View(emplist);
            // view.cshtml  >   @ViewBag.User.UserNo
            // View(myuser) : view.cshtml   >   @Model.UserNo


            var myuser = new User();
            myuser.UserNo = 100;
            myuser.UserName = "김유신";

            //ViewBag.User = myuser;

            //뷰백에 담지 않을 경우 뷰의 parameter로 보냄.
            return View(myuser);
        }
    }
}