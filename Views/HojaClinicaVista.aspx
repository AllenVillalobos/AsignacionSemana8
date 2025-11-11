<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HojaClinicaVista.aspx.cs" Inherits="AsignacionSemana8.Views.HojaClinicaVista" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Historial Clínico - Veterinaria</title>

    <!-- Bootstrap -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Estilos.css" rel="stylesheet" type="text/css" />

    <style>
        .clinica-container {
            max-width: 1100px;
            margin: 50px auto;
            background-color: #fff;
            border-radius: 20px;
            box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
            padding: 40px 50px;
        }

        .clinica-header {
            color: #1e7b5e;
            font-weight: 600;
            text-align: center;
            font-size: 1.8rem;
            margin-bottom: 30px;
        }

        .gradient-card {
            background-color: #e9fdf4;
            border-radius: 12px;
            padding: 20px;
            margin-bottom: 25px;
        }

        .form-label {
            color: #1e7b5e;
            font-weight: 500;
        }

        .btn-primary {
            background-color: #1e7b5e;
            border: none;
            border-radius: 8px;
            margin-right: 5px;
        }

            .btn-primary:hover {
                background-color: #16644c;
            }

        .readonly-box {
            background-color: #f9f9f9;
        }

        .footer-info {
            background-color: #e9fdf4;
            border-radius: 12px;
            padding: 20px;
            margin-top: 30px;
        }

        .text-primary {
            color: #1e7b5e !important;
        }

        @media (max-width: 768px) {
            .clinica-container {
                padding: 30px 20px;
                margin: 20px;
            }
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="clinica-container">
            <div class="clinica-header">Historial Clínico</div>

            <!-- Usuario y fecha -->
            <div class="gradient-card">
                <label class="form-label">Usuario Conectado</label>
                <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server" CssClass="form-control mb-2 readonly-box" />
                <label class="form-label">Fecha de Atención</label>
                <asp:TextBox ReadOnly="true" ID="txtFecha" runat="server" CssClass="form-control readonly-box" />
            </div>

            <!-- Datos de mascota -->
            <div class="gradient-card">
                <label class="form-label">Identificador de Mascota</label>
                <asp:TextBox ID="txtIDMascota" runat="server" CssClass="form-control mb-3" />
                <asp:RequiredFieldValidator ID="rfvIDMascota" runat="server" ControlToValidate="txtIDMascota" ErrorMessage="El peso es obligatorio." CssClass="text-danger" Display="Dynamic" />
                <br />

                <div class="mb-3">
                    <asp:Button Text="Agregar" runat="server" ID="bntAgregarMascota"
                        CssClass="btn btn-primary" OnClick="bntAgregarMascota_Click" />
                    <asp:Button Text="Buscar" runat="server" ID="btnBuscar"
                        CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                </div>

                <label class="form-label">Nombre de la Mascota</label>
                <asp:TextBox ID="txtNombreMas" runat="server" CssClass="form-control mb-2 readonly-box" ReadOnly="true" />
                <label class="form-label">Peso Mascota (kg)</label>
                <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control mb-2" />
                <asp:RequiredFieldValidator ID="rfvPeso" runat="server" ControlToValidate="txtPeso" ErrorMessage="El peso es obligatorio." CssClass="text-danger" Display="Dynamic" />
                <br />
                <asp:CompareValidator runat="server" ID="cvPesoMascota" ControlToValidate="txtPeso" Operator="DataTypeCheck"
                    Type="Double" CssClass="text-danger small" ErrorMessage="El peso debe ser un número válido (use punto decimal, por ejemplo: 5.3)." Display="Dynamic" />
                <br />

                <label class="form-label">Sexo</label>
                <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control mb-2 readonly-box" ReadOnly="true" />
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control mb-3 readonly-box" ReadOnly="true" />
                <label class="form-label">Alergias</label>
                <asp:TextBox TextMode="MultiLine" Rows="3" runat="server"
                    ID="txtAlergias" CssClass="form-control mb-3" />
                <asp:RequiredFieldValidator ID="rfvAlergias" runat="server" ControlToValidate="txtAlergias" ErrorMessage="Debe registrar las alergias o indicar 'Ninguna' o similares."
                    CssClass="text-danger" Display="Dynamic" />
                <br />
                <asp:Button Text="Actualizar Datos" runat="server"
                    ID="btnActualizar" CssClass="btn btn-primary" OnClick="btnActualizar_Click" />
            </div>

            <!-- Registro clínico -->
            <div class="gradient-card">
                <label class="form-label">Síntomas</label>
                <asp:TextBox TextMode="MultiLine" Rows="3" runat="server"
                    ID="txtSintomas" CssClass="form-control mb-2" />
                <asp:RequiredFieldValidator ID="rfvSintomas" runat="server" ControlToValidate="txtSintomas"
                    ErrorMessage="Debe ingresar los síntomas." CssClass="text-danger" Display="Dynamic" />
                <br />
                <label class="form-label">Diagnóstico</label>
                <asp:TextBox TextMode="MultiLine" Rows="3" runat="server"
                    ID="txtDiagnostico" CssClass="form-control mb-2" />
                <asp:RequiredFieldValidator ID="rfvDiagnostico" runat="server" ControlToValidate="txtDiagnostico"
                    ErrorMessage="Debe ingresar un diagnóstico." CssClass="text-danger" Display="Dynamic" />
                <br />
                <label class="form-label">Tratamiento</label>
                <asp:TextBox TextMode="MultiLine" Rows="3" runat="server"
                    ID="txtTratamiento" CssClass="form-control mb-3" />
                <asp:RequiredFieldValidator ID="rfvTratamiento" runat="server" ControlToValidate="txtTratamiento"
                    ErrorMessage="Debe ingresar un tratamiento." CssClass="text-danger" Display="Dynamic" />
                <br />
                <asp:Button runat="server" Text="Limpiar Campos" ID="btnLimpiar"
                    CssClass="btn btn-secondary me-2" OnClick="btnLimpiar_Click" />
                <asp:Button runat="server" Text="Guardar Hoja" ID="btnGuardarHoja"
                    CssClass="btn btn-primary" OnClick="btnGuardarHoja_Click" />
            </div>

            <!-- Auditoría -->
            <div class="gradient-card">
                <label class="form-label">Adicionado Por</label>
                <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server" CssClass="form-control mb-2 readonly-box" />
                <label class="form-label">Fecha de Adición</label>
                <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server" CssClass="form-control mb-2 readonly-box" />
                <label class="form-label">Modificado Por</label>
                <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server" CssClass="form-control mb-2 readonly-box" />
                <label class="form-label">Fecha de Modificación</label>
                <asp:TextBox ReadOnly="true" ID="txtFechaModificacion" runat="server" CssClass="form-control readonly-box" />
            </div>

            <!-- Mensaje -->
            <asp:Label ID="txtMensaje" runat="server" CssClass="text-center fw-bold text-primary d-block mt-3"></asp:Label>

        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
