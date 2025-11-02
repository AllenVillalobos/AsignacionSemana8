using AsignacionSemana8.DAO;
using AsignacionSemana8.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AsignacionSemana8.Views
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioDAO usuarioDAO = new UsuarioDAO();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = usuarioDAO.Login(txtNombre.Text, txtContra.Text);
                if (usuario !=null)
                {
                    Session["Usuario"] = usuario.NombreUsuario;
                    Response.Redirect("HojaClinica.aspx");
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al iniciar sesión: " + ex.Message;
            }
        }
    }
}