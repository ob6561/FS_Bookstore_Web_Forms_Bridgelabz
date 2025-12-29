using System;
using System.Data.SqlClient;
using FS_Bookstore.Helpers;

namespace FS_Bookstore
{
    public partial class Register : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)", con);

                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                con.Open();
                cmd.ExecuteNonQuery();

                lblMsg.Text = "Registration Successful";
            }
        }
    }
}
