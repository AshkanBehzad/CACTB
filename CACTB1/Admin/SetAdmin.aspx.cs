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
    public partial class SetAdmin : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void LoadSearchedData()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandText = "SearchedMemberList";
            da.SelectCommand.Parameters.AddWithValue("@Type", "User");
            if (txtName.Text != string.Empty)
            {
                da.SelectCommand.Parameters.AddWithValue("@Name", txtName.Text);
            }
            if (txtMemberID.Text != string.Empty)
            {
                da.SelectCommand.Parameters.AddWithValue("@Mid", txtMemberID.Text);
            }
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                grdUserSearched.DataSource = dt;
                grdUserSearched.DataBind();
            }
        }
        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadSearchedData();
        }

        protected void grdUserSearched_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "SetAdmin")
            {
                SqlDataAdapter da = new SqlDataAdapter("", connection);
                DataTable dt = new DataTable();
                da.SelectCommand.CommandText = "SELECT * FROM Rols WHERE Type = 'Admin'";
                da.Fill(dt);
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "UPDATE Users SET Type_ID=@typeID WHERE Member_ID=@mid";
                cmd.Parameters.AddWithValue("@typeID", dt.Rows[0]["ID"]);
                cmd.Parameters.AddWithValue("@mid", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                grdUserSearched.DataBind();
            }
        }

        //protected void cvNameCheck_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataTable dt = new DataTable();
        //    da.SelectCommand.CommandText = "SELCT * FROM U";
        //}
    }
}