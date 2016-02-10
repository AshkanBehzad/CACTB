using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;


namespace CACTB1.Admin
{
    public partial class AddMembers : System.Web.UI.Page
    {
        //Getting Connectio String From Web.Config
            static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
            static string connectionString = connString.ToString();
        //Make a SQL Connection
            SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Iranain NationalCode Validator Function
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
        //Clear Form Function
        public void ClearForm()
        {
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtNationalID.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtStdentID.Text = string.Empty;
            rdbmale.Checked = true;
        }
        //NationalCode Custom Validator_ServerValidation event
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            var nationalCode = args.Value;
            args.IsValid = IsValidNationalCode(nationalCode);
        }
        //Validation > Check if There Exist a Member With the Same Student ID
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandText = "SELECT * FROM Members WHERE ID = @mid";

            da.SelectCommand.Parameters.AddWithValue("@mid", txtStdentID.Text);
            da.Fill(dt);
            if (dt.Rows.Count != 1)
            {
                args.IsValid = true;
            }
            else
                args.IsValid = false;
        }
        //Click Event > Add New Member if the Validations are Valid
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string gender = (rdbmale.Checked) ? "مرد" : "زن";
                //Insertion New Member Into Members Table
                    SqlCommand cmd = new SqlCommand("", connection);
                    cmd.CommandText = "INSERT INTO Members(ID,FirstName,LastName,NationalID,Email,PhoneNumber,Gender,Image,Fielde_ID,Date,IsCompeleted) "
                        + " VALUES(@id,@fn,@ls,@nid,@em,@phn,@g,@img,@fid,@date,@isCompeleted)";
                    cmd.Parameters.AddWithValue("@id", txtStdentID.Text);
                    cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@ls", txtLastName.Text);
                    cmd.Parameters.AddWithValue("@nid", txtNationalID.Text);
                    cmd.Parameters.AddWithValue("@em", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@phn", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@g", gender);
                    cmd.Parameters.AddWithValue("@img", "~/MyFiles/user.png");
                    cmd.Parameters.AddWithValue("@fid", ddlField.SelectedValue);
                    cmd.Parameters.AddWithValue("@date", PersianDateConverter.GetDate());
                    cmd.Parameters.AddWithValue("@isCompeleted", "false");
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                cmd.Parameters.Clear();
                //Insertion new Member AS an User into Users Table
                    SqlDataAdapter da = new SqlDataAdapter("", connection);
                    DataTable dt = new DataTable();
                    da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid = @mid";
                    da.SelectCommand.Parameters.AddWithValue("@mid", txtStdentID.Text);
                    da.Fill(dt);
                    cmd.CommandText = "INSERT INTO Users(Member_ID,Password,Type_ID) VALUES(@Mid,@pass,@type)";
                    cmd.Parameters.AddWithValue("@Mid", txtStdentID.Text);
                    cmd.Parameters.AddWithValue("@pass", dt.Rows[0]["NationalID"].ToString());
                    cmd.Parameters.AddWithValue("@type", db.SelectQueryFillDataTable("SELECT * FROM Rols WHERE Type = N'User'", 0, "ID").ToString());
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                //Alert 'Add Succesfully'
                string gen = (gender == "مرد") ? "آقای" : "خانم";
                Response.Write("<script>alert('" + gen + " " + "" + txtFirstName.Text + " " + "" + txtLastName.Text + "  باموفقیت افزوده شد.');</script>");
                ClearForm();
            }
        }

    }
}