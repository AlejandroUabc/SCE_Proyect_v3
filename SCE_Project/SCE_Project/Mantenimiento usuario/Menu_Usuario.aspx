<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_Usuario.aspx.cs" Inherits="SCE_Project.Mantenimiento_usuario.Menu_Usuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MANTENIMIENTO A USUARIO</title>
     <script type="text/javascript" src="../Scripts/funcion.js"></script>
    <link rel="stylesheet" href="../Styles/MantBit.css" type="text/css" />
</head>
<body id="bodymenu">
 
    <form id="form1" runat="server">
            <div id="headermenu">
                <h2>Sistema de Control de Entregas</h2>
            </div>

        <div id="MenuImg">    
        <ul>
         <li><a href="../Mantenimiento usuario/Menu_Usuario.aspx"><asp:Image  ID="imgmanb" runat="server" ImageUrl="~/Imagenes/mant1.png" /></a></li>
         <li><a href="../Mantenimiento Bitacora/MantBit.aspx"><asp:Image id="imgmaus"  runat="server" ImageUrl="~/Imagenes/mantusuario.jpg" /></a></li>
         <li><a href="../Consulta reportes/Consultar_reportes.aspx"><asp:Image runat="server" id="imgest" ImageUrl="~/Imagenes/estadisticas.jpg" /></a></li>
         <li><a href="../Menu_principal.aspx"><asp:Image ID="imgmenu" runat="server" ImageUrl="~/Imagenes/inicio.png" /></a></li>
        </ul>
            <asp:Label ID="etMantUs" runat="server" Text="Mantenimiento<br> a usuarios"></asp:Label>
            <asp:Label ID="etMantB" runat="server" Text="Mantenimiento<br> a bitácora"></asp:Label>
            <asp:Label ID="etGenRep" runat="server" Text="Consultar<br> Reportes"></asp:Label>
            <asp:Label ID="etmenu" runat="server" Text="Menú <br> Principal"></asp:Label>
    </div>

        <h2>Mantenimiento a usuarios</h2>

    <nav id="MenuMantBit">
        <ul> 
        <li><a    onclick="mostrar('Registar Usuarios.aspx')">Registar</a></li> 
        <li><a   onclick="mostrar('Modificar Usuario.aspx')" >Modificar</a></li>
        <li><a   onclick="mostrar('Consultar Usuarios.aspx')">Consultar</a></li>
        <li><a   onclick="mostrar('Eliminar Usuario.aspx')">Eliminar</a></li>
        </ul>
            </nav>
   <section id="frame1">
            <iframe id="prog" src="about:blank" width="1250" height="700" frameborder="1"></iframe>
    </section>
    </form>
     
</body>
</html>
