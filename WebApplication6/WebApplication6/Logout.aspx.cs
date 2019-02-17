using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["uname"] = null;
            Session["Admin"] = null;
            Session.Abandon();
            Response.BufferOutput = false;
            Response.Redirect("Default.aspx", false);
        }
    }
}