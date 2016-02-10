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

namespace CACTB1.Admin
{
    public partial class EditSkillCategory : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();

        public void LoadData()
        {
            string id = Request.QueryString["Sid"].ToString();
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE ID = @idsc";
            da.SelectCommand.Parameters.AddWithValue("@idsc", id);
            da.Fill(dt);
            txtTitle.Text = dt.Rows[0]["Title"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Sid"] != null)
                {
                    SqlDataAdapter da = new SqlDataAdapter("", connection);
                   
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE ID=@Sid2";
                    da.SelectCommand.Parameters.AddWithValue("@Sid2", Request.QueryString["Sid"]);
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        Response.Redirect("SkilsCategory.aspx");
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
            if (Request.QueryString["Sid"] == null)
            {
                Response.Redirect("SkilsCategory.aspx");
            }






        }

        protected void cvTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            DataTable dl = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE ID = @sxid";
            da.SelectCommand.Parameters.AddWithValue("@sxid", Request.QueryString["Sid"]);
            da.Fill(dl);
            if (dl.Rows[0]["Title"].ToString() != txtTitle.Text)
            {
                da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE Title = @title ";
                da.SelectCommand.Parameters.AddWithValue("@title", txtTitle.Text);
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string id = Request.QueryString["Sid"].ToString();
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "UPDATE SkillCategory SET Title=@title,Description=@des WHERE ID=@sid";
                cmd.Parameters.AddWithValue("@title", txtTitle.Text);
                cmd.Parameters.AddWithValue("@des", txtDescription.Text);
                cmd.Parameters.AddWithValue("@sid", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("SkilsCategory.aspx");
            }
        }
    }
}