using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using System.Web.Script.Serialization;  // 직렬화

namespace WebApp_1
{
    public partial class WebForm_DB_JSON : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //연결 문자열 생성
            string strConn = @"Data Source=DESKTOP-TA6KUCJ\SQLEXPRESS;uid=sa;pwd=1004;database=KosaDB;"; 
            //연결 객체 생성
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open(); //연결 정보를 통해 DB통신 시도

            string sql = "select * from emp;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            
            List<EmpInfo> Objects = new List<EmpInfo>();
            while (reader.Read())
            {
                //Creating Custom Class Object
                    Objects.Add(new EmpInfo {
                        empno = Convert.ToInt32(reader[0]),
                        ename = reader[1].ToString(),
                        job = reader[2].ToString(),
                        mgr = Convert.ToInt32(reader[3]),
                        hiredate =reader[4].ToString(),
                        sal =Convert.ToInt32(reader[5]),
                        comm = Convert.ToInt32(reader[6]),
                        deptno = Convert.ToInt32(reader[7])
                    });
            }

            //Creating a JavaScriptSerializer Object
            var jsonString = new JavaScriptSerializer();
            //Use of Serialize() method
            var jsonStringResult = jsonString.Serialize(Objects);
            Response.Write(jsonStringResult);    // json 문자열로 변환

            //자원해제 (네트워크, IO)는 GC가 지우지 못함 명시적으로 해제해야함
            reader.Close();
            conn.Close();
        }
    }

    
    //Custom Classes
    public class EmpInfo
    {
        public int empno;
        public string ename;
        public string job;
        public int? mgr;
        public string hiredate;
        public int? sal;
        public int? comm;
        public int? deptno;
    }
    
}