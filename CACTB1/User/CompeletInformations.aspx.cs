using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.User
{

    public partial class CompeletInformations1 : System.Web.UI.Page
    {
        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        bool edit = false;
        public void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid = @id";
            da.SelectCommand.Parameters.AddWithValue("id", Session["Mid"]);
            da.Fill(dt);
            rdbFemale.Checked = dt.Rows[0]["Gender"].ToString() == "زن";
            rdbmale.Checked = dt.Rows[0]["Gender"].ToString() == "مرد";
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            txtMemberID.Text = dt.Rows[0]["Mid"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtPhoneNumber.Text = dt.Rows[0]["PhoneNumber"].ToString();
            txtAltPhoneNumber.Text = dt.Rows[0]["AltPhoneNumber"].ToString();
            ddlField.SelectedValue = dt.Rows[0]["Fid"].ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txtEmail.Enabled = false;
            txtFirstName.Enabled = false;
            txtAltPhoneNumber.Enabled = false;
            txtLastName.Enabled = false;
            txtMemberID.Enabled = false;
            txtPhoneNumber.Enabled = false;
            rdbmale.Enabled = false;
            rdbFemale.Enabled = false;
            ddlField.Enabled = false;
            if (!IsPostBack)
                LoadData();
        }
        

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            edit = true;
            txtFirstName.Enabled = true;
            txtLastName.Enabled = true;
            txtEmail.Enabled = true;
            txtMemberID.Enabled = true;
            txtAltPhoneNumber.Enabled = true;
            txtPhoneNumber.Enabled = true;
            rdbmale.Enabled = true;
            rdbFemale.Enabled = true;
            ddlField.Enabled = true;
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SqlCommand cmd = new SqlCommand("", connection);
                cmd.CommandText = "UPDATE Members SET ID=@id,FirstName=@fn,LastName=@ln,Email=@email,PhoneNumber=@phone,AltPhoneNumber=@altPhone,Gender=@gen,Fielde_ID=@fid WHERE ID=@mid";
                cmd.Parameters.AddWithValue("@id", txtMemberID.Text);
                cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@ln", txtLastName.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@phone", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@altPhone", txtAltPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@fid", ddlField.SelectedValue);
                cmd.Parameters.AddWithValue("@gen", (rdbmale.Checked) ? "مرد" : "زن");
                cmd.Parameters.AddWithValue("@mid", Session["Mid"]);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                Session["Mid"] = txtMemberID.Text;
                Response.Redirect("ChangePassword.aspx");
            }

        }
    }
}