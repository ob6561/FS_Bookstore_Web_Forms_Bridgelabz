<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Orders.aspx.cs"
    Inherits="FS_Bookstore.Orders" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <a href="Books.aspx">Books</a> |
        <a href="Cart.aspx">Cart</a> |
        <a href="Orders.aspx">Orders</a> |
        <a href="Logout.aspx">Logout</a>

        <hr />

        <h3>Order History</h3>

        <asp:GridView
            ID="gvOrders"
            runat="server"
            AutoGenerateColumns="False">

            <Columns>
                <asp:BoundField
                    DataField="OrderId"
                    HeaderText="Order ID" />

                <asp:BoundField
                    DataField="OrderDate"
                    HeaderText="Date" />

                <asp:BoundField
                    DataField="TotalAmount"
                    HeaderText="Total Amount" />
            </Columns>

        </asp:GridView>

    </form>
</body>
</html>
