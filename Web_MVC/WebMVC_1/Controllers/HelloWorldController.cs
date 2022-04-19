using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC_1.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: HelloWorld
        public string Index()
        {
            return "<b>my site create .........</b>";
        }
        // GET : http://localhost:52686/HelloWorld/welcome/
        /*
        public string welcome(string name, int age=20)
        {
            //return "action method return string";
            return HttpUtility.HtmlEncode("Hello " + name + " age : " + age);
        }
        */

        //http://localhost:52686/HelloWorld/welcome/100?name=wonyeong
        // 전체 주소로 ID값 받아서 처리..
        // name까지 주소에 받아서 하고 싶다면..
        // http://localhost:52686/HelloWorld/welcome/king/100  도 가능 (대신 RouteConfig.cs 에 추가해야함)
        public string welcome(string name, int ID = 1)
        {
            //return "action method return string";
            return HttpUtility.HtmlEncode("Hello " + name + " ID : " + ID);
        }
    }
}