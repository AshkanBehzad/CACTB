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
    public partial class Skills : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadData()
        {
            db.SelectQueryFillDropDownList("SELECT * FROM SkillCategory", ddlSkillCat, "Title", "ID");
            db.SelectQueryFillGridView("SELECT * FROM SkillList", grdSkills);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
                LoadData();
        }

        protected void cvSkillTitleCheck_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Skills WHERE Title= @title AND Cat_ID=@catID", connection);
            da.SelectCommand.Parameters.AddWithValue("@title", txtAddTitle.Text);
            da.SelectCommand.Parameters.AddWithValue("@catID", ddlSkillCat.SelectedValue);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count != 0 || txtAddTitle.Text == string.Empty || string.IsNullOrWhiteSpace(txtAddTitle.Text))
            {
                args.IsValid = false;
            }
            else
                args.IsValid = true;

        }

        protected void btnAddCSkill_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && !(string.IsNullOrWhiteSpace(txtAddTitle.Text) || string.IsNullOrEmpty(txtAddTitle.Text)))

            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Skills(Title,Cat_ID,Description) VALUES(@title,@catID,@des)", connection);
                cmd.Parameters.AddWithValue("@title", txtAddTitle.Text);
                cmd.Parameters.AddWithValue("@des", txtAddDescription.Text);
                cmd.Parameters.AddWithValue("@catID", ddlSkillCat.SelectedValue);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
                txtAddDescription.Text = string.Empty;
                txtAddTitle.Text = string.Empty;
            }
        }


        protected void grdSkills_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandArgument != null)
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    if (e.CommandName == "DeleteItem")
                    {
                        SqlCommand cmd = new SqlCommand("DELETE FROM Skills WHERE ID=@id", connection);
                        cmd.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        LoadData();
                    }
                    if (e.CommandName == "EditItem")
                    {
                        Response.Redirect("EditSkills.aspx?Sid=" + id);
                    }
                }
            }
            catch (Exception) { }
        }

        protected void grdSkills_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdSkills_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}