using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
            DatabaseConnection db = new DatabaseConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
             db.SelectQueryFillGridView("select * from Members",grd);
        }

        protected void grd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grd.PageIndex = e.NewPageIndex;
            grd.DataBind();
        }
    }
}