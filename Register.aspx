<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="FS_Bookstore.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Registration</title>
</head>
<body>
    <form id="form1" runat="server">

        <h3>User Registration</h3>

        Name:
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br /><br />

        Email:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br /><br />

        Password:
        <asp:TextBox ID="txtPassword"
            runat="server"
            TextMode="Password"></asp:TextBox>
        <br /><br />

        <asp:Button ID="btnRegister"
            runat="server"
            Text="Register"
            OnClick="btnRegister_Click" />
        <br /><br />

        <asp:Label ID="lblMsg"
            runat="server"
            ForeColor="Green"></asp:Label>

    </form>
</body>
</html>
