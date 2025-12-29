<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Cart.aspx.cs"
    Inherits="FS_Bookstore.Cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Your Cart</title>
</head>

<body>
    <form id="form1" runat="server">
        <a href="Books.aspx">Books</a> |
        <a href="Cart.aspx">Cart</a> |
        <a href="Orders.aspx">Orders</a> |
        <a href="Logout.aspx">Logout</a>
        <hr />


        <h3>Your Cart</h3>

        <asp:GridView
            ID="gvCart"
            runat="server"
            AutoGenerateColumns="False"
            DataKeyNames="BookId"
            OnRowCommand="gvCart_RowCommand">

            <Columns>
                <asp:BoundField
                    DataField="Title"
                    HeaderText="Book" />

                <asp:BoundField
                    DataField="Price"
                    HeaderText="Price" />

                <asp:BoundField
                    DataField="Quantity"
                    HeaderText="Quantity" />

                <asp:ButtonField
                    Text="Remove"
                    CommandName="RemoveItem"
                    ButtonType="Button" />
            </Columns>

        </asp:GridView>

        <br />

        <asp:Button
            ID="btnPlaceOrder"
            runat="server"
            Text="Place Order"
            OnClick="btnPlaceOrder_Click" />

        <br /><br />

        <asp:Label
            ID="lblMsg"
            runat="server">
        </asp:Label>

    </form>
</body>
</html>
