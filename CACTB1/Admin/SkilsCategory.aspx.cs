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
    public partial class SkilsCategory : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        private int sid;
        public int Sid
        {
            get
            {
                return sid;
            }

            set
            {
                sid = value;
            }
        }

        public void LoadData()
        {
            db.SelectQueryFillGridView("SELECT * FROM SkillCategory", grdSkillCat);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
            if (IsPostBack)
                lblErrorMes.Text = string.Empty;
        }

        protected void grdSkillCat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                string id = e.CommandArgument.ToString();

                if (e.CommandName == "DeleteItem")
                {
                    SqlDataAdapter da = new SqlDataAdapter("", connection);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandText = "SELECT * FROM Skills WHERE Cat_ID = @catID";
                    da.SelectCommand.Parameters.AddWithValue("@catID", id);
                    da.Fill(dt);
                    ; if (dt.Rows.Count != 0)
                    {
                        //alert
                        lblErrorMes.Text = " دانشی در این دسته‌بندی وجود دارد.ابتدا دانش مورد نظر را حذف کیند.";
                    }
                    else
                    {

                        SqlCommand cmd = new SqlCommand("", connection);

                        cmd.CommandText = "DELETE FROM SkillCategory WHERE ID=@id";
                        cmd.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        LoadData();
                    }
                }
                else if (e.CommandName == "EditItem")
                {
                    Response.Redirect("EditSkillCategory.aspx?Sid=" + id);
                }
            }
            catch (Exception)
            {
            }
        }


        protected void btnAddCat_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && !(string.IsNullOrWhiteSpace(txtAddTitle.Text) || string.IsNullOrEmpty(txtAddTitle.Text)))
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO SkillCategory(Title,Description) VALUES(@T,@D)", connection);
                cmd.Parameters.AddWithValue("@T", txtAddTitle.Text);
                cmd.Parameters.AddWithValue("@D", txtAddDescription.Text);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
                txtAddDescription.Text = string.Empty;
                txtAddTitle.Text = string.Empty;
            }

        }

        protected void cvTitleCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM SkillCategory WHERE Title = @title ";
            da.SelectCommand.Parameters.AddWithValue("@title", txtAddTitle.Text);
            da.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;
        }

        protected void grdSkillCat_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
        protected void grdSkillCat_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}