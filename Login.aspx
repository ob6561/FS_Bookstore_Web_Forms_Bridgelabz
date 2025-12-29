<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="FS_Bookstore.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <h3>User Login</h3>

        Email:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /><br />

        Password:
        <asp:TextBox ID="txtPassword"
            runat="server"
            TextMode="Password"></asp:TextBox>
        <br /><br />

        <asp:Button ID="btnLogin"
            runat="server"
            Text="Login"
            OnClick="btnLogin_Click" />
        <br /><br />

        <asp:Label ID="lblMsg"
            runat="server"
            ForeColor="Red"></asp:Label>

    </form>
</body>
</html>
