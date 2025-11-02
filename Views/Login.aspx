<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AsignacionSemana8.Views.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login - Veterinaria</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Estilos.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <div class="login-card d-flex flex-md-row flex-column">
                <!-- Imagen lateral -->
                <div class="col-md-6 login-image">
                    <!-- Puedes cambiar la imagen en ../Images/veterinaria.jpg -->
                </div>

                <!-- Formulario -->
                <div class="col-md-6 login-form">
                    <asp:Label runat="server" CssClass="login-title">Inicio de Sesión</asp:Label>

                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre de Usuario</label>
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Placeholder="Ingrese su usuario" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvNombre"
                            ControlToValidate="txtNombre"
                            CssClass="text-danger small"
                            ErrorMessage="Debe ingresar su usuario" />
                    </div>

                    <div class="mb-3">
                        <label for="txtContra" class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" ID="txtContra" CssClass="form-control" TextMode="Password" Placeholder="••••••••" />
                        <asp:RequiredFieldValidator runat="server" ID="rfvContra"
                            ControlToValidate="txtContra"
                            CssClass="text-danger small"
                            ErrorMessage="Debe ingresar su contraseña" />
                    </div>

                    <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary mb-3" OnClick="btnIngresar_Click" />

                    <asp:Label ID="lblMensaje" runat="server" CssClass="error-msg" />
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
