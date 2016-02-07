using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.Admin
{
    public partial class MembersList : System.Web.UI.Page
    {
        DatabaseConnection db = new DatabaseConnection();

        public void LoadData()
        {
            db.SelectQueryFillGridView("SELECT * FROM MemberList", grdMemberList);
            lblCount.Text = db.Count("Members", "ID").ToString();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();

            }
        }

        protected void grdMemberList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Show")
            {
                Session["Mid"] = id.ToString();
                Response.Redirect("MemberStats.aspx");
            }
        }
        
        protected void grdMemberList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdMemberList.PageIndex = e.NewPageIndex;
            db.SelectQueryFillGridView("SELECT * FROM MemberList",grdMemberList);
        }
    }
}