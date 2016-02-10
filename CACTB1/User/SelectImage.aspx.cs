using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.User
{
    public partial class SelectImage : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        public void LoadImage()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM UserProp  WHERE Mid=@mid";
            da.SelectCommand.Parameters.AddWithValue("@mid", Session["Mid"]);
            da.Fill(dt);
            if (string.IsNullOrEmpty(dt.Rows[0]["ImageExtention"].ToString()) || string.IsNullOrWhiteSpace(dt.Rows[0]["ImageExtention"].ToString()))
            {
                imgProfile.ImageUrl = "~/MyFiles/user.png";
            }
            else
                imgProfile.ImageUrl = dt.Rows[0]["Image"].ToString() + dt.Rows[0]["ImageExtention"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Mid"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadImage();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            string mid = Session["Mid"].ToString();
            string upFileName = fuProlileImage.FileName;
            string folderName = "~/ProfileImages/";
            string fileName = mid.ToString();
            string extension = Path.GetExtension(upFileName);
            string filePath = folderName + fileName + extension;
            if (File.Exists(folderName + fileName))
            {
                File.Delete(folderName + fileName);
                fuProlileImage.SaveAs(Server.MapPath(filePath));
            }
            else
                fuProlileImage.SaveAs(Server.MapPath(filePath));
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandText = "UPDATE Members SET Image=@img,ImageExtention=@ex WHERE ID=@mid";
            cmd.Parameters.AddWithValue("@img", folderName + fileName);
            cmd.Parameters.AddWithValue("@ex", extension);
            cmd.Parameters.AddWithValue("@mid", mid);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            LoadImage();
            Session["Mid"] = Session["Mid"];
            Response.Redirect("SelectSkill.aspx");
        }

        protected void btnIgnore_Click(object sender, EventArgs e)
        {
            Session["Mid"] = Session["Mid"];
            Response.Redirect("SelectSkill.aspx");
        }
    }
}