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
    public partial class WebForm2 : System.Web.UI.Page
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
                this.Literal2.Text = "<span class='text-black'>歡迎你的登入" + userInfo.name + "先生/小姊</span>";
                //傳資料
           List<modols.AccountNote>  objectallaccountNote=new dal.ServicUser().getAccountallNotebyuserid(userInfo.id);
                if (objectallaccountNote != null)
                {
                    this.GridView1.DataSource = objectallaccountNote;
                    this.GridView1.DataBind();
                    int allcount = 0;
                    foreach (var item in objectallaccountNote)
                    {
                        allcount += item.amount;
                    }
                    this.Literal1.Text ="<span>"+allcount+"</span>" ;
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

        protected void AddButton1_Click(object sender, EventArgs e)
        {
            modols.UserInfo userInfo = (modols.UserInfo)Session["currentuser"];
            Response.Redirect("~/SysadmAdmin/AccountingDetail.aspx?id="+userInfo.id+"&type=0");
        }
    }
}