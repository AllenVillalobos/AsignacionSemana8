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
        MascotaDAO mascotaDAO = new MascotaDAO();
        PropietarioDAO propietarioDAO = new PropietarioDAO();

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
                    txtUsuarios.Text = Session["Usuario"].ToString();
                    txtFechaAdicion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txtUsuario.Text = txtUsuarios.Text;
                }
            }
        }

        public void btnBuscarPropietario_Click(object sender, EventArgs e)
        {
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
                Propietario propietario = propietarioDAO.ObtenerPropietario(txtPropietarioIdentificacion.Text);

                if (propietario != null)
                {
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

        public int EncontarIdPropietario(string identificacion)
        {
            Propietario propietario = propietarioDAO.ObtenerPropietario(identificacion);
            return Convert.ToInt32(propietario.PropietarioId);
        }

        public void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPropietario.aspx");
        }

        public void btnGuardarMascota_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                lblMensajeMascota.Text = "Debe completar todos los campos correctamente.";
                return;
            }

            try
            {
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

                mascotaDAO.InsertarMascota(mascota);
                lblMensajeMascota.Text = "Mascota guardada correctamente.";
            }
            catch (Exception)
            {
                lblMensajeMascota.Text = "Error al guardar la mascota.";
            }
        }

        public void btnLimpiar_Click(object sender, EventArgs e)
        {
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

            txtAlergiasMascota.Text = "";
            txtNombreMascota.Text = "";
            cldFechaNacimiento.SelectedDate = DateTime.Now;
            txtPesoMascota.Text = "";
            ddlSexo.SelectedIndex = 0;
            txtPropietarioIdentificacion.Text = "";
            txtPropietarioNombre.Text = "";
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtCorreo.Text = "";
            txtCelular.Text = "";
            lblMensajeMascota.Text = "";

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
    }
}