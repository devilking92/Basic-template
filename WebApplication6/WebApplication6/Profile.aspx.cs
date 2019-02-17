using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        string queryStr, name, isAdmin;
        int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewInfo();
                UpdateCorrect.Visible = false;
                UpdateError.Visible = false;
            }
        }

        protected void Page_PreInit(Object sender, EventArgs e)
        {
            name = (string)(Session["uname"]);
            isAdmin = (string)(Session["Admin"]);
            if (name == null)
            {
                this.MasterPageFile = "~/ForUsers.Master";
            }
            else if (name != null && isAdmin == "1")
            {
                this.MasterPageFile = "~/SitLoggedIn.Master";
            }
            else if (name != null && isAdmin == "0")
            {
                this.MasterPageFile = "~/Site.Master";
            }
        }

        public void ViewInfo()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";
            userID = (Int32)(Session["userID"]);
            queryStr = "SELECT userName,spec,kurs FROM guner_db.registration WHERE userID='" + userID + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);
            MySql.Data.MySqlClient.MySqlDataReader reader = null;
            reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                UserName.Text = reader["userName"].ToString();
                UserSpec.Text = reader["spec"].ToString();
                UserKurs.Text = reader["kurs"].ToString();
            }
            con.Close();
        }

        protected void UpdateUser_Click(object sender, EventArgs e)
        {
            userID = (Int32)(Session["userID"]);
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";
            queryStr = "UPDATE guner_db.registration SET userName='"+ UserName.Text +"',spec='"+ UserSpec.Text +"',kurs='"+ UserKurs.Text +"' WHERE userID='"+ userID +"'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);

            try
            {
                cmd.ExecuteNonQuery();
                con.Close();
                UpdateCorrect.Visible = true;
                UpdateCorrect.Text = "Успешно обновени данни";
            }
            catch
            {
                UpdateError.Visible = true;
                UpdateError.Text = "Неуспешно обновяване на данните";
            }
            
        }
    }
}