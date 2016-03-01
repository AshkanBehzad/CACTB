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
            da.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["id"]);
            da.Fill(dt);
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblName.Text = dt.Rows[0]["FullName"].ToString();
            if (string.IsNullOrEmpty(dt.Rows[0]["ImageExtention"].ToString()) || string.IsNullOrWhiteSpace(dt.Rows[0]["ImageExtention"].ToString()))
            {
                imgProfile.ImageUrl = "~/MyFiles/user.png";
            }
            else
                imgProfile.ImageUrl = dt.Rows[0]["Image"].ToString() + dt.Rows[0]["ImageExtention"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
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
            da.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
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
                da.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["id"].ToString());
                da.SelectCommand.Parameters.AddWithValue("@pass", txtPassword.Text);
                da.Fill(dt);
                SqlDataAdapter sd = new SqlDataAdapter("SELECT * FROM Members WHERE ID=@memID", connection);
                DataTable dl = new DataTable();
                sd.SelectCommand.Parameters.AddWithValue("@memID", Request.QueryString["id"]);
                sd.Fill(dl);
                Session["UserType"] = dt.Rows[0]["Type"].ToString();
                Session["Mid"] = Request.QueryString["id"];
                if (Convert.ToInt32(dl.Rows[0]["IsCompeleted"]) == 0)
                {
                    Response.Redirect("~/User/CompeletInformations.aspx");
                }
                else
                {
                    if (dt.Rows[0]["Type"].ToString() == "User")
                        Response.Redirect("~/User/profile.aspx");
                    if (dt.Rows[0]["Type"].ToString() == "Admin")
                        Response.Redirect("~/Admin/DashBoard.aspx");
                }
            }
        }

        protected void lbtnForgotPass_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Members WHERE ID = @mid";
            da.SelectCommand.Parameters.AddWithValue("@mid", Session["Mid"]);
            da.Fill(dt);
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandText = "UPDATE Users SET Password=@newPass WHERE Member_ID=@memID";
            cmd.Parameters.AddWithValue("@newPass", dt.Rows[0]["NationalID"].ToString());
            cmd.Parameters.AddWithValue("@memID", Session["Mid"]);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MailService.SendMail("عضو گرامی\nبا سلام\nرمز عبور شما به کد ملی شما تغییر یافت\nبرای امنیت بیشتر بعد ورود به پروفایل شخصی خود رمز عبور را تغییر دهید\nبا تشکر \nانجمن علمی مهندسی کامپیوتر", "درخواست بازیابی رمز عبور", dt.Rows[0]["Email"].ToString());
            Response.Write("<script>alert(\"ایمیل خود را چک کنید\")</script>");

        }
    }
}
