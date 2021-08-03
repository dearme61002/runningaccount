using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using modols;
using dal;

namespace RunningAccount_7324
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void LoginButton1_Click(object sender, EventArgs e)
        {
            modols.UserInfo userInfo = new modols.UserInfo();
            userInfo.account = this.AccountTextBox1.Text.Trim();
            userInfo.pwd = this.PWDTextBox2.Text.Trim();

            try
            {
                userInfo = new dal.ServicUser().login(userInfo);
                if (userInfo.name == null)
                {
                    Literal1.Text = "<script type='text/javascript'> alert('帳號或密碼不存在!!')</script>";
                }
                else
                {

                    Session["currentuser"] = userInfo;
                    Response.Redirect("~/SysadmAdmin/UserInfo.aspx");
                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}