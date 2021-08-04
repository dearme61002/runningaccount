using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RunningAccount_7324.backendweb
{
    public partial class WebForm6 : System.Web.UI.Page
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
               modols.UserInfo userInfo1= new dal.ServicUser().getUserbyuserid(Request.QueryString["id"].ToString());
                this.Literal2.Text = userInfo1.account;
            }
            }

        protected void saveButton1_Click(object sender, EventArgs e)
        {
            //date can use
            Regex rgxpass = new Regex(@"^.{8,16}$");

            //if((this.TextBox1.Text.Trim() == "") || !rgxpass.IsMatch(this.TextBox1.Text.Trim()))
            //{
            //    this.Literaltrsult.Text= "<strong>密碼長度要8~16位只能包含字母、數字或下滑線</strong>";
            //}
            if ((this.TextBox2.Text.Trim() == "") || !rgxpass.IsMatch(this.TextBox2.Text.Trim()))
            {
                this.Literaltrsult.Text = "<strong>密碼長度要8~16位只能包含字母、數字或下滑線</strong>";
                return;
            }
            if (this.TextBox2.Text.Trim() != this.TextBox3.Text.Trim())
            {
                this.Literaltrsult.Text = "<strong>密碼要一致</strong>";
                return;
            }
        

            string ordpas = this.TextBox1.Text.Trim();

            if(new dal.ServicUser().thispasisexitbyOldpasandId(ordpas, Request.QueryString["id"].ToString()))
            {
                string newpaw = this.TextBox3.Text.Trim();
              if(new dal.ServicUser().updatePAWbyid(newpaw, Request.QueryString["id"].ToString()) > 0)
                {
                    Response.Redirect("~/SysadmAdmin/UserDetail.aspx?id="+Request.QueryString["id"].ToString()+"&chang=1");
                }
                else
                {
                    this.Literaltrsult.Text = "<script>alert('更改密碼錯誤錯誤')</script>";
                    return;
                }

            }
            else
            {
                this.Literaltrsult.Text = "<script>alert('原密碼錯誤或資料錯誤')</script>";
                return;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/UserList.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/UserInfo.aspx");
        }
    }
}