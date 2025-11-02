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
        PropietarioDAO PropietarioDAO = new PropietarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnBuscarPropietario_Click(object sender, EventArgs e)
        {
            Propietario propietario = PropietarioDAO.ObtenerPropietario(txtPropietarioIdentificacion.Text);
            if (propietario != null)
            {
                txtPropietarioNombre.Text = propietario.PrimerNombre;
                txtApellido1.Text = propietario.PrimerApellido;
                txtApellido2.Text = propietario.SegundoApellido; 
                txtCorreo.Text = propietario.Correo;
                txtCelular.Text = propietario.Telefono;
            }
            else
            {

            }

        }
        public int EncontarIdPropietario(string identificacion)
        {
            Propietario propietario = PropietarioDAO.ObtenerPropietario(identificacion);
            return propietario.PropietarioId;
        }
        public void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPropietario.aspx");
        }

        public void btnGuardarMascota_Click(object sender, EventArgs e)
        {
            Mascota mascota = new Mascota();
            mascota.Nombre = txtNombreMascota.Text;
            mascota.FechaNacimiento = cldFechaNacimiento.SelectedDate;
            mascota.Sexo = ddlSexo.SelectedValue;
            mascota.Peso = float.Parse(txtPesoMascota.Text);
            mascota.Alergias = txtAlergiasMascota.Text;
            mascota.PropietarioId = EncontarIdPropietario(txtPropietarioIdentificacion.Text);
            mascota.AdicionadoPor = "admin";
            mascota.FechaAdicion = DateTime.Now;
            mascotaDAO.InsertarMascota(mascota);
        }
        public void btnbtnLimpiar_Click(object sender, EventArgs e)
        {
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
        }
    }
}