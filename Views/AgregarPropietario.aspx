<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPropietario.aspx.cs" Inherits="AsignacionSemana8.Views.AgregarPropietario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />

    <title>Registrar Dueño</title>

    <!-- Framework Bootstrap para estructura y estilos -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <!-- Estilos personalizado -->
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-vet">

            <!-- Distribución general usando el sistema de columnas -->
            <div class="row">

                <!-- Columna principal del formulario (datos del propietario) -->
                <div class="col-lg-7">

                    <!-- Muestra el usuario logueado -->
                    <div class="mb-3">
                        <label class="form-label">Usuario Conectado</label>
                        <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server"
                            CssClass="form-control readonly-box"></asp:TextBox>
                    </div>

                    <!-- Título del formulario -->
                    <h2 class="page-title">Registrar Dueño</h2>

                    <!-- Campo para identificación del dueño -->
                    <div class="mb-3">
                        <label for="txtIdentificacion" class="form-label">Identificación</label>
                        <asp:TextBox ID="txtIdentificacion" runat="server"
                            CssClass="form-control"
                            Placeholder="Identificación" />

                        <!-- Validador obligatorio -->
                        <asp:RequiredFieldValidator runat="server" ID="rfvIdentificacion"
                            ControlToValidate="txtIdentificacion"
                            CssClass="text-danger small"
                            ErrorMessage="Se debe de ingresar una Identificación" />
                    </div>

                    <!-- Primer nombre del dueño -->
                    <div class="mb-3">
                        <label for="txtNombreDueño1" class="form-label">Primer Nombre</label>
                        <asp:TextBox ID="txtNombreDueño1" runat="server"
                            CssClass="form-control"
                            Placeholder="Primer Nombre" />

                        <!-- Validador obligatorio -->
                        <asp:RequiredFieldValidator runat="server" ID="rfvNombre1"
                            ControlToValidate="txtNombreDueño1"
                            CssClass="text-danger small"
                            ErrorMessage="Se debe de ingresar un nombre" />
                    </div>

                    <!-- Segundo nombre del dueño -->
                    <div class="mb-3">
                        <label for="txtNombreDueño2" class="form-label">Segundo Nombre</label>
                        <asp:TextBox ID="txtNombreDueño2" runat="server"
                            CssClass="form-control"
                            Placeholder="Segundo Nombre" />
                    </div>

                    <!-- Primer apellido -->
                    <div class="mb-3">
                        <label for="txtApellidoDueño1" class="form-label">Primer Apellido</label>
                        <asp:TextBox ID="txtApellidoDueño1" runat="server"
                            CssClass="form-control"
                            Placeholder="Primer Apellido" />
                        <!-- Validador obligatorio -->
                        <asp:RequiredFieldValidator runat="server" ID="rvfApellido1"
                            ControlToValidate="txtApellidoDueño1"
                            CssClass="text-danger small"
                            ErrorMessage="Se debe de ingresar un nombre" />
                    </div>

                    <!-- Segundo apellido -->
                    <div class="mb-3">
                        <label for="txtApellidoDueño2" class="form-label">Segundo Apellido</label>
                        <asp:TextBox ID="txtApellidoDueño2" runat="server"
                            CssClass="form-control"
                            Placeholder="Segundo Apellido" />
                    </div>

                    <!-- Teléfono del propietario -->
                    <div class="mb-3">
                        <label for="txtTelefonoDueño" class="form-label">Teléfono</label>
                        <asp:TextBox ID="txtTelefonoDueño" runat="server"
                            CssClass="form-control"
                            Placeholder="12345678" />

                        <!-- Validador obligatorio -->
                        <asp:RequiredFieldValidator runat="server" ID="rfvCelular"
                            ControlToValidate="txtTelefonoDueño"
                            CssClass="text-danger small"
                            ErrorMessage="Se debe un teléfono celular" />

                        <!-- Validación numérica -->
                        <asp:CompareValidator
                            runat="server"
                            ID="cvCelular"
                            ControlToValidate="txtTelefonoDueño"
                            Operator="DataTypeCheck"
                            Type="Integer"
                            CssClass="text-danger small"
                            ErrorMessage="Debe ingresar solo números"
                            Display="Dynamic" />
                    </div>

                    <!-- Correo electrónico del propietario -->
                    <div class="mb-3">
                        <label for="txtEmailDueño" class="form-label">Correo electrónico</label>
                        <asp:TextBox ID="txtEmailDueño" runat="server"
                            CssClass="form-control"
                            Placeholder="correo@ejemplo.com" />

                        <!-- Validador obligatorio -->
                        <asp:RequiredFieldValidator runat="server" ID="rfvCorreo"
                            ControlToValidate="txtEmailDueño"
                            CssClass="text-danger small"
                            ErrorMessage="Se debe de ingresar un correo" />

                        <!-- Validación de formato de correo -->
                        <asp:RegularExpressionValidator
                            runat="server"
                            ID="revCorreo"
                            ControlToValidate="txtEmailDueño"
                            CssClass="text-danger small"
                            ErrorMessage="El formato del correo no es válido"
                            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                            Display="Dynamic" />
                    </div>

                    <!-- Botones de acción: Guardar y Limpiar -->
                    <div class="text-center mt-4">
                        <asp:Button ID="btnGuardarDueño" runat="server"
                            Text="Guardar Dueño"
                            CssClass="btn btn-primary"
                            OnClick="btnGuardarDueño_Click" />

                        <asp:Button ID="btnLimiar" runat="server"
                            Text="Limpiar"
                            CssClass="btn btn-primary"
                            OnClick="btnLimiar_Click" />
                    </div>

                    <!-- Mensaje dinámico para mostrar errores o confirmaciones -->
                    <asp:Label ID="lblMensaje" runat="server"
                        CssClass="error-msg" />
                </div>

                <!-- Columna lateral con información de auditoría -->
                <div class="col-lg-5">
                    <div class="footer-info">

                        <h5 class="section-header">Información de Auditoría</h5>

                        <!-- Usuario que adicionó el registro -->
                        <div class="mb-3">
                            <label class="form-label">Adicionado Por</label>
                            <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>

                        <!-- Fecha de creación -->
                        <div class="mb-3">
                            <label class="form-label">Fecha de Adición</label>
                            <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>

                        <!-- Usuario que modificó el registro -->
                        <div class="mb-3">
                            <label class="form-label">Modificado Por</label>
                            <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>

                        <!-- Fecha de última modificación -->
                        <div class="mb-3">
                            <label class="form-label">Fecha de Modificación</label>
                            <asp:TextBox ReadOnly="true" ID="txtFechaModificacion" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>

    <!-- Scripts de Bootstrap para funcionalidad de componentes -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
