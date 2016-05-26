<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu_principal.aspx.cs" Inherits="SCE_Project.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="Styles/StyleSheet.css" type="text/css" />
</head>
<body id="bodymenu">
    <header id="headermenu"> <h2> Sistema de Control de Entregas</h2></header>
    <nav id="navmenu">
        
        
        <ul>
        <a href="Mantenimiento usuario/Menu_Usuario.aspx"><img id="imgmanb" src="Imagenes/mant1.png"</a>
        <a href="Mantenimiento Bitacora/MantBit.aspx"><img id="imgmaus" src="Imagenes/mantusuario.jpg" /></a>
         <a href="Consulta reportes/Consultar_reportes.aspx"><img id="imgest" src="Imagenes/estadisticas.jpg" /></a>
             <a href="Menu_principal.aspx"><img id="imgmenu" src="Imagenes/inicio.png" /></a>
        </ul>
        <p class="mu" >Mantenimiento <br /> a usuarios </p>
        <p class="mb" >Mantenimiento <br /> a bit&aacute;cora</p>
        <p class="es">Consultar<br /> reportes</p>
        <p class="men">Men&uacute;<br />Principal</p>
              
         <form id="formm" runat="server">
            <asp:LoginStatus ID="LoginStatus1" runat="server" LoginImageUrl="~/Imagenes/salir.png" LogoutImageUrl="~/Imagenes/salir.png" />
            </form> 
        <p class="sal">Cerrar Sesi&oacute;n</p>  
    </nav>
          
               
                  
</body>
</html>