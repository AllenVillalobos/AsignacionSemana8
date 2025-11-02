using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AsignacionSemana8.Models
{
    public class Propietario
    {
        /// <summary>
        /// Identificador único del propietario.
        /// </summary>
        public int PropietarioId { get; set; }

        /// <summary>
        /// Número de identificación del propietario.
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// Primer nombre del propietario.
        /// </summary>
        public string PrimerNombre { get; set; }

        /// <summary>
        /// Segundo nombre del propietario (opcional).
        /// </summary>
        public string SegundoNombre { get; set; }

        /// <summary>
        /// Primer apellido del propietario.
        /// </summary>
        public string PrimerApellido { get; set; }

        /// <summary>
        /// Segundo apellido del propietario (opcional).
        /// </summary>
        public string SegundoApellido { get; set; }

        /// <summary>
        /// Número de teléfono de contacto.
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// Correo electrónico del propietario.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Usuario que registró al propietario.
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
    }
}