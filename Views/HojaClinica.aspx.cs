using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsignacionSemana8.Views
{
    public partial class HojaClinica : System.Web.UI.Page
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


        public void bntAgregarMascota_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMascota.aspx");
        }
        public void btnBuscar_Click(object sender, EventArgs e)
        {

        }
        public void btnActualizar_Click(object sender, EventArgs e)
        {

        }
        public void btnLimpiar_Click(object sender, EventArgs e)
        {

        }
        public void btnGuardarHoja_Click(object sender, EventArgs e)
        {

        }
    }
}