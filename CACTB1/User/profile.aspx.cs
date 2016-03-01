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
    public partial class profile : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();

        public void LoadData()
        {
            //string mid = Session["Mid"].ToString();
            string mid = "930251337";
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid = @mid";
            da.SelectCommand.Parameters.AddWithValue("@mid", mid);
            da.Fill(dt);
            if (dt.Rows[0]["ImageExtention"].ToString().Length != 0)
            {
                imgProfile.ImageUrl = dt.Rows[0]["Image"].ToString() + dt.Rows[0]["ImageExtention"].ToString();
            }
            lblFullNameUP.Text = dt.Rows[0]["FullName"].ToString();
            lblMembershipStatusUP.Text = dt.Rows[0]["Status_ID"].ToString();
            lblFieldUP.Text = dt.Rows[0]["Title"].ToString();
            lblBioUP.Text = dt.Rows[0]["Bio"].ToString();

            if (dt.Rows[0]["Github"].ToString().Length == 0)
                github.Visible = false;
            else
            {
                lblgithub.Text ='/' + dt.Rows[0]["Github"].ToString();
                github.HRef = "https://github.com/" + dt.Rows[0]["Github"].ToString();
            }

            if (dt.Rows[0]["Linkedin"].ToString().Length == 0)
                linkedin.Visible = false;
            else
            {
                lblLinkedin.Text ='/' + dt.Rows[0]["Linkedin"].ToString();
                //linkedin.HRef = "https://Linkedin.com/" + dt.Rows[0]["Linkedin"].ToString();
            }

            if (dt.Rows[0]["Twitter"].ToString().Length == 0)
                twitter.Visible = false;
            else
            {
                lblTwitter.Text ='/' + dt.Rows[0]["Twitter"].ToString();
                //twitter.HRef = "https://Twitter.com/" + dt.Rows[0]["Twitter"].ToString();
            }
            lblFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            lblLastName.Text = dt.Rows[0]["LastName"].ToString();
            lblField.Text = dt.Rows[0]["Title"].ToString();
            lblPhone1.Text = dt.Rows[0]["PhoneNumber"].ToString();
            lblPhone2.Text = dt.Rows[0]["AltPhoneNumber"].ToString();
            lblEmail.Text = dt.Rows[0]["Email"].ToString();
            lblNationalID.Text = dt.Rows[0]["NationalID"].ToString();
            lblStudentID.Text = dt.Rows[0]["Mid"].ToString();
            da.SelectCommand.Parameters.Clear();
            dt.Clear();
            da.SelectCommand.CommandText = "SELECT * FROM MemberSkillList WHERE Member_ID = @mid2";
            da.SelectCommand.Parameters.AddWithValue("@mid2", mid);
            da.Fill(dt);
            dlSkills.DataSource = dt;
            dlSkills.DataBind();
            da.SelectCommand.Parameters.Clear();
            dt.Clear();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }

        protected void dlSkills_ItemCommand(object source, DataListCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            string mid = "930251337";
            if (e.CommandName == "DeleteItem")
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "DELETE FROM MembersSkills WHERE Member_ID=@mid3 AND ID=@caid";
                cmd.Parameters.AddWithValue("@mid3", mid);
                cmd.Parameters.AddWithValue("@caid", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                LoadData();
            }
        }

        protected void lbtnSignOut_Click(object sender, EventArgs e)
        {
            Session["Mid"] = null;
            Response.Redirect("~/Login.aspx");
        }
    }
}