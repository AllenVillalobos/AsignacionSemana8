using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AsignacionSemana8.Models
{
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Nombre de usuario utilizado para el inicio de sesión.
        /// </summary>
        public string NombreUsuario { get; set; }

        /// <summary>
        /// Contraseña del usuario (debe almacenarse encriptada).
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Estado del usuario (Activo, Inactivo, etc.).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Usuario que realizó el registro.
        /// </summary>
        public string AdicionadoPor { get; set; }

        /// <summary>
        /// Fecha en que se agregó el registro.
        /// </summary>
        public DateTime FechaAdicion { get; set; }

        /// <summary>
        /// Usuario que realizó la última modificación.
        /// </summary>
        public string ModificadoPor { get; set; }

        /// <summary>
        /// Fecha de la última modificación del registro.
        /// </summary>
        public DateTime FechaModificacion { get; set; }

        public Usuario()
        {
        }
    }
}