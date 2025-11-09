using AsignacionSemana8.DAO;
using AsignacionSemana8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsignacionSemana8.Views
{
    public partial class AgregarPropietario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    txtUsuario.Text = Session["Usuario"].ToString();
                    txtUsuarios.Text = Session["Usuario"].ToString();
                    txtFechaAdicion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }
        public void btnGuardarDueño_Click(object sender, EventArgs e)
        {


            if (!Page.IsValid)
            {
                lblMensaje.Text = "Debe completar todos los campos correctamente.";
                return;
            }

            try
            {
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

                // Verificamos si ya existe el propietario en la base de datos
                var existente = propietarioDAO.ObtenerPropietario(propietario.Identificacion);

                if (existente == null)
                {
                    propietarioDAO.InsertarPropietario(propietario);
                    lblMensaje.Text = " Propietario guardado correctamente.";
                }
                else
                {
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
        public void btnLimiar_Click(object sender, EventArgs e)
        {

            // Limpiar campos del formulario principal
            txtIdentificacion.Text = string.Empty;
            txtNombreDueño1.Text = string.Empty;
            txtNombreDueño2.Text = string.Empty;
            txtApellidoDueño1.Text = string.Empty;
            txtApellidoDueño2.Text = string.Empty;
            txtTelefonoDueño.Text = string.Empty;
            txtEmailDueño.Text = string.Empty;

            // Limpiar campos de auditoría
            txtUsuario.Text = string.Empty;
            txtFechaAdicion.Text = string.Empty;
            txtModificadoPor.Text = string.Empty;
            txtFechaModificacion.Text = string.Empty;

            // Limpiar mensaje
            lblMensaje.Text = string.Empty;


        }

    }
}
