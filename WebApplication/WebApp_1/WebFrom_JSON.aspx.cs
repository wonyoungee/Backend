using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;  // 직렬화

namespace WebApp_1
{
    public partial class WebFrom_JSON : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Creating Custom Class Object
             var Object = new MyInformation
             {
                 firstName = "Olivia",
                 lastName = "Mason",
                 dateOfBirth = new DateOfBirth
                 {
                     year = 1999,
                     month = 06,
                     day = 19
                 }
             };
            //Creating a JavaScriptSerializer Object
            var jsonString = new JavaScriptSerializer();

            //Use of Serialize() method
            var jsonStringResult = jsonString.Serialize(Object);
            //Console.WriteLine(jsonStringResult);
            Response.Write(jsonStringResult);   //json 문자열 변환

            //{"firstName":"Olivia","lastName":"Mason","dateOfBirth":{"year":1999,"month":6,"day":19}}
        }
    }

    //Custom Classes
    public class MyInformation
    {
        public string firstName;
        public string lastName;
        public DateOfBirth dateOfBirth;
    }

    public class DateOfBirth
    {
        public int year;
        public int month;
        public int day;

    }
}