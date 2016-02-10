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
    public partial class Fields : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadData()
        {
            db.SelectQueryFillGridView("SELECT * FROM  Fields", grdFields);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
            lblError.Text = string.Empty;
        }

        protected void cvTitle_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Fields WHERE Title = @tl";
            da.SelectCommand.Parameters.AddWithValue("@tl", txtAddTitle.Text);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
                args.IsValid = false;
            else
                args.IsValid = true;

        }

        protected void btnAddCSkill_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAddTitle.Text) || string.IsNullOrWhiteSpace(txtAddTitle.Text))
            {
                lblError.Text = "عنوان را وارد نکرده‌اید!";
            }
            if (Page.IsValid && !(string.IsNullOrEmpty(txtAddTitle.Text) || string.IsNullOrWhiteSpace(txtAddTitle.Text)))
            {
                db.Insert("Fields", "Title", txtAddTitle.Text);
            }
            txtAddTitle.Text = string.Empty;
            LoadData();
        }

        protected void grdFields_RowCommand(object sender, GridViewCommandEventArgs e)
        {   
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "DeleteItem")
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "DELETE FROM Fields WHERE ID =@id";
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
            if (e.CommandName == "EditItem")
            {
                Response.Redirect("EditField.aspx?Fid=" + id);
            }
        }

        protected void grdFields_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdFields.PageIndex = e.NewPageIndex;
            db.SelectQueryFillGridView("SELECT * FROM Fields",grdFields);
        }
    }
}