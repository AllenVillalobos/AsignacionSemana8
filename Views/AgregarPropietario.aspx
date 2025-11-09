<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPropietario.aspx.cs" Inherits="AsignacionSemana8.Views.AgregarPropietario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registrar / Editar Dueño</title>
    
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    
    <!-- Tu CSS personalizado -->
    <link href="Estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-vet">
            <div class="row">
                <!-- Columna principal -->
                <div class="col-lg-7">
                    <!-- Usuario Conectado -->
                    <div class="mb-3">
                        <label class="form-label">Usuario Conectado</label>
                        <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server"
                            CssClass="form-control readonly-box"></asp:TextBox>
                    </div>

                    <!-- Título -->
                    <h2 class="page-title">Registrar / Editar Dueño</h2>

                    <!-- Identificación -->
                    <div class="mb-3">
                        <label for="txtIdentificacion" class="form-label">Identificación</label>
                        <asp:TextBox ID="txtIdentificacion" runat="server"
                            CssClass="form-control"
                            Placeholder="Identificación" />
                    </div>

                    <!-- Primer Nombre -->
                    <div class="mb-3">
                        <label for="txtNombreDueño1" class="form-label">Primer Nombre</label>
                        <asp:TextBox ID="txtNombreDueño1" runat="server"
                            CssClass="form-control"
                            Placeholder="Primer Nombre" />
                    </div>

                    <!-- Segundo Nombre -->
                    <div class="mb-3">
                        <label for="txtNombreDueño2" class="form-label">Segundo Nombre</label>
                        <asp:TextBox ID="txtNombreDueño2" runat="server"
                            CssClass="form-control"
                            Placeholder="Segundo Nombre" />
                    </div>

                    <!-- Primer Apellido -->
                    <div class="mb-3">
                        <label for="txtApellidoDueño1" class="form-label">Primer Apellido</label>
                        <asp:TextBox ID="txtApellidoDueño1" runat="server"
                            CssClass="form-control"
                            Placeholder="Primer Apellido" />
                    </div>

                    <!-- Segundo Apellido -->
                    <div class="mb-3">
                        <label for="txtApellidoDueño2" class="form-label">Segundo Apellido</label>
                        <asp:TextBox ID="txtApellidoDueño2" runat="server"
                            CssClass="form-control"
                            Placeholder="Segundo Apellido" />
                    </div>

                    <!-- Teléfono -->
                    <div class="mb-3">
                        <label for="txtTelefonoDueño" class="form-label">Teléfono</label>
                        <asp:TextBox ID="txtTelefonoDueño" runat="server"
                            CssClass="form-control"
                            Placeholder="1234-5678" />
                    </div>

                    <!-- Correo electrónico -->
                    <div class="mb-3">
                        <label for="txtEmailDueño" class="form-label">Correo electrónico</label>
                        <asp:TextBox ID="txtEmailDueño" runat="server"
                            CssClass="form-control"
                            Placeholder="correo@ejemplo.com" />
                    </div>

                    <!-- Botones -->
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

                    <!-- Mensaje -->
                    <asp:Label ID="lblMensaje" runat="server"
                        CssClass="error-msg" />
                </div>

                <!-- Columna de auditoría -->
                <div class="col-lg-5">
                    <div class="footer-info">
                        <h5 class="section-header">Información de Auditoría</h5>
                        
                        <!-- Adicionado Por -->
                        <div class="mb-3">
                            <label class="form-label">Adicionado Por</label>
                            <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>

                        <!-- Fecha de Adición -->
                        <div class="mb-3">
                            <label class="form-label">Fecha de Adición</label>
                            <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>

                        <!-- Modificado Por -->
                        <div class="mb-3">
                            <label class="form-label">Modificado Por</label>
                            <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server"
                                CssClass="form-control readonly-box" />
                        </div>

                        <!-- Fecha de Modificación -->
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
    
    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>