<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FS_Bookstore._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>FS Bookstore</title>
</head>
<body>
    <form runat="server">
        <h3>Welcome to FS Bookstore</h3>

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br /><br />
        <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
    </form>
</body>
</html>
