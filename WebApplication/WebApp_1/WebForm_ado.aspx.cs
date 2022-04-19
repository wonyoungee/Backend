using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace WebApp_1
{
    public partial class WebForm_ado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //연결 문자열 생성
            //string strConn = @"Data Source=DESKTOP-IT2S01N\SQLEXPRESS01;Initial Catalog=KosaDB;Integrated Security=SSPI;";
            string strConn = @"Data Source=DESKTOP-TA6KUCJ\SQLEXPRESS;uid=sa;pwd=1004;database=KosaDB;"; //로그인 x kosadb에 유저가 추가가 없을 경우
            //연결 객체 생성
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();

            string sql = "select * from emp where empno=" + Request["empno"]; //get post 받아서 메모리에 올라감
            //string sql = "select * from emp;";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reder = cmd.ExecuteReader();

            Response.Write("<table border=1>");
            while (reder.Read())//data row 개수만큼
            {
                Response.Write("<tr>");
                for (int i = 0; i < reder.FieldCount; i++) // data row의 컬럼 개수만큼
                {
                    Response.Write("<td>" + reder[i] + "</td>");
                }
                Response.Write("</tr>");
            }
            Response.Write("</table>");
            //자원해제 (네트워크, IO)는 GC가 지우지 못함 명시적으로 해제해야함
            reder.Close();
            conn.Close();

            //http://localhost:50109/WebForm_ado.aspx?empno=7902  테스트
        }
    }
}