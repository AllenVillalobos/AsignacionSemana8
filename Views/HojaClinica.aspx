<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HojaClinica.aspx.cs" Inherits="AsignacionSemana8.Views.HojaClinica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Historial Clínico</title>
    <!-- Enlaza tus estilos -->
    <link rel="stylesheet" href="~/Estilos/main.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="clinica-container">

            <!-- Información del usuario y fecha de atención -->
            <div class="gradient-card">
                <!-- Muestra el nombre del usuario conectado -->
                <asp:Label runat="server">Usuario Conectado</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtUsuarios" runat="server" CssClass="form-control" /><br />
                <br />

                <!-- Muestra la fecha actual o fecha de atención -->
                <asp:Label runat="server">Fecha de Atención:</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFecha" runat="server" CssClass="form-control" />
            </div>

            <!-- Identificador y datos generales de la mascota -->
            <div class="gradient-card">

                <!-- Ingreso del ID de la mascota -->
                <asp:Label>Identificador de Mascotas</asp:Label><br />
                <asp:TextBox ID="txtIDMascota" runat="server" CssClass="form-control" /><br />
                <br />

                <!-- Botón para agregar una nueva mascota -->
                <asp:Button Text="Agregar" runat="server" ID="bntAgregarMascota"
                    CssClass="btn-primary" 
                    OnClick="bntAgregarMascota_Click"/>

                <!-- Botón para buscar una mascota existente por ID -->
                <asp:Button Text="Buscar" runat="server" ID="btnBuscar"
                    OnClick="btnBuscar_Click"
                    CssClass="btn-primary" /><br />
                <br />

                <!-- Nombre de la mascota (solo lectura) -->
                <asp:Label>Nombre de la Mascota</asp:Label><br />
                <asp:TextBox ID="txtNombreMas" runat="server" CssClass="form-control" ReadOnly="true" /><br />

                <!-- Peso de la mascota (solo lectura) -->
                <asp:Label>Peso Mascota (kg)</asp:Label><br />
                <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control" /><br />

                <!-- Sexo de la mascota (solo lectura) -->
                <asp:Label>Sexo</asp:Label><br />
                <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control" ReadOnly="true" /><br />

                <!-- Fecha de nacimiento de la mascota (solo lectura) -->
                <asp:Label>Fecha de Nacimiento</asp:Label><br />
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" ReadOnly="true" /><br />
                <br />

                <!-- Alergias registradas (editable) -->
                <asp:Label>Alergias</asp:Label><br />
                <asp:TextBox TextMode="MultiLine" Rows="3" runat="server"
                    ID="txtAlergias" CssClass="form-control" /><br />

                <!-- Botón para actualizar alergias u otros datos -->
                <asp:Button Text="Actualizar Datos" runat="server"
                    ID="btnActualizar"
                    OnClick="btnActualizar_Click"
                    CssClass="btn-primary" />
            </div>

            <!-- Tarjeta: Registro de síntomas, diagnóstico y tratamiento -->
            <div class="gradient-card">

                <!-- Campo para registrar síntomas observados -->
                <asp:Label>Síntomas:</asp:Label><br />
                <asp:TextBox TextMode="MultiLine" Rows="5" runat="server"
                    ID="txtSintomas" CssClass="form-control" /><br />

                <!-- Campo para escribir el diagnóstico realizado -->
                <asp:Label>Diagnóstico:</asp:Label><br />
                <asp:TextBox TextMode="MultiLine" Rows="5" runat="server"
                    ID="txtDiagnostico" CssClass="form-control" /><br />

                <!-- Campo para detallar el tratamiento asignado -->
                <asp:Label>Tratamiento:</asp:Label><br />
                <asp:TextBox TextMode="MultiLine" Rows="5" runat="server"
                    ID="txtTratamiento" CssClass="form-control" /><br />

                <!-- Botón para limpiar todos los campos de la hoja -->
                <asp:Button runat="server" Text="Limpiar Campos" ID="btnLimpiar"
                    CssClass="btn-primary" OnClick="btnLimpiar_Click" />

                <!-- Botón para guardar la hoja clínica -->
                <asp:Button runat="server" Text="Guardar Hoja" ID="btnGuardarHoja"
                    CssClass="btn-primary" OnClick="btnGuardarHoja_Click" />
            </div>

            <!-- Tarjeta: Información de auditoría (quién y cuándo modificó o agregó) -->
            <div class="gradient-card">
                <asp:Label>Adicionado Por</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtUsuario" runat="server" CssClass="form-control" /><br />

                <asp:Label>Fecha de Adición</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFechaAdicion" runat="server" CssClass="form-control" /><br />

                <asp:Label>Modificado Por</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtModificadoPor" runat="server" CssClass="form-control" /><br />

                <asp:Label>Fecha de Modificación</asp:Label><br />
                <asp:TextBox ReadOnly="true" ID="txtFechaModificacion" runat="server" CssClass="form-control" />
            </div>

            <!-- Mensaje de confirmación o error -->
            <asp:Label ID="txtMensaje" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
