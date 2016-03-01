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
    public partial class SkillVal : System.Web.UI.Page
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
            da.SelectCommand.CommandText = "SELECT * FROM MemberSkillList WHERE Member_ID = @mid";
            da.SelectCommand.Parameters.AddWithValue("@mid",Session["Mid"]);
            da.Fill(dt);
            grdSkill.DataSource = dt;
            grdSkill.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdSkill.Rows)
            {
                DropDownList ddlVal = (DropDownList)row.FindControl("ddlVal");
                if (ddlVal != null)
                {
                    var dataKey = grdSkill.DataKeys[row.RowIndex];
                    if (dataKey != null)
                    {
                        string msid = dataKey.Value.ToString();
                        SqlCommand cmd = new SqlCommand("", connection);
                        cmd.CommandText = "UPDATE MembersSkills SET Value=@val WHERE ID=@msid";
                        cmd.Parameters.AddWithValue("@val",ddlVal.SelectedValue);
                        cmd.Parameters.AddWithValue("@msid", msid);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                    }

                }
            }
            Response.Redirect("SocialNets.aspx");
        }
    }
}