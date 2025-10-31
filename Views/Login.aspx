<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AsignacionSemana8.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="">
            <!-- Título del formulario de inicio de sesión -->
            <asp:Label runat="server" CssClass="login-title">Inicio de Sección</asp:Label>
            <br />

            <!-- Etiqueta para el campo de nombre de usuario -->
            <asp:Label runat="server" AssociatedControlID="txtNombre" CssClass="login-label"> Nombre De Usuario </asp:Label>
            <br />

            <!-- Campo para ingresar el nombre de usuario -->
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Placeholder="Usuario" />
            <br />
            <asp:RequiredFieldValidator runat="server" ID="rfvNombre"
                ControlToValidate="txtNombre"
                ErrorMessage="El nombre se debe de ingresar"></asp:RequiredFieldValidator>

            <!-- Etiqueta para el campo de contraseña -->
            <asp:Label runat="server" AssociatedControlID="txtContra" CssClass="login-label"> Ingresa La Clave </asp:Label>
            <br />

            <!-- Campo para ingresar la contraseña (oculta con asteriscos) -->
            <asp:TextBox runat="server" ID="txtContra" CssClass="form-control" TextMode="Password" Placeholder="••••••••" />
            <br />
            <asp:RequiredFieldValidator runat="server" ID="rfvContra"
                ControlToValidate="txtContra"
                ErrorMessage="La contraseña se debe de ingresar"></asp:RequiredFieldValidator>
            <!-- Botón para enviar los datos e intentar iniciar sesión -->
            <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn-primary" OnClick="btnIngresar_Click" />
            <br />
            <!-- Etiqueta para mostrar mensajes de error o información -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="error-msg" />
        </div>
    </form>
</body>
</html>
