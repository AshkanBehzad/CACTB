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
    public partial class Login : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cvUsername_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("",connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Users WHERE Member_ID=@un";
            da.SelectCommand.Parameters.AddWithValue("@un",txtUserName.Text);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Session["Mid"] = txtUserName.Text;
                Response.Redirect("~/PasswordCheck.aspx");
            }
        }
    }
}