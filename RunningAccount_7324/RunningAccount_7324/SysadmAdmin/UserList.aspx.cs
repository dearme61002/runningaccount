using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RunningAccount_7324.backendweb
{
    public partial class WebForm4 : System.Web.UI.Page
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
                this.Literal1.Text = "<span class='text-white'>歡迎你的登入" + userInfo.name + "先生/小姊</span>";
                //傳資料
          
              List<modols.UserInfo> objectuserinfo  = new dal.ServicUser().getalluserinfo();
                if(objectuserinfo != null)
                {
                    this.GridView1.DataSource = objectuserinfo;
                    this.GridView1.DataBind();
                }
            }
        }

        protected void AddButton1_Click(object sender, EventArgs e)
        {
        Response.Redirect("~/SysadmAdmin/UserDetail.aspx?chang=0");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/UserInfo.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
         
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/UserList.aspx");
        }
    }
}