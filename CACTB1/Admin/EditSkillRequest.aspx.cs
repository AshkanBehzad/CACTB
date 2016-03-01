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
    public partial class EditSkillRequest : System.Web.UI.Page
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
            da.SelectCommand.CommandText = "SELECT * FROM SkillRequest WHERE ID = @srid";
            da.SelectCommand.Parameters.AddWithValue("@srid", Request.QueryString["srid"]);
            da.Fill(dt);
            txtTitle.Text = dt.Rows[0]["Title"].ToString();
            txtDescription.Text = dt.Rows[0]["Description"].ToString();
            db.SelectQueryFillDropDownList("SELECT * FROM SkillCategory", ddlSkillCat, "Title", "ID");
            da.SelectCommand.Parameters.Clear();
            dt.Clear();
            da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE Title = \'متفرقه\' ";
            da.Fill(dt);
            if (dt.Rows.Count != 0)
                ddlSkillCat.SelectedValue = dt.Rows[0]["ID"].ToString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("",connection);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandText = "INSERT INTO Skills(Title,Description,Cat_ID,Req) VALUES(@tl,@des,@cat,@req)";
            cmd.Parameters.AddWithValue("@tl", txtTitle.Text);
            cmd.Parameters.AddWithValue("@des", txtDescription.Text);
            cmd.Parameters.AddWithValue("@cat", ddlSkillCat.SelectedValue);
            cmd.Parameters.AddWithValue("@req",Request.QueryString["srid"] );
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            cmd.Parameters.Clear();
            cmd.CommandText = "INSERT INTO MembersSkills(Member_ID,Skill_ID,Date) VALUES(@mid,@sid,@date)";
            da.SelectCommand.CommandText = "SELECT * FROM SkillRequest WHERE ID = @srid";
            da.SelectCommand.Parameters.AddWithValue("@srid", Request.QueryString["srid"]);
            da.Fill(dt);
            cmd.Parameters.AddWithValue("@mid", dt.Rows[0]["Member_ID"] );
            da.SelectCommand.Parameters.Clear();
            dt.Clear();
            da.SelectCommand.CommandText = "SELECT * FROM Skills WHERE Req = @req";
            da.SelectCommand.Parameters.AddWithValue("@req", Request.QueryString["srid"]);
            da.Fill(dt);
            cmd.Parameters.AddWithValue("@sid", dt.Rows[0]["ID"]);
            da.SelectCommand.Parameters.Clear();
            dt.Clear();
            //cmd.Parameters.AddWithValue("@val", );
            cmd.Parameters.AddWithValue("@date", PersianDateConverter.GetDate());
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            cmd.Parameters.Clear();
            da.SelectCommand.Parameters.Clear();
            dt.Clear();
            cmd.CommandText = "DELETE FROM SkillRequest WHERE ID=@id";
            cmd.Parameters.AddWithValue("@id",Request.QueryString["srid"]);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("SkillRequests.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("",connection);
            cmd.CommandText = "DELETE FROM SkillRequest WHERE ID=@id";
            cmd.Parameters.AddWithValue("@id", Request.QueryString["srid"]);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            Response.Redirect("SkillRequests.aspx");
        }
    }
}