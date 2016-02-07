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
        public static Boolean IsValidNationalCode(string nationalCode)
        {

            if (string.IsNullOrEmpty(nationalCode))
                return false;
            if (nationalCode.Length != 10)
                return false;
            var regex = new Regex(@"\d{10}");
            if (!regex.IsMatch(nationalCode))
                return false;
            var allDigitEqual = new[] { "0000000000", "1111111111", "2222222222", "3333333333", "4444444444", "5555555555", "6666666666", "7777777777", "8888888888", "9999999999" };
            if (allDigitEqual.Contains(nationalCode))
                return false;
            else
            {
                var chArray = nationalCode.ToCharArray();
                var num0 = Convert.ToInt32(chArray[0].ToString()) * 10;
                var num2 = Convert.ToInt32(chArray[1].ToString()) * 9;
                var num3 = Convert.ToInt32(chArray[2].ToString()) * 8;
                var num4 = Convert.ToInt32(chArray[3].ToString()) * 7;
                var num5 = Convert.ToInt32(chArray[4].ToString()) * 6;
                var num6 = Convert.ToInt32(chArray[5].ToString()) * 5;
                var num7 = Convert.ToInt32(chArray[6].ToString()) * 4;
                var num8 = Convert.ToInt32(chArray[7].ToString()) * 3;
                var num9 = Convert.ToInt32(chArray[8].ToString()) * 2;
                var a = Convert.ToInt32(chArray[9].ToString());
                var b = (((((((num0 + num2) + num3) + num4) + num5) + num6) + num7) + num8) + num9;
                var c = b % 11;
                return (((c < 2) && (a == c)) || ((c >= 2) && ((11 - c) == a)));
            }
        }
        public void LoadData()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid = @id";
            da.SelectCommand.Parameters.AddWithValue("id", Session["Mid2"]);
            da.Fill(dt);
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            txtMemberID.Text = dt.Rows[0]["Mid"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            txtNatioanlID.Text = dt.Rows[0]["NationalID"].ToString();
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
            txtNatioanlID.Enabled = false;
            txtPhoneNumber.Enabled = false;
            ddlField.Enabled = false;
            if (!IsPostBack)
                LoadData();
        }

        protected void cvMemberID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtMemberID.Text.ToString().Length != 9)
                args.IsValid = false;
            else
                args.IsValid = true;
        }

        protected void cvNationalID_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = IsValidNationalCode(txtNatioanlID.Text.ToString());
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {

            txtEmail.Enabled = true;
            txtFirstName.Enabled = true;
            txtAltPhoneNumber.Enabled = true;
            txtLastName.Enabled = true;
            txtMemberID.Enabled = true;
            txtNatioanlID.Enabled = true;
            ddlField.Enabled = true;
            txtPhoneNumber.Enabled = true;
        }
    }
}