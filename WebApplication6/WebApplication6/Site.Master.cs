﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class SiteMaster : MasterPage
    {
        string name;
        protected void Page_Load(object sender, EventArgs e)
        {
            name = (string)(Session["uname"]);
            userLabel1.Text = name;
        }
    }
}