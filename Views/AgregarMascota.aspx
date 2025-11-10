<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMascota.aspx.cs" Inherits="AsignacionSemana8.Views.AgregarMascota" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <title>Agregar Mascota</title>

    <!-- Biblioteca Bootstrap para estilos y componentes visuales -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css"
        rel="stylesheet"
        integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB"
        crossorigin="anonymous" />

    <!-- Scripts de Bootstrap para funcionalidad de botones, modal, etc -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI"
        crossorigin="anonymous"></script>

    <!-- Estilos propio del proyecto -->
    <link href="Estilos.css" rel="stylesheet" type="text/css" />

</head>
<body>

    <!-- Formulario WebForms principal -->
    <form id="form1" runat="server">

        <!-- Control necesario para componentes AJAX -->
        <asp:ScriptManager runat="server" ID="ScriptManager1" />

        <div class="container-vet">

            <!-- Título general del formulario -->
            <h2 class="page-title">🐾 Registro de Mascotas</h2>

            <!-- Mostrar usuario actualmente autenticado -->
            <div class="mb-3">
                <label class="form-label">Usuario Conectado</label>
                <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server" CssClass="form-control readonly-box" />
            </div>

            <!-- Sección de datos del propietario -->
            <div class="section-header">Datos del Propietario</div>

            <div class="row">

                <!-- Campo de identificación del propietario -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="txtPropietarioIdentificacion">Identificación</label>
                    <asp:TextBox ID="txtPropietarioIdentificacion" runat="server" CssClass="form-control"></asp:TextBox>

                    <!-- Validador obligatorio -->
                    <asp:RequiredFieldValidator runat="server" ID="rfvIdentificacion"
                        ControlToValidate="txtPropietarioIdentificacion"
                        CssClass="text-danger small"
                        ErrorMessage="Se debe de ingresar una Identificación" />
                </div>

                <!-- Botones de búsqueda y registro de propietario -->
                <div class="col-md-6 d-flex align-items-end mb-3">
                    <asp:Button Text="Buscar Propietario" runat="server" ID="btnBuscarPropietario" CssClass="btn btn-primary me-2" OnClick="btnBuscarPropietario_Click" />
                    <asp:Button Text="Agregar Propietario" runat="server" ID="btnAgregarPropietario" CssClass="btn btn-primary" OnClick="btnAgregarPropietario_Click" />
                </div>
            </div>

            <!-- Zona donde se muestran datos del propietario encontrado -->
            <div class="row">

                <div class="col-md-4 mb-3">
                    <label class="form-label" for="txtPropietarioNombre">Primer Nombre</label>
                    <asp:TextBox ID="txtPropietarioNombre" runat="server" CssClass="form-control readonly-box" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="col-md-4 mb-3">
                    <label class="form-label" for="txtApellido1">Primer Apellido</label>
                    <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control readonly-box" ReadOnly="true"></asp:TextBox>
                </div>

                <div class="col-md-4 mb-3">
                    <label class="form-label" for="txtApellido2">Segundo Apellido</label>
                    <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control readonly-box" ReadOnly="true"></asp:TextBox>
                </div>

            </div>

            <!-- Datos de contacto del propietario -->
            <div class="row">

                <!-- Correo -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="txtCorreo">Correo Electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator runat="server" ID="rfvCorreo"
                        ControlToValidate="txtCorreo"
                        CssClass="text-danger small"
                        ErrorMessage="Se debe de ingresar un correo" />

                    <!-- Validación de formato de correo -->
                    <asp:RegularExpressionValidator
                        runat="server"
                        ID="revCorreo"
                        ControlToValidate="txtCorreo"
                        CssClass="text-danger small"
                        ErrorMessage="El formato del correo no es válido"
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                        Display="Dynamic" />
                </div>

                <!-- Teléfono -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="txtCelular">Teléfono Celular</label>
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>

                    <asp:RequiredFieldValidator runat="server" ID="rfvCelular"
                        ControlToValidate="txtCelular"
                        CssClass="text-danger small"
                        ErrorMessage="Se debe un teléfono celular" />

                    <!-- Validación numérica -->
                    <asp:CompareValidator
                        runat="server"
                        ID="cvCelular"
                        ControlToValidate="txtCelular"
                        Operator="DataTypeCheck"
                        Type="Integer"
                        CssClass="text-danger small"
                        ErrorMessage="Debe ingresar solo números"
                        Display="Dynamic" />
                </div>

            </div>

            <!-- Botón para actualizar datos del propietario -->
            <asp:Button Text="Actualizar Datos" runat="server" ID="btnActualizar" CssClass="btn btn-primary mb-3" OnClick="btnActualizar_Click"/>

            <!-- Separador para sección de nueva mascota -->
            <div class="section-header">Datos de la Mascota</div>

            <!-- Datos de la mascota -->
            <div class="row">

                <!-- Nombre de la mascota -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="txtNombreMascota">Nombre Mascota</label>
                    <asp:TextBox ID="txtNombreMascota" runat="server" CssClass="form-control" Placeholder="Nombre de la mascota" />

                    <asp:RequiredFieldValidator runat="server" ID="rfvNombreMascota"
                        ControlToValidate="txtNombreMascota"
                        CssClass="text-danger small"
                        ErrorMessage="Se debe un ingresar un nombre para la mascota" />
                </div>

                <!-- Peso -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="txtPesoMascota">Peso (kg)</label>
                    <asp:TextBox ID="txtPesoMascota" runat="server" CssClass="form-control" Placeholder="Peso de la mascota" />

                    <asp:RequiredFieldValidator runat="server" ID="rfvPesoMascota"
                        ControlToValidate="txtPesoMascota"
                        CssClass="text-danger small"
                        ErrorMessage="Se debe un peso para la mascota" />

                    <!-- Validación numérica tipo decimal -->
                    <asp:CompareValidator
                        runat="server"
                        ID="cvPesoMascota"
                        ControlToValidate="txtPesoMascota"
                        Operator="DataTypeCheck"
                        Type="Double"
                        CssClass="text-danger small"
                        ErrorMessage="El peso debe ser un número válido (use punto decimal, por ejemplo: 5.3)."
                        Display="Dynamic" />
                </div>

            </div>

            <!-- Sexo y alergias -->
            <div class="row">

                <!-- Selección de sexo -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="ddlSexo">Sexo</label>
                    <asp:DropDownList runat="server" ID="ddlSexo" CssClass="form-select">
                        <asp:ListItem Text="Seleccione el sexo" Value="" />
                        <asp:ListItem Text="Macho" Value="M" />
                        <asp:ListItem Text="Hembra" Value="H" />
                    </asp:DropDownList>

                    <asp:RequiredFieldValidator
                        runat="server"
                        ID="rfvSexo"
                        ControlToValidate="ddlSexo"
                        InitialValue=""
                        CssClass="text-danger small"
                        ErrorMessage="Debe seleccionar el sexo de la mascota"
                        Display="Dynamic" />
                </div>

                <!-- Campo de alergias -->
                <div class="col-md-6 mb-3">
                    <label class="form-label" for="txtAlergiasMascota">Alergias</label>
                    <asp:TextBox ID="txtAlergiasMascota" runat="server" CssClass="form-control"
                        TextMode="MultiLine" Rows="3" Placeholder="Alergias conocidas" />

                    <asp:RequiredFieldValidator runat="server" ID="rfvAlergias"
                        ControlToValidate="txtPesoMascota"
                        CssClass="text-danger small"
                        ErrorMessage="Se debe rellenar este campo" />
                </div>

            </div>

            <!-- Fecha de nacimiento de la mascota -->
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                    <ContentTemplate>
                        <asp:Calendar runat="server" ID="cldFechaNacimiento" CssClass="calendar-basico"></asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <!-- Botones finales -->
            <div class="text-center mb-3">
                <asp:Button ID="btnGuardarMascota" runat="server" Text="Guardar Mascota" CssClass="btn btn-primary" OnClick="btnGuardarMascota_Click" />
                <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-primary" OnClick="btnLimpiar_Click" />
            </div>

            <!-- Etiqueta donde se muestran mensajes informativos -->
            <asp:Label ID="lblMensajeMascota" runat="server" CssClass="error-msg" />

            <!-- Sección de auditoría del registro -->
            <div class="footer-info mt-4">
                <h5 class="section-header">Información de Registro</h5>

                <div class="row">

                    <!-- Usuario que creó el registro -->
                    <div class="col-md-6 mb-2">
                        <label class="form-label">Adicionado Por</label>
                        <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server" CssClass="form-control readonly-box" />
                    </div>

                    <!-- Fecha de registro -->
                    <div class="col-md-6 mb-2">
                        <label class="form-label">Fecha de Adición</label>
                        <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server" CssClass="form-control readonly-box" />
                    </div>

                    <!-- Usuario que realizó la última modificación -->
                    <div class="col-md-6 mb-2">
                        <label class="form-label">Modificado Por</label>
                        <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server" CssClass="form-control readonly-box" />
                    </div>

                    <!-- Fecha de modificación -->
                    <div class="col-md-6 mb-2">
                        <label class="form-label">Fecha de Modificación</label>
                        <asp:TextBox ReadOnly="true" ID="txtFechaModificacion" runat="server" CssClass="form-control readonly-box" />
                    </div>

                </div>
            </div>

        </div>

        <!-- Script de Bootstrap -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>

    </form>

</body>
</html>
