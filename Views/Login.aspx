<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AsignacionSemana8.Views.Login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Login - Veterinaria</title>

    <!-- Estilos de Bootstrap para diseño responsivo -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Estilos personalizado -->
    <link href="Estilos.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">

        <!-- Contenedor general del formulario de login -->
        <div class="login-container">

            <!-- Tarjeta principal dividida en dos secciones -->
            <div class="login-card d-flex flex-md-row flex-column">

                <!-- Sección izquierda: imagen decorativa del login -->
                <div class="col-md-6 login-image">
                    <!-- Imagen de fondo definida desde CSS para mantener limpieza visual -->
                    <img src="Recursos/Vete.png" />
                </div>

                <!-- Sección derecha: formulario de autenticación -->
                <div class="col-md-6 login-form">

                    <!-- Título del formulario -->
                    <asp:Label runat="server" CssClass="login-title">Inicio de Sesión</asp:Label>

                    <!-- Campo: Nombre de usuario -->
                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre de Usuario</label>

                        <!-- Caja de texto para ingresar el usuario -->
                        <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" Placeholder="Ingrese su usuario" />

                        <!-- Validación requerida para el campo usuario -->
                        <asp:RequiredFieldValidator runat="server" ID="rfvNombre"
                            ControlToValidate="txtNombre"
                            CssClass="text-danger small"
                            ErrorMessage="Debe ingresar su usuario" />
                    </div>

                    <!-- Campo: Contraseña -->
                    <div class="mb-3">
                        <label for="txtContra" class="form-label">Contraseña</label>

                        <!-- Caja de texto tipo contraseña -->
                        <asp:TextBox runat="server" ID="txtContra" CssClass="form-control" TextMode="Password" Placeholder="••••••••" />

                        <!-- Validación requerida para el campo contraseña -->
                        <asp:RequiredFieldValidator runat="server" ID="rfvContra"
                            ControlToValidate="txtContra"
                            CssClass="text-danger small"
                            ErrorMessage="Debe ingresar su contraseña" />
                    </div>

                    <!-- Botón para enviar las credenciales -->
                    <asp:Button runat="server" ID="btnIngresar" Text="Ingresar" CssClass="btn btn-primary mb-3" OnClick="btnIngresar_Click" />

                    <!-- Mensaje dinámico para mostrar errores o notificaciones -->
                    <asp:Label ID="lblMensaje" runat="server" CssClass="error-msg" />
                </div>
            </div>
        </div>
    </form>

    <!-- Script de Bootstrap para componentes interactivos -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
ss