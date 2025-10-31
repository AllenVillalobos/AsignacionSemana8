using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AsignacionSemana8.Models
{
    public class Mascota
    {
        /// <summary>
        /// Identificador único de la mascota.
        /// </summary>
        public int MascotaId { get; set; }

        /// <summary>
        /// Nombre de la mascota.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Fecha de nacimiento de la mascota.
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// Sexo de la mascota (Macho o Hembra).
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Peso actual de la mascota (en kilogramos).
        /// </summary>
        public float Peso { get; set; }

        /// <summary>
        /// Alergias conocidas de la mascota.
        /// </summary>
        public string Alergias { get; set; }

        /// <summary>
        /// Identificador del propietario asociado.
        /// </summary>
        public int PropietarioId { get; set; }

        /// <summary>
        /// Usuario que registró la mascota.
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

        public Mascota()
        {
        }
    }
}