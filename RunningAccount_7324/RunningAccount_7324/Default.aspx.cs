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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               data objectdata= new dal.ServicUser().getdate();
                this.Literal1.Text = "<I class='badge badge-dark'>" + objectdata.firstuse+"</I>";
                this.Literal2.Text= "<I class='badge badge-dark'>" + objectdata.lastuse +"</I>";
                this.Literal3.Text= "<I class='badge badge-dark'>" + objectdata.usecount+"</I>";
                this.Literal4.Text= "<I class='badge badge-dark'>" + objectdata.userallcount+"</I>";
            }
        }
    }
}
