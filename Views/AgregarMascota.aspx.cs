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
    public partial class AgregarMascota : System.Web.UI.Page
    {
        // DAO para gestionar Mascotas
        MascotaDAO mascotaDAO = new MascotaDAO();

        // DAO para gestionar Propietarios
        PropietarioDAO propietarioDAO = new PropietarioDAO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Si no hay usuario en sesión → redirige al login
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    // Muestra el usuario conectado
                    txtUsuarios.Text = Session["Usuario"].ToString();

                    // Carga valores de auditoría
                    txtFechaAdicion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtUsuario.Text = txtUsuarios.Text;
                }
            }
        }

        /// <summary>
        /// Evento del botón Buscar Propietario.
        /// Realiza una consulta por identificación y carga los datos en pantalla.
        /// Desactiva temporalmente los validadores para permitir búsqueda.
        /// </summary>
        public void btnBuscarPropietario_Click(object sender, EventArgs e)
        {
            // Deshabilita validaciones para evitar errores mientras se consulta
            rfvCorreo.Enabled = false;
            revCorreo.Enabled = false;
            rfvCelular.Enabled = false;
            cvCelular.Enabled = false;
            rfvNombreMascota.Enabled = false;
            rfvPesoMascota.Enabled = false;
            cvPesoMascota.Enabled = false;
            rfvSexo.Enabled = false;
            rfvAlergias.Enabled = false;

            try
            {
                // Obtiene el propietario según la identificación ingresada
                Propietario propietario = propietarioDAO.ObtenerPropietario(txtPropietarioIdentificacion.Text);

                if (propietario != null)
                {
                    // Carga los datos en los campos respectivos
                    txtPropietarioNombre.Text = propietario.PrimerNombre;
                    txtApellido1.Text = propietario.PrimerApellido;
                    txtApellido2.Text = propietario.SegundoApellido;
                    txtCorreo.Text = propietario.Correo;
                    txtCelular.Text = propietario.Telefono;
                    lblMensajeMascota.Text = "";
                }
                else
                {
                    lblMensajeMascota.Text = "No se encontró al propietario.";
                }
            }
            catch (Exception)
            {
                lblMensajeMascota.Text = "Error al buscar el propietario.";
            }

            // Reactiva los validadores
            rfvCorreo.Enabled = true;
            revCorreo.Enabled = true;
            rfvCelular.Enabled = true;
            cvCelular.Enabled = true;
            rfvNombreMascota.Enabled = true;
            rfvPesoMascota.Enabled = true;
            cvPesoMascota.Enabled = true;
            rfvSexo.Enabled = true;
            rfvAlergias.Enabled = true;
        }

        /// <summary>
        /// Busca el ID del propietario según la identificación.
        /// </summary>
        /// <param name="identificacion">Número de identificación del propietario.</param>
        /// <returns>ID del propietario encontrado.</returns>
        public int EncontarIdPropietario(string identificacion)
        {
            Propietario propietario = propietarioDAO.ObtenerPropietario(identificacion);
            return Convert.ToInt32(propietario.PropietarioId);
        }

        /// <summary>
        /// Redirige a la página para agregar un nuevo propietario.
        /// </summary>
        public void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPropietario.aspx");
        }

        /// <summary>
        /// Guarda los datos de la mascota ingresada en el formulario.
        /// Incluye validaciones, creación de objeto y llamado al DAO.
        /// </summary>
        public void btnGuardarMascota_Click(object sender, EventArgs e)
        {
            // Verifica si la página cumple validaciones
            if (!Page.IsValid)
            {
                lblMensajeMascota.Text = "Debe completar todos los campos correctamente.";
                return;
            }

            try
            {
                // Crea la instancia de Mascota con los datos ingresados
                Mascota mascota = new Mascota
                {
                    Nombre = txtNombreMascota.Text,
                    FechaNacimiento = cldFechaNacimiento.SelectedDate,
                    Sexo = ddlSexo.SelectedValue,
                    Peso = float.Parse(txtPesoMascota.Text),
                    Alergias = txtAlergiasMascota.Text,
                    PropietarioId = EncontarIdPropietario(txtPropietarioIdentificacion.Text),
                    AdicionadoPor = txtUsuarios.Text,
                    FechaAdicion = DateTime.Now
                };

                // Guarda la mascota
                mascotaDAO.InsertarMascota(mascota);

                lblMensajeMascota.Text = "Mascota guardada correctamente.";
            }
            catch (Exception)
            {
                lblMensajeMascota.Text = "Error al guardar la mascota.";
            }
        }

        /// <summary>
        /// Limpia el formulario completo
        /// </summary>
        public void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Desactiva validadores para evitar errores durante el reseteo
            rfvIdentificacion.Enabled = false;
            rfvCorreo.Enabled = false;
            revCorreo.Enabled = false;
            rfvCelular.Enabled = false;
            cvCelular.Enabled = false;
            rfvNombreMascota.Enabled = false;
            rfvPesoMascota.Enabled = false;
            cvPesoMascota.Enabled = false;
            rfvSexo.Enabled = false;
            rfvAlergias.Enabled = false;

            // Limpia campos de mascota
            txtAlergiasMascota.Text = "";
            txtNombreMascota.Text = "";
            cldFechaNacimiento.SelectedDate = DateTime.Now;
            txtPesoMascota.Text = "";
            ddlSexo.SelectedIndex = 0;

            // Limpia campos del propietario
            txtPropietarioIdentificacion.Text = "";
            txtPropietarioNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
            lblMensajeMascota.Text = "";

            // Reactiva validadores
            rfvIdentificacion.Enabled = true;
            rfvCorreo.Enabled = true;
            revCorreo.Enabled = true;
            rfvCelular.Enabled = true;
            cvCelular.Enabled = true;
            rfvNombreMascota.Enabled = true;
            rfvPesoMascota.Enabled = true;
            cvPesoMascota.Enabled = true;
            rfvSexo.Enabled = true;
            rfvAlergias.Enabled = true;
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón "Actualizar Datos".
        /// Actualiza la información del propietario sin validar los campos
        /// correspondientes a la mascota.  
        /// </summary>
        public void btnActualizar_Click(object sender, EventArgs e)
        {
            // Deshabilitar validadores de mascota para permitir actualizar solo propietario
            rfvNombreMascota.Enabled = false;
            rfvPesoMascota.Enabled = false;
            cvPesoMascota.Enabled = false;
            rfvSexo.Enabled = false;
            rfvAlergias.Enabled = false;

            try
            {
                // Crear objeto propietario con los valores ingresados
                Propietario propietario = new Propietario();
                propietario.Identificacion = txtPropietarioIdentificacion.Text;
                propietario.PrimerNombre = txtPropietarioNombre.Text;
                propietario.PrimerApellido = txtApellido1.Text;
                propietario.SegundoApellido = txtApellido2.Text;
                propietario.Correo = txtCorreo.Text;
                propietario.Telefono = txtCelular.Text;
                propietario.ModificadoPor = txtUsuarios.Text;

                // Ejecutar actualización en la base de datos
                int resultado = propietarioDAO.ActualizarPropietario(propietario);

                // Verificar resultado
                if (resultado != 0)
                {
                    // Actualizar campos de auditoría
                    txtModificadoPor.Text = txtUsuarios.Text;
                    txtFechaModificacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    lblMensajeMascota.Text = "Propietario actualizado correctamente";
                }
                else
                {
                    lblMensajeMascota.Text = "No se pudo actualizar el propietario";
                }
            }
            catch
            {
                // Error general en el proceso
                lblMensajeMascota.Text = "Error al actualizar el propietario";
            }

            // Volver a habilitar validadores de mascota
            rfvNombreMascota.Enabled = true;
            rfvPesoMascota.Enabled = true;
            cvPesoMascota.Enabled = true;
            rfvSexo.Enabled = true;
            rfvAlergias.Enabled = true;
        }

    }
}
