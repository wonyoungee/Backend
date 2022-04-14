using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

namespace WebApp_Procedure
{
    public partial class WebForm_Proc : System.Web.UI.Page
    {
        /*
         Create procedure user_regprocedure
         @UName varchar(50),
         @UAddress varchar(50),
         @Gender varchar(6),
         @U_Password varchar(50)
          AS
          BEGIN
             INSERT INTO user_registration VALUES (@UName,@UAddress,@Gender,@U_Password)
          END
        */

        // 다른 함수에서도 사용된다면
        SqlConnection conn = null;
        SqlCommand cmd = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegiser_Click(object sender, EventArgs e) // 클릭이벤트에 동작하는 함수
        {
            //연결 문자열 생성
            string strConn = @"Data Source=DESKTOP-TA6KUCJ\SQLEXPRESS;uid=sa;pwd=1004;database=kosadb";
            conn = new SqlConnection(strConn);
            conn.Open();

            SqlCommand cmd = new SqlCommand("user_regprocedure", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@UName", txt_name.Text);   //txt_name는 웹폼의 id
            cmd.Parameters.AddWithValue("@UAddress", txt_address.Text); // 원래는 c# 은 request[""] 형식
            cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@U_Password", txt_pwd.Text);

            cmd.ExecuteNonQuery();
            conn.Close();

            lbl_msg.Text = "Record Inserted";
        }
    }
}