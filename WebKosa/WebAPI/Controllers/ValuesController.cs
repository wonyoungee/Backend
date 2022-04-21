using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };     // 전체 조회 select * from emp
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";     // 조건 조회 select * from emp where empno=7788
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            // data 받아서 insert   >> insert into ...
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            // data 받아서 update  >>  update emp...
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            // data 받아서 delete
        }
    }
}
