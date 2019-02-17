using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class Login : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string queryStr,name,logAdmin,isAdmin;
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LogIn(object sender, EventArgs e)
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";

            queryStr = "SELECT * FROM guner_db.registration WHERE userName='"+ UserName.Text +"' AND password='"+ Password.Text +"'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);

            reader = cmd.ExecuteReader();
            name = "";

            while (reader.HasRows && reader.Read())
            {
                userID = reader.GetInt32(reader.GetOrdinal("userID"));
                name = reader.GetString(reader.GetOrdinal("userName"));
                isAdmin = Convert.ToString(reader.GetInt32(5));
            }

            if (reader.HasRows)
            {
                Session["userID"] = userID;
                Session["uname"] = name;
                Session["Admin"] = isAdmin;
                Response.BufferOutput = true;
                Response.Redirect("Default.aspx", false);
            }
            else
            {
                LoginErrorMessage.Text = "Invalid user name or password";
            }

            reader.Close();
            con.Close();
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            name = (string)(Session["uname"]);
            logAdmin = (string)(Session["Admin"]);
            if (name == null)
            {
                this.MasterPageFile = "~/ForUsers.Master";
            }
            else if (name != null && logAdmin == "1")
            {
                this.MasterPageFile = "~/SitLoggedIn.Master";
            }
            else if (name != null && logAdmin == "0")
            {
                this.MasterPageFile = "~/Site.Master";
            }
        }
    }
}