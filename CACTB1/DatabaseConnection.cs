using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;

namespace CACTB1
{
    public class DatabaseConnection
    {

        static Configuration rootWebConfig = WebConfigurationManager.OpenWebConfiguration("/MyWebSiteRoot");
        static ConnectionStringSettings connString = rootWebConfig.ConnectionStrings.ConnectionStrings["CACTB1ConnectionString"];
        static string connectionString = connString.ToString();
        static SqlConnection connection = new SqlConnection(connectionString);
        //Count
        public int Count(string tableName, string field)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT COUNT(@field)  AS [Count] FROM "+ tableName + "",connection);
            da.SelectCommand.Parameters.AddWithValue("@field", field);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return Convert.ToInt32(dt.Rows[0]["Count"]);
        }
        //Return DataTable From A SELECT
        public DataTable SelectQueryFillDataTable(string selectQuery)
        {
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        //Return DataTable's Row Content From A SELECT
        public object SelectQueryFillDataTable(string selectQuery, int column, int row)
        {
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[column][row];
        }
        //Return DataTable's Row Content From A SELECT
        public object SelectQueryFillDataTable(string selectQuery, int column, string row)
        {
            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[column][row];
        }
        //
        public string SelectQueryFillDataTableConditional(string selectQuery, int column, string row)
        {

            SqlDataAdapter da = new SqlDataAdapter(selectQuery, connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[column][row].ToString();
        }
        //Fill A GridView
        public void SelectQueryFillGridView(string selectQuery, GridView grd)
        {
            grd.DataSource = SelectQueryFillDataTable(selectQuery);
            grd.DataBind();
        }
        //
        public string ExecuteScaler(string tableName, string FieldName, string fieldCondition, string valueCondition)
        {
            string strReult;
            SqlCommand cmd = new SqlCommand("SELECT " + FieldName + "FROM" + tableName + "WHERE" + fieldCondition + "= @val", connection);
            cmd.Parameters.AddWithValue("@val", valueCondition);
            connection.Open();
            strReult = cmd.ExecuteScalar().ToString();
            connection.Close();
            return strReult;
        }


        //Fill A DropDownList
        public void SelectQueryFillDropDownList(string selectQuery, DropDownList drp, string dataTextField, string dataValueField)
        {
            drp.DataSource = SelectQueryFillDataTable(selectQuery);
            drp.DataTextField = dataTextField;
            drp.DataValueField = dataValueField;
            drp.DataBind();
        }
        //Insert 1 v
        public void Insert(string tableName, string field1, string value1)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + ") VALUES(@value1)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 2 v
        public void Insert(string tableName, string field1, string field2, string value1, string value2)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + ") VALUES(@value1,@value2)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 3 v
        public void Insert(string tableName, string field1, string field2, string field3, string value1, string value2, string value3)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + "," + field3 + ") VALUES(@value1,@value2,@value3)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            cmd.Parameters.AddWithValue("@value3", value3);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 4 v
        public void Insert(string tableName, string field1, string field2, string field3, string field4, string value1, string value2, string value3, string value4)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + "," + field3 + "," + field4 + ") VALUES(@value1,@value2,@value3,@value4)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            cmd.Parameters.AddWithValue("@value3", value3);
            cmd.Parameters.AddWithValue("@value4", value4);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 5 v
        public void Insert(string tableName, string field1, string field2, string field3, string field4, string field5, string value1, string value2, string value3, string value4, string value5)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + "," + field3 + "," + field4 + "," + field5 + ") VALUES(@value1,@value2,@value3,@value4,@value5)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            cmd.Parameters.AddWithValue("@value3", value3);
            cmd.Parameters.AddWithValue("@value4", value4);
            cmd.Parameters.AddWithValue("@value5", value5);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 6 v
        public void Insert(string tableName, string field1, string field2, string field3, string field4, string field5, string field6, string value1, string value2, string value3, string value4, string value5, string value6)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + "," + field3 + "," + field4 + "," + field5 + "," + field6 + ") VALUES(@value1,@value2,@value3,@value4,@value5,@value6)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            cmd.Parameters.AddWithValue("@value3", value3);
            cmd.Parameters.AddWithValue("@value4", value4);
            cmd.Parameters.AddWithValue("@value5", value5);
            cmd.Parameters.AddWithValue("@value6", value6);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 7 v
        public void Insert(string tableName, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string value1, string value2, string value3, string value4, string value5, string value6, string value7)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + "," + field3 + "," + field4 + "," + field5 + "," + field6 + "," + field7 + ") VALUES(@value1,@value2,@value3,@value4,@value5,@value6,@value7)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            cmd.Parameters.AddWithValue("@value3", value3);
            cmd.Parameters.AddWithValue("@value4", value4);
            cmd.Parameters.AddWithValue("@value5", value5);
            cmd.Parameters.AddWithValue("@value6", value6);
            cmd.Parameters.AddWithValue("@value7", value7);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        //Insert 7 v
        public void Insert(string tableName, string field1, string field2, string field3, string field4, string field5, string field6, string field7, string field8, string value1, string value2, string value3, string value4, string value5, string value6, string value7, string value8)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tableName + "(" + field1 + "," + field2 + "," + field3 + "," + field4 + "," + field5 + "," + field6 + "," + field7 + "," + field8 + ") VALUES(@value1,@value2,@value3,@value4,@value5,@value6,@value7,@value8)", connection);
            cmd.Parameters.AddWithValue("@table", tableName);
            cmd.Parameters.AddWithValue("@value1", value1);
            cmd.Parameters.AddWithValue("@value2", value2);
            cmd.Parameters.AddWithValue("@value3", value3);
            cmd.Parameters.AddWithValue("@value4", value4);
            cmd.Parameters.AddWithValue("@value5", value5);
            cmd.Parameters.AddWithValue("@value6", value6);
            cmd.Parameters.AddWithValue("@value7", value7);
            cmd.Parameters.AddWithValue("@value8", value8);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }


    }
}