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
    public partial class MemberStats : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadData()
        {
            int id = Convert.ToInt32(Session["Mid"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid = @id";
            da.SelectCommand.Parameters.AddWithValue("@id", id);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lblName.Text = dt.Rows[0]["FirstName"].ToString() + "   " + dt.Rows[0]["LastName"].ToString();
            lblField.Text = dt.Rows[0]["Title"].ToString();
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();

        }

        protected void btnSaveEditedName_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["Mid"].ToString());
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandText = "UPDATE Members SET FirstName=@fn,LastName=@ln WHERE ID= @id ";
            cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@ln", txtLastName.Text);
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            LoadData();

        }

        protected void btnEditfield_Click(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(Session["Mid"].ToString());
            SqlCommand cmd = new SqlCommand("", connection);
            cmd.CommandText = "UPDATE Members SET Fielde_ID =@fid WHERE ID= @id ";
            cmd.Parameters.AddWithValue("@fid", ddlField.SelectedValue);
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            LoadData();
        }
    }
}