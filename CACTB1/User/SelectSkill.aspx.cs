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
    public partial class SelectSkill : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Bind & Fill Category GridView
            if (!IsPostBack)
                db.SelectQueryFillGridView("SELECT * FROM SkillCategory", grdCat);
        }
        protected void grdCat_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
            {
                return;
            }
            //Find inner GridView BECAUSE the Inner gridView ain't Recognized
            GridView nestedGrid = (GridView)e.Row.FindControl("grdSkill");
            string datakey = grdCat.DataKeys[e.Row.RowIndex].Value.ToString();
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            //Fill inner GridView According to Outer GridView's ID as dataKeyName
            da.SelectCommand.CommandText = "SELECT * FROM Skills WHERE Cat_ID=@cid";
            da.SelectCommand.Parameters.AddWithValue("@cid", datakey);
            da.Fill(dt);
            nestedGrid.DataSource = dt;
            nestedGrid.DataBind();
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            //Iterate outer GridView Rows ...
            foreach (GridViewRow row in grdCat.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    // ... to Find the Inner GridView
                    GridView grdSkills = (GridView)row.FindControl("grdSkill");
                    //Iterate inner GridView ...
                    if (grdSkills != null)
                    {
                        foreach (GridViewRow grow in grdSkills.Rows)
                        {
                            if (grow.RowType == DataControlRowType.DataRow)
                            {
                                //... to Find CheckBoxes
                                CheckBox ckbSkills = (CheckBox)grow.FindControl("ckbSkill");
                                if (ckbSkills != null)
                                {
                                    if (ckbSkills.Checked)
                                    {
                                        var dataKey = grdSkills.DataKeys[grow.RowIndex];
                                        if (dataKey != null)
                                        {
                                            string sid = dataKey.Value.ToString();
                                            SqlDataAdapter d = new SqlDataAdapter("", connection);
                                            DataTable t = new DataTable();
                                            d.SelectCommand.CommandText = "SELECT * FROM MembersSkills WHERE Member_ID=@mid AND Skill_ID=@sid";
                                            d.SelectCommand.Parameters.AddWithValue("@mid", Session["Mid"]);
                                            d.SelectCommand.Parameters.AddWithValue("@sid", sid);
                                            d.Fill(t);
                                            if (t.Rows.Count == 0)
                                            {
                                                d.SelectCommand.Parameters.Clear();
                                                SqlCommand cmd = new SqlCommand("INSERT INTO MembersSkills(Member_ID,Skill_ID,Date) VALUES(@mid,@sid,@date)", connection);
                                                cmd.Parameters.AddWithValue("@mid", Session["Mid"]);
                                                cmd.Parameters.AddWithValue("@sid", sid);
                                                cmd.Parameters.AddWithValue("@date", PersianDateConverter.GetDate());
                                                connection.Open();
                                                cmd.ExecuteNonQuery();
                                                connection.Close();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Response.Redirect("SkillVal.aspx");
        }

        protected void btnSuggest_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrWhiteSpace(txtTitle.Text)))
            {
                SqlDataAdapter da = new SqlDataAdapter("", connection);
                DataTable dt = new DataTable();
                DataTable dl = new DataTable();
                SqlCommand cmd = new SqlCommand("", connection);
                da.SelectCommand.CommandText = "SELECT * FROM Skills WHERE Title=@tl";
                da.SelectCommand.Parameters.AddWithValue("@tl", txtTitle.Text);
                da.Fill(dt);
                da.SelectCommand.Parameters.Clear();
                da.SelectCommand.CommandText = "SELECT * FROM SkillRequest WHERE Title=@title AND Member_ID=@mid";
                da.SelectCommand.Parameters.AddWithValue("@title", txtTitle.Text);
                da.SelectCommand.Parameters.AddWithValue("@mid", Session["Mid"]);
                da.Fill(dl);
                if (dt.Rows.Count != 0)
                    Response.Write("<script>alert('دانشی که پیشنهاد کرده‌اید در لیست موجود است');</script>");
                if (dl.Rows.Count != 0)
                    Response.Write("<script>alert('شما قبلاً این دانش را ثبت کرده‌اید');</script>");

                else
                {
                    
                    cmd.CommandText = "INSERT INTO SkillRequest(Title,Member_ID,Description,Date) VALUES(@ttl,@mid2,@des,@date)";
                    cmd.Parameters.AddWithValue("@ttl", txtTitle.Text);
                    cmd.Parameters.AddWithValue("@mid2", Session["Mid"]);
                    cmd.Parameters.AddWithValue("@des", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@date", PersianDateConverter.GetDate());
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            else
            {
                Response.Write("<script>alert('دانش پیشنهادی افزوده نشد.فیلد خالی است');</script>");
            }

        }
    }
}