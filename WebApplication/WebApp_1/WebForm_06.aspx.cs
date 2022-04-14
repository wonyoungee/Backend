using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_1
{
    public partial class WebForm_06 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            if (!IsPostBack)
            {
                // 페이지가 처음 로드 되었다면
                // 초기화 작업
                Response.Write("처음 로드");      
            }
            */

            string msg = Request["msg"];
            var today = new DateTime(2022, 4, 13);
            var strtoday = string.Format("{0}년{1:00}월{2:00}일", today.Year, today.Month, today.Day);
            Response.Write(msg + "/" +strtoday);

        }
    }
}