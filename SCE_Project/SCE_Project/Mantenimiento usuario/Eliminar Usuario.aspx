<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Eliminar Usuario.aspx.cs" Inherits="SCE_Project.Mantenimiento_usuario.Eliminar_Usuario" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eliminar usuario</title>
    <link rel="stylesheet" href="../Styles/mantUsuarioEliminar.css" type="text/css" />
</head>
<body>
     
        
    <form id="form1" runat="server">

    <div id="formEliminar">
        <header><h2>Eliminar usuarios</h2></header>
        
        <asp:Label ID="etIdUsu" runat="server" Text="Id del usuario a eliminar"></asp:Label>
        <asp:TextBox ID="txIdUsu" runat="server"></asp:TextBox>
        <asp:Button ID="btBuscar" runat="server" OnClick="btBuscar_Click" Text="Buscar" />
         <asp:RequiredFieldValidator ID="rfvIdUsu" runat="server" ControlToValidate="txIdUsu" Display="Dynamic" ErrorMessage="ID vacio"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revIdUsu" runat="server" ControlToValidate="txIdUsu" Display="Dynamic" ErrorMessage="El ID es numerico" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
<br />
        <asp:Label ID="etNom" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txNom" runat="server" Enabled="False" ></asp:TextBox>
        <br />
        <asp:Label ID="etTipoUsu" runat="server" Text="Tipo de usuario"></asp:Label>
        <asp:TextBox ID="txTipoUsu" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="etContra" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="txContra" runat="server" Enabled="False"></asp:TextBox>
    
        <br />
        <asp:Button ID="btEliminar" runat="server" Text="Eliminar" OnClick="btEliminar_Click" />
        <br />
    
    </div>
    </form>
</body>
</html>