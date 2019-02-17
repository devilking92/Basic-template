using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class Registration : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        string queryStr,name,isAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            registerUser();
        }

        int checkboxAdmin = 0;
        private void registerUser()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";

            if(UserAdmin.Checked == true) { checkboxAdmin = Convert.ToInt32(UserAdmin.Checked); }

            queryStr = "INSERT INTO guner_db.registration (userName,password,spec,kurs,admin) VALUE('" + UserName.Text + "','" + Password.Text + "','"+ UserSpec.Text +"','"+ UserKurs.Text + "','"+ checkboxAdmin + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);

            cmd.ExecuteReader();
            con.Close();

            ErrorMessage.Text = "Успешно качени данни";
            UserName.Text = null;
            UserSpec.Text = null;
            UserKurs.Text = null;
            UserAdmin.Checked = false;
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
            }
            else
            {
                this.MasterPageFile = "~/ForUsers.Master";
            }
        }
    }
}