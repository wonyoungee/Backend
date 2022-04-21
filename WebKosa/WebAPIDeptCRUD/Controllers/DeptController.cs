using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using WebAPIDeptCRUD.Models;

namespace WebAPIDeptCRUD.Controllers
{
    public class DeptController : ApiController
    {
        DeptDB deptDB = new DeptDB();

        public List<Dept> GetAllProduct() // 함수의 이름이 중요. Get으로 시작
        {
            return deptDB.GetAll();
        }
    }
}
