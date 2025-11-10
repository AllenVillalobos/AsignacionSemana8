using AsignacionSemana8.DAO;
using AsignacionSemana8.Models;
using System;
using System.Web.UI;

namespace AsignacionSemana8.Views
{
    public partial class AgregarPropietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validación: si no hay usuario en sesión, redirige al Login
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    // Carga de auditoría
                    txtUsuario.Text = Session["Usuario"].ToString();
                    txtUsuarios.Text = Session["Usuario"].ToString();
                    txtFechaAdicion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }

        /// <summary>
        /// Guarda o actualiza un propietario según exista en la base de datos.
        /// </summary>
        public void btnGuardarDueño_Click(object sender, EventArgs e)
        {
            // Validación general del formulario
            if (!Page.IsValid)
            {
                lblMensaje.Text = "Debe completar todos los campos correctamente.";
                return;
            }

            try
            {
                // Creación de objeto propietario con datos del formulario
                Propietario propietario = new Propietario
                {
                    Identificacion = txtIdentificacion.Text.Trim(),
                    PrimerNombre = txtNombreDueño1.Text.Trim(),
                    SegundoNombre = txtNombreDueño2.Text.Trim(),
                    PrimerApellido = txtApellidoDueño1.Text.Trim(),
                    SegundoApellido = txtApellidoDueño2.Text.Trim(),
                    Telefono = txtTelefonoDueño.Text.Trim(),
                    Correo = txtEmailDueño.Text.Trim(),
                    AdicionadoPor = txtUsuarios.Text.Trim(),
                    FechaAdicion = DateTime.Now
                };

                PropietarioDAO propietarioDAO = new PropietarioDAO();

                // Consulta para verificar si el propietario ya existe
                var existente = propietarioDAO.ObtenerPropietario(propietario.Identificacion);

                if (existente == null)
                {
                    // Inserción si no existe
                    propietarioDAO.InsertarPropietario(propietario);
                    lblMensaje.Text = "Propietario guardado correctamente.";
                }
                else
                {
                    // Actualización si existe
                    propietario.PropietarioId = existente.PropietarioId;
                    propietario.ModificadoPor = txtUsuarios.Text.Trim();
                    propietario.FechaModificacion = DateTime.Now;

                    propietarioDAO.ActualizarPropietario(propietario);
                    lblMensaje.Text = "Propietario actualizado correctamente.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al guardar el propietario: " + ex.Message;
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario 
        /// </summary>
        public void btnLimiar_Click(object sender, EventArgs e)
        {
            // Limpieza de campos generales
            txtIdentificacion.Text = string.Empty;
            txtNombreDueño1.Text = string.Empty;
            txtNombreDueño2.Text = string.Empty;
            txtApellidoDueño1.Text = string.Empty;
            txtApellidoDueño2.Text = string.Empty;
            txtTelefonoDueño.Text = string.Empty;
            txtEmailDueño.Text = string.Empty;

            // Limpieza de información de auditoría
            txtUsuario.Text = string.Empty;
            txtFechaAdicion.Text = string.Empty;
            txtModificadoPor.Text = string.Empty;
            txtFechaModificacion.Text = string.Empty;

            // Limpieza de mensajes
            lblMensaje.Text = string.Empty;
        }
    }
}
