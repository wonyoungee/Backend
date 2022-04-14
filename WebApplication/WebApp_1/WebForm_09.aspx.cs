using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp_1
{
    public partial class WebForm_09 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = Request["name"];
            string pwd = Request["pwd"];

            Response.Write("당신의 이름은 : " + name);
            Response.Write("당신의 비번은 : "+ pwd);

        }
    }
}