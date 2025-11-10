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
    public partial class HojaClinicaVista : System.Web.UI.Page
    {
        HojaClinicaDAO hojaClinicaDAO = new HojaClinicaDAO();
        MascotaDAO mascotaDAO = new MascotaDAO();

        public int MascotaId { get; private set; }

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
                    txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            }
        }


        public void bntAgregarMascota_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMascota.aspx");
        }
        public void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var mascota = mascotaDAO.BuscarMascotaPorID(Convert.ToInt32(txtIDMascota.Text));
                if (mascota != null)
                {
                    txtNombreMas.Text = mascota.Nombre;
                    txtFechaNacimiento.Text = mascota.FechaNacimiento?.ToString("dd/MM/yyyy");
                    txtSexo.Text = mascota.Sexo;
                    txtPeso.Text = mascota.Peso.ToString();
                    txtAlergias.Text = mascota.Alergias;
                }
                else
                {
                    txtMensaje.Text = "Mascota no encontrada.";
                }
            }
            catch (Exception ex)
            {
                txtMensaje.Text = "Error al buscar la mascota: " + ex.Message;
            }
        }
        public void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Mascota mascota = new Mascota
                {
                    MascotaId = Convert.ToInt32(txtIDMascota.Text),
                    Nombre = txtNombreMas.Text,
                    FechaNacimiento = DateTime.Parse(txtFechaNacimiento.Text),
                    Sexo = txtSexo.Text,
                    Peso = float.Parse(txtPeso.Text),
                    Alergias = txtAlergias.Text,
                    ModificadoPor = txtUsuario.Text,
                    FechaModificacion = DateTime.Now
                };
                int actualizado = mascotaDAO.ActualizarMascota(mascota);
                if (actualizado != 0)
                {
                    txtModificadoPor.Text = txtUsuario.Text;
                    txtFechaModificacion.Text = txtFecha.Text;
                    txtMensaje.Text = "Mascota actualizada correctamente.";
                }
                else
                {
                    txtMensaje.Text = "No se pudo actualizar la mascota.";
                }
            }
            catch
            {
                txtMensaje.Text = "Error al actualizar la mascota.";
            }
        }
        public void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIDMascota.Text = "";
            txtNombreMas.Text = "";
            txtFechaNacimiento.Text = "";
            txtSexo.Text = "";
            txtPeso.Text = "";
            txtAlergias.Text = "";
            txtSintomas.Text = "";
            txtDiagnostico.Text = "";
            txtTratamiento.Text = "";
            txtMensaje.Text = "";
        }
        public void btnGuardarHoja_Click(object sender, EventArgs e)
        {
            try
            {
                HojaClinica hojaClinica = new HojaClinica();
                hojaClinica.MascotaId = Convert.ToInt32(txtIDMascota.Text);
                hojaClinica.FechaAtencion = DateTime.Parse(txtFecha.Text);
                hojaClinica.Sintomas = txtSintomas.Text;
                hojaClinica.Diagnostico = txtDiagnostico.Text;
                hojaClinica.Tratamiento = txtTratamiento.Text;
                hojaClinica.AdicionadoPor = txtUsuarios.Text;
                hojaClinica.FechaAdicion = DateTime.Now;
                int resultado = hojaClinicaDAO.CrearAtencion(hojaClinica);
                if (resultado > 0)
                {
                    txtMensaje.Text = "Hoja clínica guardada correctamente.";
                }
                else
                {
                    txtMensaje.Text = "Error al guardar la hoja clínica.";
                }
            }
            catch (Exception ex)
            {
                txtMensaje.Text = "Error al guardar la hoja clínica: " + ex.Message;
            }
        }
    }
}