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
    public partial class PasswordCheck : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadData()
        {

            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM UserProp WHERE Mid=@id";
            da.SelectCommand.Parameters.AddWithValue("@id", Session["Mid"]);
            da.Fill(dt);
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblName.Text = dt.Rows[0]["FullName"].ToString();
            imgProfile.ImageUrl = dt.Rows[0]["Image"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Mid"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void cvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Users WHERE Member_ID=@id AND Password=@pass";
            da.SelectCommand.Parameters.AddWithValue("@id", Session["Mid"].ToString());
            da.SelectCommand.Parameters.AddWithValue("@pass", txtPassword.Text);
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlDataAdapter da = new SqlDataAdapter("", connection);
                DataTable dt = new DataTable();
                da.SelectCommand.CommandText = "SELECT * FROM UsersAndRols WHERE Member_ID=@id AND Password=@pass ";
                da.SelectCommand.Parameters.AddWithValue("@id", Session["Mid"]);
                da.SelectCommand.Parameters.AddWithValue("@pass", txtPassword.Text);
                da.Fill(dt);
                if (dt.Rows[0]["Type"].ToString() == "Admin")
                {
                    Session["Mid2"] = Session["Mid"];
                    Session["UserType"] = dt.Rows[0]["Type"].ToString().ToString();
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }
                if (dt.Rows[0]["Type"].ToString() == "User")
                {
                    dt.Clear();
                    da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid=@mID";
                    da.SelectCommand.Parameters.AddWithValue("@mID", Session["Mid"]);
                    da.Fill(dt);
                    if (Convert.ToInt32(dt.Rows[0]["IsCompeleted"]) == 0)
                    {
                        Session["Mid2"] = Session["Mid"];
                        Response.Redirect("~/User/CompeletInformations.aspx");
                    }

                }

            }
        }
    }
}