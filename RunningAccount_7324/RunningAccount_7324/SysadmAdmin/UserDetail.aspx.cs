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
                    //顯示資料
                    modols.UserInfo objectUserInfo = new dal.ServicUser().getUserbyuserid(Request.QueryString["id"].ToString());
                    if (objectUserInfo == null)
                    {
                        this.Literalalter.Text = "<script>alert('跟改帳號失敗')</script>";
                        return;
                    }
                      this.DropDownList1Literalchangelevel.Visible = true;
                     this.accountTextBox.Text = objectUserInfo.account;
                    this.accountTextBox.Enabled = false;
                    this.TextBox1.Text = objectUserInfo.name;
                    this.TextBox2.Text = objectUserInfo.email;
                    if (objectUserInfo.userlevel == "一般會員")
                    {

                        this.DropDownList1Literalchangelevel.SelectedValue = "1";
                    }
                    else if (objectUserInfo.userlevel == "管理員")
                    {
                       
                        this.DropDownList1Literalchangelevel.SelectedValue = "0";
                    }

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
          
            if (this.saveButton1.Text == "Add")
            {
                objectuserinfo.userlevel = "1";
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
                modols.UserInfo userlevelismanger = (modols.UserInfo)Session["currentuser"];
                if (userlevelismanger.userlevel == "1")
                {
                    this.Literalalter.Text = "<script>alert('權限不足無法，請更換請換管里長帳號登入')</script>";
                    return;
                };
                objectuserinfo.userlevel = this.DropDownList1Literalchangelevel.SelectedValue;
                    int result=  new dal.ServicUser().updateuserinfobyobjecInfo(objectuserinfo, Request.QueryString["id"].ToString());
                if (result > 0)
                {
                    Response.Redirect("~/SysadmAdmin/UserList.aspx");
                }
                else
                {
                    this.Literalalter.Text = "<script>alert('修改帳號失敗')</script>";
                    return;
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {

            this.Literal3.Text = "<span>" + DateTime.Now.ToString() + "</span>";

        }

        protected void deleteButton2_Click(object sender, EventArgs e)
        {
          int result=  new dal.ServicUser().deleteinfobyID(Request.QueryString["id"].ToString());
            if (result > 0)
            {
                Response.Redirect("~/SysadmAdmin/UserList.aspx");
            }
            else
            {
                this.Literalalter.Text = "<script>alert('修改帳號失敗')</script>";
                return;
            }
        }

        protected void PSWButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SysadmAdmin/UserPassword.aspx?id="+ Request.QueryString["id"].ToString());
        }
    }
}