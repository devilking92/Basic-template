using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace WebApplication6
{
    public partial class _Default : Page
    {
        MySql.Data.MySqlClient.MySqlConnection con;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        string queryStr, name, isAdmin;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SliderLabelMessage.Visible = false;
                GetImage();
                ImgShow();
            }
        }

        public void GetImage()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";

            queryStr = "SELECT imgName, imgHeader, imgContent FROM guner_db.sliderimage";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);

            DataTable dt = new DataTable();
            
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            da.Fill(dt);
            if (dt.Rows.Count > 0 && (string)dt.Rows[0][0] != string.Empty)
            {
                rpt.DataSource = dt;
                rpt.DataBind();
            }
            else
            {
                rpt.DataSource = null;
                rpt.DataBind();
            }
        }

        protected void SliderBtnImgUpload(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = SliderImgUpload.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(fileName);
            int fileSize = postedFile.ContentLength;

            if (fileExtension.ToLower() == ".jpg"
                || fileExtension.ToLower() == ".jpeg"
                || fileExtension.ToLower() == ".png"
                || fileExtension.ToLower() == ".bmp"
                || fileExtension.ToLower() == ".gif")
            {
                Stream stream = postedFile.InputStream;
                BinaryReader binaryReader = new BinaryReader(stream);
                byte[] bytes = binaryReader.ReadBytes((int)stream.Length);

                string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

                con = new MySql.Data.MySqlClient.MySqlConnection(conString);
                con.Open();
                queryStr = "";

                queryStr = "INSERT INTO guner_db.sliderimage (imgName,imgSize,imgData,imgHeader,imgContent) VALUE('" + fileName + "','" + fileSize + "','" + fileExtension + "','"+ imgHeaderBox.Text +"','"+ imgContentBox.Text +"')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);

                cmd.ExecuteReader();
                con.Close();

                SliderImgUpload.SaveAs(Server.MapPath("~/Content/Images/") + fileName);

                SliderLabelMessage.Visible = true;
                SliderLabelMessage.Text = "Успешно";
                SliderLabelMessage.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                SliderLabelMessage.Visible = true;
                SliderLabelMessage.Text = "Само файлове с разширение (.jpg, .jpeg, .png, .bmp, .gif)";
                SliderLabelMessage.ForeColor = System.Drawing.Color.Red;
            }
            ImgShow();
            GetImage();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Label l1 = GridView1.Rows[e.RowIndex].FindControl("imgLabelID") as Label;
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";

            queryStr = "DELETE FROM guner_db.sliderimage WHERE imgID=@id1";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);
            cmd.Parameters.AddWithValue("@id1", l1.Text);
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            ImgShow();
            GetImage();
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

        void ImgShow()
        {
            string conString = System.Configuration.ConfigurationManager.ConnectionStrings["WebAppConString"].ToString();

            con = new MySql.Data.MySqlClient.MySqlConnection(conString);
            con.Open();
            queryStr = "";

            queryStr = "SELECT imgID,imgName FROM guner_db.sliderimage";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, con);
       
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySql.Data.MySqlClient.MySqlDataAdapter da = new MySql.Data.MySqlClient.MySqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            con.Close();
        }
    }
}