using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_1
{
    public partial class WebForm_Request : System.Web.UI.Page
    {
        /* page 처음 불러올때 호출 ...*/
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 웹 서버가 내장하고 있는 기본 객체
             * 1. request (요청객체) : 클라이언트가 서버에 요청을 하게 되면 서버에서 생성되는 객체 (정보 : 클라이언트 정보)
                                                    1) 클라이언트가 입력한 회원가입 정보
                                                    2) 클라이언트의 웹 브라우저 버전, 요청정보 ... => request가 받아서 가지고 있음
             * 2. response (응답객체) : 서버가 가진 정보를 클라이언트에게 보내는 객체
             * 
             * 3. session
             * 4. application
             * 5. server
             * 
             * 원칙적으로 Page 2개
             * 1. 회원가입 할거야 -> 서버에 요청
             *    서버가 register.jsp 보냄  ->  회원가입 데이터 보낼게 register.aspx
             *  
             *  2. Webform 하나가 화면 단과 처리단을 하나로 묶어서 처리...
             */

            string struserid = "";
            string strpassword = "";
            string strname = "";
            string strage = String.Empty;

            // 1. request 객체의 QueryString 컬렉션 Get
            struserid = Request["userid"];

            // 2. request 객체의 params 컬렉션
            strpassword = Request.Params["password"];

            strname = Request.Form["name"];

            strage = Request["age"];

            string strMsg = String.Format("입력한 아이디 : {0}이고 </br>" + "암호는 {1}이고, 이름은 {2}이고, 나이는 {3}입니다",
                struserid, strpassword, strname, strage);

            Response.Write(strMsg);

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            // 원칙적인 방법은
            // 클라이언튿에서 전송된 data >> Request 객체를 통해 전달 받는 것이 가장 일반적인 방식

            // 원칙적인 방법 말고 서버컨트롤의 속성을 사용해서 정보를 얻을 수 있다.
            string username = name.Text;
            int userage = Convert.ToInt16(age.Text);
            userdata.Text = username;
            userdata2.Text = userage.ToString();
            
            //Console.WriteLine("username : " + username);
            //Console.WriteLine("userage:" + userage);
        }

    }
}