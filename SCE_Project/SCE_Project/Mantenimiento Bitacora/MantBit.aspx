<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantBit.aspx.cs" Inherits="SCE_Project.Mantenimienro_Bitacora.MantBit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MANTENIMIENTO A BITÁCORA</title>
    <link rel="stylesheet" href="../Styles/MantBit.css" type="text/css" />
    <script type="text/javascript" src="../Scripts/funcion.js"></script>
</head>
<body id="bodymenu">
    <div id="headermenu">
      <h2>Sistema de Control de Entregas</h2>
    </div>

    <div id="MenuImg">    
        <ul>
         <li><a href="../Mantenimiento usuario/Menu_Usuario.aspx"><asp:Image  ID="imgmanb" runat="server" ImageUrl="~/Imagenes/mant1.png" /></a></li>
         <li><a href="MantBit.aspx"><asp:Image id="imgmaus"  runat="server" ImageUrl="~/Imagenes/mantusuario.jpg" /></a></li>
         <li><a href="../Consulta reportes/Consultar_reportes.aspx"><asp:Image runat="server" id="imgest" ImageUrl="~/Imagenes/estadisticas.jpg" /></a></li>
         <li><a href="../Menu_principal.aspx"><asp:Image ID="imgmenu" runat="server" ImageUrl="~/Imagenes/inicio.png" /></a></li>
        </ul>
        <asp:Label ID="etMantUs" runat="server" Text="Mantenimiento<br> a usuarios"></asp:Label>
        <asp:Label ID="etMantB" runat="server" Text="Mantenimiento<br> a bitácora"></asp:Label>
        <asp:Label ID="etGenRep" runat="server" Text="Consultar<br> Reportes"></asp:Label>
        <asp:Label ID="etmenu" runat="server" Text="Menú <br> Principal"></asp:Label>
    </div>

    <h2>Mantenimiento a bitácora</h2>

    <nav id="MenuMantBit">
        <ul >
   	    <li><a onclick="mostrar('generarBit.aspx')">Registrar</a></li> 
	    <li><a onClick="mostrar('modBit.aspx')">Modificar</a></li>    
	    <li><a onclick="mostrar('consultaBit.aspx')">Consultar</a></li> 
	    <li><a onClick="mostrar('elimBit.aspx')">Eliminar</a></li>
	  </ul>
    </nav>

    <section id="frame1">
            <iframe id="prog" src="about:blank" width="1250" height="700" frameborder="1"></iframe>
    </section>

</body>
</html>

