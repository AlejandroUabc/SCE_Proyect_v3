<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modificar Usuario.aspx.cs" Inherits="SCE_Project.Mantenimiento_usuario.Modificar_Usuario" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modificar usuario</title>
    <link rel="stylesheet" href="../Styles/mantUsuario.css" type="text/css" />
    <script type="text/javascript">
        function ocultarPass() {
            var control = document.getElementById("ddlTipoUsu");
            var password = document.getElementById("txContra");
            var lpassword = document.getElementById("etContra");
            var bc = document.getElementById("btModificarC");
            var bs = document.getElementById("btModificarS");
            var reqVal = document.getElementById("rfvContra");
            var regVal = document.getElementById("revContra");
            if (control.value == 1) {
                password.style.visibility = "visible";
                //bc.style.visibility = "hidden";
                //bs.style.visibility = "visible";
                bc.style.display = "none";
                bs.style.display = "block";
                regVal.style.visibility = "visible";
                reqVal.style.visibility = "visible";
                lpassword.style.visibility = "visible";
            } else {
                password.style.visibility = "hidden";
                //bc.style.visibility = "visible";
                //bs.style.visibility = "hidden";
                bc.style.display = "block";
                bs.style.display = "none";
                regVal.style.visibility = "hidden";
                reqVal.style.visibility = "hidden";
                lpassword.style.visibility = "hidden";
            }
        }
        function cargar() {
            var bs = document.getElementById("btModificarC");
            var password = document.getElementById("txContra");
            var lpassword = document.getElementById("etContra");
            var reqVal = document.getElementById("rfvContra");
            var regVal = document.getElementById("revContra");
            regVal.style.visibility = "hidden";
            reqVal.style.visibility = "hidden";
            password.style.visibility = "hidden";
            lpassword.style.visibility = "hidden";
            //bs.style.visibility = "hidden";
            bs.style.display = "none";
        }
    </script>
</head>
<body>
     <header class="headercr">
        <h2 id="titulo">Modificar usuarios</h2></header>
    <form id="form1" runat="server">
    <div id="formModificar">
    
        <asp:Label ID="etIdUsu" runat="server" Text="Id usuario a modificar"></asp:Label>
        <asp:TextBox ID="txIdUsu" runat="server" Width="200px"></asp:TextBox>
        <asp:Button ID="btBuscar" runat="server" Text="Buscar" OnClick="btBuscar_Click" ValidationGroup="idVal" />
         <asp:RequiredFieldValidator ID="rfvIdUsu" runat="server" ControlToValidate="txIdUsu" Display="Dynamic" ErrorMessage="ID vacio" ValidationGroup="idVal"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revIdUsu" runat="server" ControlToValidate="txIdUsu" Display="Dynamic" ErrorMessage="El ID es numerico" ValidationExpression="^\d+$" ValidationGroup="idVal"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="etNom" runat="server" Text="Nombre"></asp:Label>
        <asp:TextBox ID="txNom" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvNomC" runat="server" ControlToValidate="txNom" Display="Dynamic" ErrorMessage="Nombre vacio" ValidationGroup="chofer"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revNomC" runat="server" ControlToValidate="txNom" Display="Dynamic" ErrorMessage="Solo caracteres" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="chofer"></asp:RegularExpressionValidator>
       
        <asp:RequiredFieldValidator ID="rfvNomS" runat="server" ControlToValidate="txNom" Display="Dynamic" ErrorMessage="Nombre vacio" ValidationGroup="super"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revNomS" runat="server" ControlToValidate="txNom" Display="Dynamic" ErrorMessage="Solo caracteres" ValidationExpression="^[a-zA-Z''-'\s]{1,40}$" ValidationGroup="super"></asp:RegularExpressionValidator>
        <br />
        <asp:Label ID="etTipoUsu" runat="server" Text="Tipo de usuario"></asp:Label>
        <asp:DropDownList ID="ddlTipoUsu" runat="server" Width="200px" onchange="ocultarPass();">
            <asp:ListItem>Tipo de usuario</asp:ListItem>
            <asp:ListItem Value="1">Supervisor</asp:ListItem>
            <asp:ListItem Value="2">Chofer</asp:ListItem>
            
        </asp:DropDownList>
         <asp:RequiredFieldValidator ID="rfvTipo" runat="server" ControlToValidate="ddlTipoUsu" Display="Dynamic" ErrorMessage="Selecione un tipo de usuario" InitialValue="Tipo de usuario" ValidationGroup="chofer"></asp:RequiredFieldValidator>
    
        <asp:RequiredFieldValidator ID="rfvTipoS" runat="server" ControlToValidate="ddlTipoUsu" Display="Dynamic" ErrorMessage="Selecione un tipo de usuario" InitialValue="Tipo de usuario" ValidationGroup="super"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="etContra" runat="server" Text="Contraseña"></asp:Label>
        <asp:TextBox ID="txContra" runat="server" Width="200px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvContra" runat="server" ControlToValidate="txContra" Display="Dynamic" ErrorMessage="pass vacio" ValidationGroup="super"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revContra" runat="server" ControlToValidate="txContra" Display="Dynamic" ErrorMessage="minimo 8 caracteres" ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,10})$" ValidationGroup="super"></asp:RegularExpressionValidator>
        <br />
        <asp:Button ID="btModificarS" runat="server" Text="Modificar" OnClick="btModificarS_Click" ValidationGroup="super" style="height: 26px" />
        <asp:Button ID="btModificarC" runat="server" Text="Modificar" OnClick="btModificarC_Click" ValidationGroup="chofer" />
        <asp:Button ID="btCancelar" runat="server" CausesValidation="False" OnClick="btCancelar_Click" Text="Cancelar" />
        <br />
    
    </div>
    </form>
</body>
</html>
