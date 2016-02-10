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
    public partial class EditField : System.Web.UI.Page
    {
        //Get Connection String From Web.config
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        public void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Fields WHERE ID=@fid";
            da.SelectCommand.Parameters.AddWithValue("@fid", Request.QueryString["Fid"]);
            da.Fill(dt);
            txtTitle.Text = dt.Rows[0]["Title"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Fid"] != null)
                {
                    SqlDataAdapter da = new SqlDataAdapter("", connection);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandText = "SELECT * FROM Fields WHERE ID=@fid2";
                    da.SelectCommand.Parameters.AddWithValue("@fid2", Request.QueryString["Fid"]);
                    da.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        Response.Redirect("Fields.aspx");
                    }
                    else
                    {
                        LoadData();
                    }
                }
            }
            if (Request.QueryString["Fid"] == null)
            {
                Response.Redirect("Fields.aspx");
            }

        }
        protected void cvTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            DataTable dl = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Fields WHERE ID = @id";
            da.SelectCommand.Parameters.AddWithValue("@id", Request.QueryString["Fid"]);
            da.Fill(dl);
            if (dl.Rows[0]["Title"].ToString() != txtTitle.Text)
            {
                da.SelectCommand.CommandText = "SELECT * FROM Fields WHERE Title= @tl";
                da.SelectCommand.Parameters.AddWithValue("@tl", txtTitle.Text);
                da.Fill(dt);
                if (dt.Rows.Count != 0)
                    args.IsValid = false;
                else
                    args.IsValid = true;
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("",connection);
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Fields WHERE ID=@Fid";
            da.SelectCommand.Parameters.AddWithValue("@Fid",Request.QueryString["Fid"]);
            da.Fill(dt);
            if (dt.Rows[0]["Title"].ToString() != txtTitle.Text)
            {
                cmd.CommandText = "UPDATE Fields SET Title = @tlt WHERE ID=@Fid2";
                cmd.Parameters.AddWithValue("@tlt",txtTitle.Text);
                cmd.Parameters.AddWithValue("@Fid2",Request.QueryString["Fid"]);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                Response.Redirect("Fields.aspx");
            }
        }
    }
}