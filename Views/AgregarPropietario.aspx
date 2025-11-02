<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPropietario.aspx.cs" Inherits="AsignacionSemana8.Views.AgregarPropietario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Registrar / Editar Dueño</title>
    <link rel="stylesheet" href="~/Estilos/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="clinica-container">

            <!-- Tarjeta principal para registrar o editar datos del dueño -->
            <div class="gradient-card">

                <!-- Muestra el nombre del usuario actualmente conectado -->
                <asp:Label runat="server">Usuario Conectado</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server"
                    CssClass="form-control"></asp:TextBox>

                <!-- Título principal del formulario -->
                <h2 class="page-title">Registrar / Editar Dueño</h2>

                <!-- Campo para escribir el número de identificación del dueño -->
                <label for="txtIdentificacion">Identificación</label>
                <asp:TextBox ID="txtIdentificacion" runat="server"
                    CssClass="form-control"
                    Placeholder="Identificación" />

                <!-- Primer nombre del dueño -->
                <label for="txtNombreDueño1">Primer Nombre</label>
                <asp:TextBox ID="txtNombreDueño1" runat="server"
                    CssClass="form-control"
                    Placeholder="Primer Nombre" />

                <!-- Segundo nombre del dueño (opcional) -->
                <label for="txtNombreDueño2">Segundo Nombre</label>
                <asp:TextBox ID="txtNombreDueño2" runat="server"
                    CssClass="form-control"
                    Placeholder="Segundo Nombre" />

                <!-- Primer apellido del dueño -->
                <label for="txtApellidoDueño1">Primer Apellido</label>
                <asp:TextBox ID="txtApellidoDueño1" runat="server"
                    CssClass="form-control"
                    Placeholder="Primer Apellido" />

                <!-- Segundo apellido del dueño -->
                <label for="txtApellidoDueño2">Segundo Apellido</label>
                <asp:TextBox ID="txtApellidoDueño2" runat="server"
                    CssClass="form-control"
                    Placeholder="Segundo Apellido" />

                <!-- Teléfono de contacto del dueño -->
                <label for="txtTelefonoDueño">Teléfono</label>
                <asp:TextBox ID="txtTelefonoDueño" runat="server"
                    CssClass="form-control"
                    Placeholder="1234-5678" />

                <!-- Correo electrónico del dueño -->
                <label for="txtEmailDueño">Correo electrónico</label>
                <asp:TextBox ID="txtEmailDueño" runat="server"
                    CssClass="form-control"
                    Placeholder="correo@ejemplo.com" />

                <!-- Botón para guardar los datos del dueño -->
                <asp:Button ID="btnGuardarDueño" runat="server"
                    Text="Guardar Dueño"
                    CssClass="btn-primary"
                    OnClick="btnGuardarDueño_Click" />

                <!-- Botón para limpiar todos los campos del formulario -->
                <asp:Button ID="btnLimiar" runat="server"
                    Text="Limpiar"
                    CssClass="btn-primary"
                    OnClick="btnLimiar_Click" />

                <!-- Área para mostrar mensajes al usuario (éxito o error) -->
                <asp:Label ID="lblMensaje" runat="server"
                    CssClass="error-msg" />
            </div>

            <!-- Tarjeta secundaria para mostrar información de auditoría -->
            <div class="gradient-card">

                <!-- Usuario que registró los datos -->
                <asp:Label>Adicionado Por</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server"
                    CssClass="form-control" /><br />

                <!-- Fecha en que se registraron los datos -->
                <asp:Label>Fecha de Adición</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server"
                    CssClass="form-control" /><br />

                <!-- Usuario que hizo la última modificación -->
                <asp:Label>Modificado Por</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server"
                    CssClass="form-control" /><br />

                <!-- Fecha de la última modificación -->
                <asp:Label>Fecha de Modificación</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFechaModificacion" runat="server"
                    CssClass="form-control" />
            </div>
        </div>
    </form>
</body>
</html>
