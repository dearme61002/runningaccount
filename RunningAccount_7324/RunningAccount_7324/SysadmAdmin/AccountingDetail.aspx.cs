using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using modols;
using dal;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace RunningAccount_7324.backendweb
{
    public partial class WebForm3 : System.Web.UI.Page
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
                string type = Request.QueryString["type"].ToString();
                if (type == "0")
                {
                    saveButton1.Text = "Add";
                    this.deleteButton2.Visible = false;
                }
                else
                {
                    this.deleteButton2.Visible = true;
                    SqlDataReader sr = new dal.ServicUser().getnotebyid(Convert.ToInt32(Request.QueryString["id"]));
                    try
                    {
                        if (sr.Read())
                        {
                            this.TextBox1.Text = sr["Amount"].ToString();
                            this.TextBox2.Text = sr["Caption"].ToString();
                            this.TextBox3.Text = sr["Body"].ToString();
                            this.DropDownList1.SelectedItem.Value = sr["ActType"].ToString();
                        }
                        else
                        {
                            this.Literal1.Text = "讀取資料錯誤";
                        }
                        sr.Close();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

                //傳資料

            }
        }

        protected void saveButton1_Click(object sender, EventArgs e)
        {
            //date can use
            Regex rgx = new Regex(@"^[0-9]*$");
            Regex rgx2 = new Regex(@"^[\u4E00-\u9FA5A-Za-z0-9_]+$");
            if (TextBox1.Text.Trim() == "" || !(rgx.IsMatch(TextBox1.Text.Trim())))
            {
                this.Literal2.Text = "<strong>只能輸入數字且不能為空</strong>";
                return;
            }
            if (!rgx2.IsMatch(TextBox2.Text.Trim()) || TextBox2.Text.Trim()=="")
            {
                this.Literal3.Text= "<strong>不能為空</strong>";
                return;
            }
            //date can use

            modols.AccountNote objectaccountNote = new modols.AccountNote();
            objectaccountNote.acttype = this.DropDownList1.SelectedItem.Value;
            objectaccountNote.amount = Convert.ToInt32(this.TextBox1.Text.Trim());
            objectaccountNote.caption = this.TextBox2.Text.Trim();
            objectaccountNote.body = this.TextBox3.Text.Trim();
            modols.UserInfo userInfo = (modols.UserInfo)Session["currentuser"];
            objectaccountNote.userid = userInfo.id;
           
                if (saveButton1.Text == "Add")
            {
                int result = new dal.ServicUser().addnotebyobjectAccountNote(objectaccountNote);
                if (result > 0)
                {
                    Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
                }
                else
                {
                    this.Literal1.Text = "加入資料失敗請重新開啟網站";
                }

            }
            else
            {
                try
                {
                    int result = new dal.ServicUser().updatenotebyobjectAccountNote(objectaccountNote, Convert.ToInt32(Request.QueryString["id"]));
                    if (result > 0)
                    {
                        Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
                    }
                    else
                    {
                        this.Literal1.Text = "修改資料失敗請重新開啟網站";
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/UserInfo.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/UserList.aspx");
        }

        protected void deleteButton2_Click(object sender, EventArgs e)
        {
          int result=  new dal.ServicUser().delectnotebyid(Convert.ToInt32(Request.QueryString["id"]));
            if (result >0){
                Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
            }else
            {
                this.Literal1.Text = "刪除資料失敗請重新開啟網站";
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
        }
    }
}