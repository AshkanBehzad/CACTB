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
    public partial class WorkExp : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public bool IsTextBoxValid()
        {
            return txtCoName.Text == string.Empty || string.IsNullOrEmpty(txtCoName.Text) || string.IsNullOrWhiteSpace(txtCoName.Text) ||
                txtDutation.Text == string.Empty || string.IsNullOrEmpty(txtDutation.Text) || string.IsNullOrWhiteSpace(txtDutation.Text);
        }
        public void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM WorkExperience WHERE Member_ID=@mmid";
            da.SelectCommand.Parameters.AddWithValue("@mmid", Session["Mid"]);
            da.Fill(dt);
            dlSavedExps.DataSource = dt;
            dlSavedExps.DataBind();

        }
        public void ClearForm()
        {
            txtCoName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtDutation.Text = string.Empty;
            ddlType.SelectedValue = "0";
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ddlType.SelectedIndex != 0 && !IsTextBoxValid())
            {
                lblWarn.Visible = false;
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "INSERT INTO WorkExperience(Member_ID,CompanyName,Type,Duration,Details) VALUES(@mid,@cName,@type,@duration,@des)";
                cmd.Parameters.AddWithValue("@mid", Session["Mid"]);
                cmd.Parameters.AddWithValue("@cName", txtCoName.Text);
                cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue);
                cmd.Parameters.AddWithValue("@duration", txtDutation.Text);
                cmd.Parameters.AddWithValue("@des", txtDescription.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
                ClearForm();
            }
            else
                lblWarn.Visible = true;
        }
        protected void btnNext_Click1(object sender, EventArgs e)
        {
                Response.Redirect("profile.aspx");
        }
        protected void dlSavedExps_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "DeleteItem")
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "DELETE FROM WorkExperience WHERE ID=@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
        }
    }
}