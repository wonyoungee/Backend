using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMVCAjax.Models
{
    public class Employee   // dto==vo==domain 클래스
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}