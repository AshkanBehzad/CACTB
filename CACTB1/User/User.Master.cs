﻿using System;
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
    public partial class User : System.Web.UI.MasterPage
    {


        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        SqlConnection connection = new SqlConnection(connectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Mid"] != null)
            {
                string mid = Session["Mid"].ToString();
                SqlDataAdapter da = new SqlDataAdapter("", connection);
                DataTable dt = new DataTable();
                da.SelectCommand.CommandText = "SELECT * FROM MemberList WHERE Mid=@mid";
                da.SelectCommand.Parameters.AddWithValue("@mid", mid);
                da.Fill(dt);
                if (Convert.ToBoolean(dt.Rows[0]["IsCompeleted"]))
                {
                    Response.Redirect("~/User/profile.aspx");
                }
            }
            else
                Response.Redirect("~/Login.aspx");
        }
    }
}