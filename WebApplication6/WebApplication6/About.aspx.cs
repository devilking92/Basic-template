using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class About : Page
    {
        string name, isAdmin;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            name = (string)(Session["uname"]);
            isAdmin = (string)(Session["Admin"]);
            if (name == null)
            {
                this.MasterPageFile = "~/ForUsers.Master";
            }
            else if ((name != null) && (isAdmin == "1"))
            {
                this.MasterPageFile = "~/SitLoggedIn.Master";
            }
            else if ((name != null) && (isAdmin == "0"))
            {
                this.MasterPageFile = "~/Site.Master";
            }else
            {
                this.MasterPageFile = "~/ForUsers.Master";
            }
        }
    }
}