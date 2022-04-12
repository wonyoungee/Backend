using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// data작업에 필요한 namespace
using System.Data;
using System.Data.SqlClient;

namespace WebApp_1
{
    public partial class WebForm_ado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 연결 문자열 생성
            //string strConn = @"Data Source=DESKTOP-DD3FU43\SQLEXPRESS01;Initial Catalog=kosadb; Integrated Security=SSPI;";
            string strConn = @"Data Source=DESKTOP-DD3FU43\SQLEXPRESS01; uid=sa; pwd=1004; database=kosadb";
            // 연결 객체 생성
            SqlConnection conn = new SqlConnection(strConn);
            conn.Open();    // 연결 정보를 통해 DB통신 시도
            Response.Write(conn.State + "<br>");
            conn.Close();   //연결 해제
            Response.Write(conn.State);
        }
    }
}