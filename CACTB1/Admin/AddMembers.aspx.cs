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
        //Getting Connection String From Web.Config
            static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
            static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
            static string connectionString = connString.ToString();
        //Make a SQL Connection
            SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();

        public static void SendMail(string address,string id,string pass)
        {
            string mailBody = "باسلام\nعضویت شما در انجمن علمی مهندسی کامپیوتر با موفقیت ثبت شد.\nهم اکنون میتوانید در سایت cactb.ir وارد شده واطلاعات خود را تکمیل کنید \n لازم به ذکر است که نام کابری شما همان شماره دانشجویی و رمز عبور شما کد ملی شماست.\nبا تشکر \nانجمن علمی مهندسی کامپیوتر";
            mailBody += "\n http://localhost:7297/User/Hello.aspx?MMID=" + id +"&MPASS="+pass;
            string sub = "عضویت در انجمن علمی مهندسی کامپیوتر";
            MailService.SendMail(mailBody, sub, address);
        }
        public static string MakePass(string ID, string phoneNum,string email)
        {
            return ID.Remove(0, ID.Length - 4) + phoneNum.Remove(0, phoneNum.Length - 4) +
                email.Substring(0, 1).ToUpper();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        //Clear Form Function
        public void ClearForm()
        {
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtStdentID.Text = string.Empty;
            rdbmale.Checked = true;
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
                    cmd.CommandText = "INSERT INTO Members(ID,FirstName,LastName,Email,PhoneNumber,Gender,Image,Fielde_ID,Date,IsCompeleted) "
                        + " VALUES(@id,@fn,@ls,@em,@phn,@g,@img,@fid,@date,@isCompeleted)";
                    cmd.Parameters.AddWithValue("@id", txtStdentID.Text);
                    cmd.Parameters.AddWithValue("@fn", txtFirstName.Text);
                    cmd.Parameters.AddWithValue("@ls", txtLastName.Text);
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
                cmd.Parameters.AddWithValue("@pass",MakePass(txtStdentID.Text,txtPhoneNumber.Text,txtEmail.Text).ToUpper());
                cmd.Parameters.AddWithValue("@type", db.SelectQueryFillDataTable("SELECT * FROM Rols WHERE Type = N'User'", 0, "ID").ToString());
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                SendMail(txtEmail.Text.ToLower(),txtStdentID.Text, MakePass(txtStdentID.Text, txtPhoneNumber.Text, txtEmail.Text).ToUpper());
                //Alert 'Add Succesfully'
                string gen = (gender == "مرد") ? "آقای" : "خانم";
                Response.Write("<script>alert('" + gen + " " + "" + txtFirstName.Text + " " + "" + txtLastName.Text + "  باموفقیت افزوده شد.');</script>");
                ClearForm();
            }
        }

    }
}