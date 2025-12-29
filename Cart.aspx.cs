using System;
using System.Data;
using System.Data.SqlClient;
using FS_Bookstore.Helpers;

namespace FS_Bookstore
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadCart();
            }
        }

        private void LoadCart()
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection con = DBHelper.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT b.BookId, b.Title, b.Price, c.Quantity
                      FROM Cart c
                      INNER JOIN Books b ON c.BookId = b.BookId
                      WHERE c.UserId = @UserId", con);

                da.SelectCommand.Parameters.AddWithValue("@UserId", userId);

                DataTable dt = new DataTable();
                da.Fill(dt);

                gvCart.DataSource = dt;
                gvCart.DataBind();
            }
        }

        protected void gvCart_RowCommand(
            object sender,
            System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RemoveItem")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                int bookId = Convert.ToInt32(gvCart.DataKeys[rowIndex].Value);
                int userId = Convert.ToInt32(Session["UserId"]);

                using (SqlConnection con = DBHelper.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Cart WHERE UserId=@UserId AND BookId=@BookId", con);

                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@BookId", bookId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                lblMsg.Text = "Item removed from cart";
                LoadCart();
            }
        }

        
        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserId"]);

            using (SqlConnection con = DBHelper.GetConnection())
            {
                con.Open();

                
                SqlCommand totalCmd = new SqlCommand(
                    @"SELECT SUM(b.Price * c.Quantity)
                      FROM Cart c
                      INNER JOIN Books b ON c.BookId = b.BookId
                      WHERE c.UserId = @UserId", con);

                totalCmd.Parameters.AddWithValue("@UserId", userId);

                object total = totalCmd.ExecuteScalar();

                if (total == DBNull.Value)
                {
                    lblMsg.Text = "Cart is empty";
                    return;
                }

                
                SqlCommand orderCmd = new SqlCommand(
                    @"INSERT INTO Orders (UserId, OrderDate, TotalAmount)
                      OUTPUT INSERTED.OrderId
                      VALUES (@UserId, GETDATE(), @TotalAmount)", con);

                orderCmd.Parameters.AddWithValue("@UserId", userId);
                orderCmd.Parameters.AddWithValue("@TotalAmount", total);

                int orderId = (int)orderCmd.ExecuteScalar();

                
                SqlCommand itemsCmd = new SqlCommand(
                    @"INSERT INTO OrderItems (OrderId, BookId, Quantity, Price)
                      SELECT @OrderId, c.BookId, c.Quantity, b.Price
                      FROM Cart c
                      INNER JOIN Books b ON c.BookId = b.BookId
                      WHERE c.UserId = @UserId", con);

                itemsCmd.Parameters.AddWithValue("@OrderId", orderId);
                itemsCmd.Parameters.AddWithValue("@UserId", userId);
                itemsCmd.ExecuteNonQuery();

                
                SqlCommand clearCmd = new SqlCommand(
                    "DELETE FROM Cart WHERE UserId=@UserId", con);

                clearCmd.Parameters.AddWithValue("@UserId", userId);
                clearCmd.ExecuteNonQuery();

                lblMsg.Text = "Order placed successfully";
                LoadCart();
            }
        }
    }
}
