using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.User
{
    public partial class SocialNets : System.Web.UI.Page
    {
        //Get Connection String From Web.congig
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandText = "UPDATE Members SET Linkedin=@linkedin,Github=@git,Twitter=@twitter WHERE ID=@mid";
            cmd.Parameters.AddWithValue("@linkedin", txtLinedin.Text);
            cmd.Parameters.AddWithValue("@git", txtGit.Text);
            cmd.Parameters.AddWithValue("@twitter", txtTwitter.Text);
            cmd.Parameters.AddWithValue("@mid", Session["Mid"]);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "UPDATE Members SET IsCompeleted=1 WHERE ID = @mid";
            cmd.Parameters.AddWithValue("@mid", Session["Mid"]);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("WorkExp.aspx");
        }
    }
}