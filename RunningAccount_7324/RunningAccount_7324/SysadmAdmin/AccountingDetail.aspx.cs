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
                this.Literal1.Text = "<span class='text-white'>歡迎你的登入"+ userInfo.name +"先生/小姊</span>";
                string type = Request.QueryString["type"].ToString();
                if (type == "0")
                {
                    saveButton1.Text = "Add";
                }
                //傳資料
              
            }
        }

        protected void saveButton1_Click(object sender, EventArgs e)
        {
            modols.AccountNote objectaccountNote = new modols.AccountNote();
            objectaccountNote.acttype= this.DropDownList1.SelectedItem.Value;
            objectaccountNote.amount = Convert.ToInt32(this.TextBox1.Text.Trim()) ;
            objectaccountNote.caption = this.TextBox2.Text.Trim();
            objectaccountNote.body = this.TextBox3.Text.Trim();
            modols.UserInfo userInfo = (modols.UserInfo)Session["currentuser"];
            objectaccountNote.userid = userInfo.id;
            if (saveButton1.Text== "Add")
            {
             int  result= new dal.ServicUser().addnotebyobjectAccountNote(objectaccountNote);
                if (result > 0)
                {
                    Response.Redirect("~/SysadmAdmin/AccountingList.aspx");
                }
                else
                {
                    this.Literal1.Text = "加入資料失敗請重新增加";
                }

            }
        }
    }
}