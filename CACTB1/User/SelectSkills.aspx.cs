using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.User
{
    public partial class SelectSkills : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();

        public void LoadData()
        {
            db.SelectQueryFillGridView("SELECT * FROM SkillList", grdSkills);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in grdSkills.Rows)
            {
                CheckBox ch = (CheckBox)row.FindControl("ckbSkills");
                if (ch != null && ch.Checked)
                {
                    var dataKey = grdSkills.DataKeys[row.RowIndex];
                    if (dataKey != null)
                    {
                        string sid = dataKey.Value.ToString();
                        SqlCommand cmd = new SqlCommand("",connection);
                        cmd.CommandText = "INSERT INTO MembersSkills(Member_ID,Skill_ID,Date) VALUES(@mid,@sid,@date)";
                        cmd.Parameters.AddWithValue("@mid",Session["Mid"]);
                        cmd.Parameters.AddWithValue("@sid",sid);
                        cmd.Parameters.AddWithValue("@date",PersianDateConverter.GetDate());
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
        }
    }
}