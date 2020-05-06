using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Project_Glados_master
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lloyd\Documents\ProjectGladosDB.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                string name = Session["username"].ToString();
                usernameDisplay.InnerHtml = "<h4 style = 'color: RoyalBlue;' > username:" + name + "</ h4 >";
            }
            else
            {
                usernameDisplay.InnerHtml = "<h4 style = 'color: RoyalBlue;' > no username </ h4 >";
            }
            // using (SqlConnection sqlCon = new SqlConnection(connectionString)) {
            // sqlCon.Open();
            //SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Title, Price, GenreId, Description FROM VideoGames", sqlCon);
            //DataTable dtbl = new DataTable();
            //sqlData.Fill(dtbl);
            //GridView1.DataSource = dtbl;
            //GridView1.DataBind();
            //}
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String query = "SELECT VideoGameId, Title, Genre, Rating, Company, Requested, Price FROM VideoGames WHERE Requested=0 AND Title LIKE '%" + gameTitle.Text + "%' AND Company LIKE '%" + gameDeveloper.Text + "%'";
            if (gameRating.Text != "Rating") {
                query += " AND Rating >= " + gameRating.Text + " ORDER BY Rating DESC";
            }
            SqlDataSource1.SelectCommand = query;
            SqlDataSource1.DataBind();
        }
    }
}