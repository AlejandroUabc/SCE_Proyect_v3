<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultar_reportes.aspx.cs" Inherits="SCE_Project.Consulta_reportes.Consultar_reportes" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="../Styles/StyleSheet.css" />
</head>
<body id="bodycr">
        <header id="headermenu"><h2>Sistema de Control de Entregas </h2></header>
        <form id="form1" runat="server">
    <nav id="navmenu">
           <ul>
        <a href="../Mantenimiento usuario/Menu_Usuario.aspx"><img id="imgmanb" src="../Imagenes/mant1.png"</a>
        <a href="../Mantenimiento Bitacora/MantBit.aspx"><img id="imgmaus" src="../Imagenes/mantusuario.jpg" /></a>
         <a href="Consultar_reportes.aspx"><img id="imgest" src="../Imagenes/estadisticas.jpg" /></a>
        <a href="../Menu_principal.aspx"><img id="imgmenu" src="../Imagenes/inicio.png" /></a>

        </ul>
        <p class="mu" >Mantenimiento <br /> a usuarios </p>
        <p class="mb" >Mantenimiento <br /> a bit&aacute;cora</p>
        <p class="es">Consultar<br /> reportes</p>
        <p class="men">Men&uacute;<br />Principal</p>
       
    </nav>
    <section id="sectioncr">
        <
        <h2>Consultar Reporte</h2>
        <asp:DropDownList ID="ddllista" runat="server">
            <asp:ListItem Text="Selecciona una opción..." Value="0"></asp:ListItem>
            <asp:ListItem Text="Tiempo en Ruta" Value="1"></asp:ListItem>
            <asp:ListItem Text="Km recorrido" Value="2"></asp:ListItem>
            <asp:ListItem Text="Número de Ordenes" Value="3"></asp:ListItem>
            <asp:ListItem Text="Estadísticas Generales" Value="4"></asp:ListItem>
        </asp:DropDownList>
        <div id="fecha">
        <asp:TextBox ID="txfecha1" runat="server" TextMode="Date"></asp:TextBox>
        <asp:TextBox ID="txfecha2" runat="server" TextMode="Date"></asp:TextBox>
        <asp:Label ID="etfecha1" runat="server" Text="Fecha Inicial:"></asp:Label>
        <asp:Label ID="etfecha2" runat="server" Text="Fecha Final:"></asp:Label>
        
        </div>
        <asp:Button ID="btest" runat="server" Text="Buscar" OnClick="btest_Click" />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>

    </section>   
        </form>
</body>
</html>
