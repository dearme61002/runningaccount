using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using modols;
using dal;

namespace RunningAccount_7324.backendweb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["currentuser"] == null)
                {
                    Response.Redirect("~/Login.aspx");
                }
                modols.UserInfo userInfo = (modols.UserInfo)Session["currentuser"];
                this.Literal1Logined.Text = "<span class='text-white'>歡迎你的登入" + userInfo.name+ "先生/小姊</span>";
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["currentuser"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}