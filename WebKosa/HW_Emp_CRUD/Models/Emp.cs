using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW_Emp_CRUD.Models
{
    public class Emp    // DTO
    {
        public int empno { get; set; }
        public string ename { get; set; }
        public string job { get; set; }
        public int? mgr { get; set; }
        public string hiredate { get; set; }
        public int? sal { get; set; }
        public int? comm { get; set; }
        public int? deptno { get; set; }
    }
}