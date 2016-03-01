using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.Admin
{
    public partial class SkillRequests : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadData()
        {
            db.SelectQueryFillGridView("SELECT * FROM SkillReq", grdSkills);
             lblCount.Text = db.Count("SkillReq", "ID").ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        protected void grdSkills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "DeleteItem")
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "DELETE FROM SkillRequest WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
            else

                Response.Redirect("EditSkillRequest.aspx?srid=" + id);
        }

        protected void grdSkills_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {

        }
    }
}