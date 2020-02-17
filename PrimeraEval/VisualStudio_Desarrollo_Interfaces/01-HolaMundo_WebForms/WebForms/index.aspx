<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_01_HolaMundo_WebForms.WebForms.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            Nombre:
            <asp:TextBox ID="txtNombre" runat="server" ></asp:TextBox>
        </div>
        <p>
            Apellido:  <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
        </p>
        
        <p>
            Edad:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEdad" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="btnSaludar" runat="server" OnClick="Button1_Click" Text="Saludar" />
        </p>
        <p>
            <asp:Label ID="lblSaludo" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
