using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Glados_master
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) {
            Session["currentVideoGame"] = Request.QueryString["VideoGameId"];
            string query = "SELECT [Title], [Rating], [Price], [Genre], [Company] FROM [VideoGames] WHERE [VideoGameId] = " + Request.QueryString["VideoGameId"];
            SqlDataSource1.SelectCommand = query;
            SqlDataSource1.DataBind();

            string query2 = "SELECT U.[userName], C.[Rating], C.[Comments] FROM [Comments] C , Users U WHERE C.UserId = U.UserId AND C.IsDeleted=0 AND C.videoGameId = " + Request.QueryString["VideoGameId"];
            SqlDataSource2.SelectCommand = query2;
            SqlDataSource2.DataBind();
        }

        protected void BtnMain_Click(object sender, EventArgs e) {
            Response.Redirect(Session["webpage"].ToString());
        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {
            Session["VideoGamePage"] = "WebForm3.aspx?VideoGameId=" + Session["currentVideoGame"];
            Response.Redirect("CommentWebForm.aspx");
        }
    }
}