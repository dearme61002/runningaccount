using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dal;
using modols;

namespace RunningAccount_7324.backendweb
{
    public partial class WebForm5 : System.Web.UI.Page
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
                int chang = Convert.ToInt32(Request.QueryString["chang"]);
                this.Literal3.Text = "<span>" + DateTime.Now.ToString() + "</span>";
                if (chang == 0)
                {
                    this.saveButton1.Text = "Add";
                    this.deleteButton2.Visible = false;
                    this.PSWButton1.Visible = false;
                    this.Literal2.Text = "<span>一般會員</span>";


                }
                else
                {
                    this.PSWButton1.Visible = true;
                    this.Timer1.Enabled = false;

                    this.deleteButton2.Visible = true;
                    this.Literalpas1.Visible = false;
                    this.Literalpas2.Visible = false;
                    this.TextBox3.Visible = false;
                    this.TextBox4.Visible = false;
                    this.Literalpas3.Visible = false;
                    //2021/8/4
                    modols.UserInfo objectUserInfo = new dal.ServicUser().getUserbyuserid(Request.QueryString["id"].ToString());
                    if (objectUserInfo == null)
                    {
                        this.Literalalter.Text = "<script>alert('跟改帳號失敗')</script>";
                        return;
                    }
                    this.accountTextBox.Text = objectUserInfo.account;
                    this.accountTextBox.Enabled = false;
                    this.TextBox1.Text = objectUserInfo.name;
                    this.TextBox2.Text = objectUserInfo.email;

                    this.Literal2.Text = "<span>" + objectUserInfo.userlevel + "</span>";
                    this.Literal3.Text = "<span>" + objectUserInfo.createdate + "</span>";
                }
            }
        }

        protected void saveButton1_Click(object sender, EventArgs e)
        {
            modols.UserInfo objectuserinfo = new UserInfo();
            objectuserinfo.account = this.accountTextBox.Text.Trim();
            objectuserinfo.name = this.TextBox1.Text.Trim();
            objectuserinfo.email = this.TextBox2.Text.Trim();
            objectuserinfo.pwd = this.TextBox4.Text.Trim();
            objectuserinfo.userlevel = "1";
            if (this.saveButton1.Text == "Add")
            {
                if (new dal.ServicUser().isexistaccountbyaccount(objectuserinfo.account))
                {
                    this.Literalalter.Text = "<script>alert('帳號已存在，請換一個帳號註冊')</script>";
                    return;
                }
                int result = new dal.ServicUser().adduserinfobyuserinfo(objectuserinfo);
                if (result > 0)
                {
                    Response.Redirect("~/SysadmAdmin/UserList.aspx");
                }
                else
                {
                    this.Literalalter.Text = "<script>alert('增加帳號失敗')</script>";
                    return;
                }

            }
            else
            {//save
              
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            this.Literal3.Text = "<span>" + DateTime.Now.ToString() + "</span>";

        }
    }
}