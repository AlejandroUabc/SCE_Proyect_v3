<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="elimBit.aspx.cs" Inherits="SCE_Project.Mantenimiento_Bitacora.elimBit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Bitácora</title>
    <link rel="stylesheet" href="../Styles/elimBit.css" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
    <div>
    <asp:Label ID="etNom" runat="server" Text="Nombre del chofer: "></asp:Label>
        <asp:DropDownList ID="ddlLista" runat="server">
            <asp:ListItem Value="0">Todos los choferes</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="etFechaInic" runat="server" Text="Fecha inicial: "></asp:Label>
        <asp:TextBox ID="txFechaInic" runat="server" TextMode="Date"  required="required"></asp:TextBox>
        <asp:Label ID="etFechaFin" runat="server" Text="Fecha final: "></asp:Label>
        <asp:TextBox ID="txFechaFin" runat="server" TextMode="Date" required="required"></asp:TextBox>
        <asp:Button ID="btBuscar" runat="server" Text="Buscar Bitácora" OnClick="btBuscar_Click" />
    </div>

        <div id="GridView">
            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical">
             <asp:GridView ID="gdvBit" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gdv1_SelectedIndexChanged1" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                 <AlternatingRowStyle BackColor="White" />
                 <Columns>
                     <asp:BoundField DataField="idBitacoraid" HeaderText="ID Bitácora" SortExpression="idBitacoraid" />
                     <asp:BoundField DataField="nomUsu" HeaderText="Nombre" SortExpression="nomUsu" />
                     <asp:BoundField DataField="fecha" HeaderText="Fecha" SortExpression="fecha" />
                     <asp:BoundField DataField="noRuta" HeaderText="Número de ruta" SortExpression="noRuta" />
                     <asp:BoundField DataField="noCam" HeaderText="Número de camión" SortExpression="noCam" />
                     <asp:CommandField ShowSelectButton="True" SelectText="Seleccionar" />
                 </Columns>
                 <FooterStyle BackColor="#CCCC99" />
                 <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                 <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                 <RowStyle BackColor="#F7F7DE" />
                 <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                 <SortedAscendingCellStyle BackColor="#FBFBF2" />
                 <SortedAscendingHeaderStyle BackColor="#848384" />
                 <SortedDescendingCellStyle BackColor="#EAEAD3" />
                 <SortedDescendingHeaderStyle BackColor="#575357" />
             </asp:GridView>
         </asp:Panel>
            </div>
        
        <asp:Button ID="btEliminar"  runat="server" Text="Eliminar Bitácora" OnClick="btEliminar_Click" OnClientClick='javascript:return confirm("Seguro que desea eliminar el registro?")' />
        <asp:Label ID="etNom2" runat="server" Text="idBitacora"></asp:Label>
    </form>
</body>
</html>
