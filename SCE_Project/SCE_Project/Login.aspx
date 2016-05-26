<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SCE_Project.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="Styles/StyleSheet.css">
</head>
<body id="bodylog">
    <div id="divlogin">
        <div id="divlogin1"> <h1>SCE</h1> <br /> <p> Sistema de Control de Entregas</p></div>
        <div id="divlogin2">
    <form id="formlogin" runat="server" >

            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" FailureText="Error al iniciar sesión, intente de nuevo con un id de usuario y/ó un password correcto." ForeColor="Black" DisplayRememberMe="False" PasswordRequiredErrorMessage="Favor de insertar el password" UserNameRequiredErrorMessage="Favor de insertar un Id de usuario" ValidateRequestMode="Enabled" ViewStateMode="Enabled" LoginButtonText="Iniciar sesión" PasswordLabelText="Contraseña:" UserNameLabelText="Id de usuario:">
                <FailureTextStyle ForeColor="#663300" BorderStyle="None" />
                <ValidatorTextStyle BorderStyle="None" />
            </asp:Login>
            
        <p>
            &nbsp;</p>
    </form>
    
    <p>
        &nbsp;</p>
        </div>
        </div>
</body>
</html>
