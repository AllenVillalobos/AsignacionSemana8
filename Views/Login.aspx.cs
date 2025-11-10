using AsignacionSemana8.DAO;
using AsignacionSemana8.Models;
using System;
using System.Web.UI;

namespace AsignacionSemana8.Views
{
    public partial class Login : System.Web.UI.Page
    {
        // DAO encargado de realizar la validación contra la base de datos
        UsuarioDAO usuarioDAO = new UsuarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Evento del botón Ingresar.
        /// Valida credenciales, crea sesión y redirige a HojaClinica si es correcto.
        /// </summary>
        public void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Llamada al método Login del DAO para validar usuario/contraseña
                Usuario usuario = usuarioDAO.Login(txtNombre.Text, txtContra.Text);

                if (usuario != null)
                {
                    // Usuario encontrado: se crea sesión y se redirige
                    Session["Usuario"] = usuario.NombreUsuario;
                    Response.Redirect("HojaClinicaVista.aspx");
                }
                else
                {
                    // Credenciales incorrectas
                    lblMensaje.Text = "Usuario o contraseña incorrectos";
                }
            }
            catch (Exception ex)
            {
                // Error en la ejecución del procedimiento o conexión
                lblMensaje.Text = "Error al iniciar sesión: " + ex.Message;
            }
        }
    }
}
