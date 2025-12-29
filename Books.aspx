<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Books.aspx.cs"
    Inherits="FS_Bookstore.Books" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Available Books</title>
</head>

<body>
    <form id="form1" runat="server">
        <a href="Books.aspx">Books</a> |
        <a href="Cart.aspx">Cart</a> |
        <a href="Orders.aspx">Orders</a> |
        <a href="Logout.aspx">Logout</a>
        <hr />


        <h3>Available Books</h3>

        <asp:GridView
            ID="gvBooks"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="BookId"
            OnRowCommand="gvBooks_RowCommand">

            <Columns>
                <asp:BoundField
                    DataField="Title"
                    HeaderText="Title" />

                <asp:BoundField
                    DataField="Author"
                    HeaderText="Author" />

                <asp:BoundField
                    DataField="Price"
                    HeaderText="Price" />

                <asp:ButtonField
                    Text="Add to Cart"
                    CommandName="AddToCart"
                    ButtonType="Button" />
            </Columns>

        </asp:GridView>

        <br />

        <asp:Label
            ID="lblMsg"
            runat="server">
        </asp:Label>

    </form>
</body>
</html>
