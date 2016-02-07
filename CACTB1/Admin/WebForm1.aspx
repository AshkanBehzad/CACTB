<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CACTB1.Admin.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="grd" runat="server" AllowPaging="True" OnPageIndexChanging="grd_PageIndexChanging" PageSize="4"></asp:GridView>
    </div>
    </form>
</body>
</html>
