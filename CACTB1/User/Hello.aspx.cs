using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.User
{
    public partial class Hello : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["MMID"] != null || Request.QueryString["MPASS"] != null)
            {
                SqlDataAdapter da = new SqlDataAdapter("",connection);
                DataTable dt = new DataTable();
                da.SelectCommand.CommandText = "SELECT * FROM Users WHERE Member_ID = @mid AND Password = @pass";
                da.SelectCommand.Parameters.AddWithValue("@mid",Request.QueryString["MMID"]);
                da.SelectCommand.Parameters.AddWithValue("@pass",Request.QueryString["MPASS"]);
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    Session["Mid"] = Request.QueryString["MMID"];
                    Response.Redirect("~/User/CompeletInformations.aspx");
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

        }
    }
}