<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMascota.aspx.cs" Inherits="AsignacionSemana8.Views.AgregarMascota" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
 <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>
    <title>Agregar Mascotas</title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager runat="server" ID="ScriptManager1" />

        <div class="clinica-container">
            <div class="gradient-card">
                <!--
                /// Muestra el usuario actualmente conectado al sistema
                -->
                <asp:Label runat="server">Usuario Conectado</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server" CssClass="form-control" /><br />

                <!--
                /// Título principal de la sección de registro de mascotas
                -->
                <h2 class="page-title">Agregar Mascota</h2>

                <!--
                /// Campo para ingresar la cédula del propietario para buscarlo
                -->
                <label for="txtPropietarioID">Dueño</label>
                <asp:TextBox ID="txtPropietarioIdentificacion" runat="server"
                    CssClass="form-control"></asp:TextBox>
                <br />

                <!--
                /// Botón para buscar los datos del propietario en la base de datos
                -->
                <asp:Button Text="Buscar Propietario" runat="server"
                     ID="btnBuscarPropietario"
                    CssClass="btn-primary" />

                <!--
                /// Botón para redirigir a la sección de agregar un nuevo propietario
                -->
                <asp:Button Text="Agregar Propietario" runat="server"
                    ID="btnAgregarPropietario"
                    CssClass="btn-primary" />

                <!--
                /// Muestra el primer nombre del propietario encontrado (solo lectura)
                -->
                <label for="txtPropietarioNombre">Primer Nombre</label>
                <asp:TextBox ID="txtPropietarioNombre" runat="server"
                    CssClass="form-control" ReadOnly="true"></asp:TextBox>

                <label for="txtApellido1">Primer Apellido</label>
                <asp:TextBox ID="txtApellido1" runat="server"
                    CssClass="form-control" ReadOnly="true"></asp:TextBox>

                <label for="txtApellido2">Segundo Apellido</label>
                <asp:TextBox ID="txtApellido2" runat="server"
                    CssClass="form-control" ReadOnly="true"></asp:TextBox>
                <br />

                <!--
                /// Campos editables para actualizar el correo y teléfono del propietario
                -->
                <label for="txtCorreo">Correo Electronico</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>

                <label for="txtCelular">Telefono Celular</label>
                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Button Text="Actulizar Datos" runat="server" ID="btnActualizar"
                    CssClass="btn-primary" />

                <!--
                /// Campos para registrar información de la nueva mascota
                -->
                <label for="txtNombreMascota">Nombre Mascota</label>
                <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="form-control"
                    Placeholder="Nombre de la mascota" />

                <label for="txtFechaNacimiento">Fecha de Nacimiento</label>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <asp:Calendar runat="server" ID="cldFechaNacimiento"
                            CssClass="calendar-basico"></asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <label for="txtPesoMascota">Peso (kg)</label>
                <asp:TextBox ID="txtPesoMascota" runat="server" CssClass="form-control"
                    Placeholder="Peso de la mascota" />

                <label for="ddlSexo">Sexo</label>
                <asp:DropDownList runat="server" ID="ddlSexo"></asp:DropDownList>

                <label for="txtAlergiasMascota">Alergias</label>
                <asp:TextBox ID="txtAlergiasMascota" runat="server" CssClass="form-control"
                    TextMode="MultiLine" Rows="3" Placeholder="Alergias conocidas" />

                <asp:Button ID="btnGuardarMascota" runat="server" Text="Guardar Mascota" CssClass="btn-primary"
                    />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn-primary"
                     />

                <!--
                /// Muestra mensajes de éxito o error al usuario
                -->
                <asp:Label ID="lblMensajeMascota" runat="server" CssClass="error-msg" />
            </div>

            <!--
            /// Sección que muestra metadatos sobre quién creó o modificó el registro
            -->
            <div class="gradient-card">
                <asp:Label runat="server">Adicionado Por</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server" CssClass="form-control" /><br />

                <asp:Label runat="server">Fecha de Adición</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server" CssClass="form-control" /><br />

                <asp:Label runat="server">Modificado Por</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server" CssClass="form-control" /><br />

                <asp:Label runat="server">Fecha de Modificación</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFechaModificacion" runat="server" CssClass="form-control" />
            </div>
        </div>
    </form>
</body>
</html>
