using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Project_Glados_master
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectGladosDBConnectionString3"].ConnectionString))
            {
                sqlCon.Open();
                string query = "SELECT COUNT(1) FROM Users WHERE userName = @userName AND password = @password";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@userName", Username.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    query = "SELECT COUNT(1) FROM Users WHERE userName = @userName AND password = @password AND isModerator = 1";

                    sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@userName", Username.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                    count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    if (count == 1)
                    {
                        Session["username"] = Username.Text.Trim();
                        Response.Redirect("ModeratorWebForm.aspx");
                    }
                    else
                    {
                        query = "SELECT COUNT(1) FROM Users WHERE userName = @userName AND password = @password AND isAdministrator = 1";

                        sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@userName", Username.Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());

                        count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                        if (count == 1)
                        {
                            Session["username"] = Username.Text.Trim();
                            Response.Redirect("AdministratorWebForm.aspx");
                        }
                        else
                        {
                            Session["username"] = Username.Text.Trim();
                            Response.Redirect("WebForm1.aspx");

                        }

                    }
                }
                else
                {
                    lblErrorMessage.Visible = true;

                }
            }

        }

        protected void Continue_Click(object sender, EventArgs e)
        {
            Session["username"] = null;
            Response.Redirect("WebForm1.aspx");
        }

        protected void SignUp_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectGladosDBConnectionString3"].ConnectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Users (isModerator, isAdministrator, isDeleted, userName, [password], email) VALUES (0, 0, 0, @username, @password, @email)";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@username", usernameSignUp.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@password", passwordSignUp.Text.Trim());
                sqlCmd.Parameters.AddWithValue("@email", emailSignUp.Text.Trim());
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();

                Session["username"] = usernameSignUp.Text.Trim();
                Response.Redirect("WebForm1.aspx");
            }
        }
    }
}