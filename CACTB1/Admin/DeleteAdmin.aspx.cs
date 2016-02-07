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
    public partial class DeleteAdmin : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadSearchedData()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandText = "SearchedMemberList";
            da.SelectCommand.Parameters.AddWithValue("@Type", "Admin");
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtName_TextChanged(object sender, EventArgs e)
        {
            LoadSearchedData();
        }

        protected void grdUserSearched_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "DeleteAdmin")
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "UPTADE Users SET Type_ID=@type AND Member_ID=@mid";
                cmd.Parameters.AddWithValue("@type", db.SelectQueryFillDataTable("SELECT * FROM Rols R WHERE R.[Type] = N'Admin'", 0, "Type"));
                cmd.Parameters.AddWithValue("@mid", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}