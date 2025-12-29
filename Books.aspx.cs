using System;
using System.Data;
using System.Data.SqlClient;
using FS_Bookstore.Helpers;

namespace FS_Bookstore
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadBooks();
            }
        }

        private void LoadBooks()
        {
            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("SELECT * FROM Books", con);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

        protected void gvBooks_RowCommand(object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int bookId = Convert.ToInt32(gvBooks.DataKeys[rowIndex].Value);

                int userId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection con = DBHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Cart (UserId, BookId, Quantity) VALUES (@UserId, @BookId, 1)", con);

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    lblMsg.Text = "Book added to cart";
                }
            }
        }
    }
}
