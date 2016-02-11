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
    public partial class Search : System.Web.UI.Page
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        DatabaseConnection db = new DatabaseConnection();
        public void LoadData()
        {
            drpField.Items.Insert(0,new ListItem("<--مقطع/گرایش-->","") );
            ddlStatuse.Items.Insert(0,new ListItem("<--وضعیت عضو-->", "") );
            drpField.SelectedIndex = 0;
            ddlStatuse.SelectedIndex = 0;
            db.SelectQueryFillDropDownList("SELECT * FROM Fields", drpField, "Title", "ID");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadData();
        }
        public void SearchMember()
        {
            SqlDataAdapter da = new SqlDataAdapter("", connection);
            DataTable dt = new DataTable();
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.CommandText = "SearchedMemberList";
            if (drpField.SelectedValue != string.Empty)
                da.SelectCommand.Parameters.AddWithValue("@Fid", drpField.SelectedValue);
            if (txtName.Text != string.Empty)
            {
                da.SelectCommand.Parameters.AddWithValue("@Name", txtName.Text);
            }
            da.Fill(dt);
            grdSearchedList.DataSource = dt;
            grdSearchedList.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        protected void grdSearchedList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdSearchedList.PageIndex = e.NewPageIndex;
            SearchMember();
        }

    }
}