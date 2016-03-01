using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CACTB1.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserType"] == null)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
            //else if (Session["UserType"].ToString() != "Admin")
            //{
            //    Response.Redirect("~/Login.aspx");
            //}

        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session["UserType"] = null;
            Response.Redirect("~/Login.aspx");
        }

        protected void lbtnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/profile.aspx");
        }
    }
}