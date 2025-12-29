using System;
using System.Data.SqlClient;
using FS_Bookstore.Helpers;

namespace FS_Bookstore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT UserId FROM Users WHERE Email=@Email AND Password=@Password", con);

                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                con.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    
                    Session["UserId"] = result;
                    lblMsg.ForeColor = System.Drawing.Color.Green;
                    Session["UserId"] = result;
                    Response.Redirect("Books.aspx");

                }
                else
                {
                    
                    lblMsg.Text = "Invalid Email or Password";
                }
            }
        }
    }
}
