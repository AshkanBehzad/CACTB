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
        //Get ConnectionString From WEb.config
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
                LoadData();
            //Handle null QueryString
            if (Request.QueryString["Sid"] == null)
            {
                Response.Redirect("SkilsCategory.aspx");
            }
        }
        //Validation > 
        protected void cvTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            DataTable dl = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE ID = @sxid";
            da.SelectCommand.Parameters.AddWithValue("@sxid", Request.QueryString["Sid"]);
            da.Fill(dl);
            //Consept : Check if TextBox' value has changed or not
            //If This part doesn't Exist -> the page won't be valid Because of the next part of Validation. WHY? ...
            //if the title isn't changed the next part cause invalidation beacuse the Title has already Exist
            if (dl.Rows[0]["Title"].ToString() != txtTitle.Text)
            {
                da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE Title = @title ";
                da.SelectCommand.Parameters.AddWithValue("@title", txtTitle.Text);
                da.Fill(dt);
                //If the TextBox' Value has changed ...
                //So , Now Check if The New Value has already Exist in Table or not
                if (dt.Rows.Count != 0)
                {
                    args.IsValid = false;
                }
                else
                    args.IsValid = true;
            }
        }
        //Update table if page isValid
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