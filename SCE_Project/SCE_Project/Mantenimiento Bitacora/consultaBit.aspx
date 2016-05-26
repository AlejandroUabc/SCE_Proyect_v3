<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consultaBit.aspx.cs" Inherits="SCE_Project.Mantenimienro_Bitacora.consultaBit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Consulta Bitácora</title>
    <script type="text/javascript" src="../Scripts/funcion.js"></script>
    <link rel="stylesheet" href="../Styles/consultaBit.css" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
    <div id="principal">
    <div id="botones" >
         <asp:Label ID="etNom" runat="server" Text="Nombre del chofer: "></asp:Label>
        <asp:DropDownList ID="ddlNom" runat="server">
            <asp:ListItem Value="0">Todos los choferes</asp:ListItem>
        </asp:DropDownList>
        <asp:Label ID="etFechaInic" runat="server" Text="Fecha inicial: "></asp:Label>
        <asp:TextBox ID="txFechaInic" runat="server" TextMode="Date"  required="required"></asp:TextBox>
        <asp:Label ID="etFechaFin" runat="server" Text="Fecha final: "></asp:Label>
        <asp:TextBox ID="txFechaFin" runat="server" TextMode="Date" required="required" ValidateRequestMode="Enabled"></asp:TextBox>
        <asp:Button ID="btBuscar" runat="server" Text="Buscar Bitácora" OnClick="btBuscar_Click" />
    </div>

        <div id="GridView">
            <asp:Panel ID="Panel1" runat="server">
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
         
        <div id="form">
        <asp:Panel ID="camion" runat="server">
        <legend>Datos Papeleo</legend>
    <br /><br />
    <asp:Label ID="etFechaCon" runat="server" Text="Fecha: "></asp:Label>
    <asp:TextBox class="tx" ID="txFechaCon" runat="server" required="required" Enabled="False"></asp:TextBox>

    <br /><br /><br />
    <asp:Label ID="etNumRem" runat="server" Text="Número de remisión: "></asp:Label>
    <asp:TextBox class="tx" ID="txNumRem"  type="text" requiredField="required" placeholder="" runat="server" ValidateRequestMode="Inherit" ></asp:TextBox>
    <br /><br /><br />
    <asp:Label ID="etRevPapCon" runat="server" Text="Revisión papeleo:"></asp:Label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ControlToValidate="ddlRevPapCon" Display="Dynamic" InitialValue="0" BorderStyle="None" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:TextBox ID="ddlRevPapCon" runat="server" Enabled="False"></asp:TextBox>
            <br /><br />
        <br /><br />
            </asp:Panel>

        <asp:Panel ID="camion2" runat="server">
        <legend>Datos camión</legend>
        <p>
        <asp:Label ID="etNumRuta" runat="server" Text="Número de ruta: "></asp:Label>
        <asp:TextBox class="tx" ID="txNumRuta"  type="text" required="required" placeholder="" runat="server" maxlength="30" pattern="[\d\ ]{0,12}"></asp:TextBox>
        <br /><br />
        <asp:Label class="lb" ID="etNumCam" runat="server" Text="Número de camión: "></asp:Label>
        <asp:TextBox class="tx" ID="txNumCam" runat="server" type="text" placeholder="" required="required" maxlength="30" pattern="[\d\ ]{0,12}"></asp:TextBox>
        <br /><br />
        <asp:Label ID="etHS" runat="server" Text="Hora de salida: "></asp:Label>
        <asp:TextBox class="tx" ID="txHS" runat="server" type="time" required="required"></asp:TextBox>
        <br /><br />
        <asp:Label class="lb" ID="etHR" runat="server" Text="Hora de regreso: "></asp:Label>
        <asp:TextBox class="tx" ID="txHR" runat="server" type="time" required="required" Width="102px"></asp:TextBox>
        <br /><br />
        <asp:Label  ID="etKmInic" runat="server" Text="Kilometraje inicial: "></asp:Label>
        <asp:TextBox class="tx" ID="txKmInic"  type="text" required="required" placeholder="" runat="server"  maxlength="30" pattern="[\d\ ]{0,12}" Height="22px"></asp:TextBox><asp:RegularExpressionValidator ID="revkmInic" runat="server" ValidationExpression="^\d+$" ControlToValidate="txKmInic" ErrorMessage="*" Display="Dynamic"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:Label class="lb" ID="etKmFin" runat="server" Text="Kilometraje final: "></asp:Label>
        <asp:TextBox class="tx" ID="txKmFin"  type="text" required="required" placeholder="" runat="server" maxlength="30" pattern="[\d\ ]{0,12}"></asp:TextBox>
        <br /><br />
        <asp:Label class="lbCaja" ID="etNumCaja" runat="server" Text="Número de caja: "></asp:Label>
        <asp:TextBox class="tx" ID="txNumCaja" runat="server" type="text" placeholder="" required="required" maxlength="30" pattern="[\d\ ]{0,12}"></asp:TextBox>
        <br /><br />
        <asp:Label class="lb" ID="etCapCon" runat="server" Text="Capacidad del camión:"></asp:Label>
            <asp:TextBox ID="ddlCapCon" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDdlCap" runat="server" ErrorMessage="*" ControlToValidate="ddlCapCon" Display="Dynamic" InitialValue="0" BorderStyle="None" Font-Size="Medium" ForeColor="Red"></asp:RequiredFieldValidator>
            <br /><br />
        <asp:Label Class="etComRuta" ID="etComRuta" runat="server" Text="Comentario sobre ruta: "></asp:Label><br />
            <asp:TextBox ID="txComRuta" type="text" runat="server" TextMode="MultiLine"></asp:TextBox>
        </p>
        </asp:Panel>

        
         <asp:Panel ID="camion3" runat="server">
        <legend>Datos del cliente</legend>
        <p>
                <asp:Label ID="etNomCli" runat="server" Text="Nombre del cliente: "></asp:Label>
                <asp:TextBox Class="tx" ID="txNomCli"  type="text" required="required" placeholder="" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Label ID="etHoraLlegada" runat="server" Text="Hora de llegada con el cliente: "></asp:Label>
                <asp:TextBox class="tx" ID="txHoraLlegada"  type="time" required="required" placeholder="" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Label ID="etHoraSal" runat="server" Text="Hora de salida con el cliente: "></asp:Label>
                <asp:TextBox ID="txHoraSal"  type="time" required="required" placeholder="" runat="server"></asp:TextBox>
                <br /><br />
                <asp:Label ID="etTD" runat="server" Text="Tiempo en descargar: "></asp:Label>
                 <asp:TextBox ID="txTD"  type="text" required="required" placeholder="" maxlength="30" pattern="[\d\ ]{0,12}" runat="server" Width="200px"></asp:TextBox><asp:Label ID="etMin" runat="server" Text="Min."></asp:Label>
                <br /><br />
                <asp:Label class="etComCli" ID="etComCli" runat="server" Text="Comentario sobre cliente: "></asp:Label><br />
                <asp:TextBox ID="txComCli" type="text" runat="server" TextMode="MultiLine"></asp:TextBox>
            </p>
        <br />
       <asp:Label ID="etNom2" runat="server" Text="idBitacora" Visible="False"></asp:Label>
    </asp:Panel>
            </div>
   </div>
    </form>

</body>
</html>

