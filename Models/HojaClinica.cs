using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AsignacionSemana8.Models
{
    public class HojaClinica
    {
        /// <summary>
        /// Identificador único de la hoja clínica.
        /// </summary>
        public int? HojaClinicaId { get; set; }

        /// <summary>
        /// Fecha en que se realizó la atención médica.
        /// </summary>
        public DateTime? FechaAtencion { get; set; }

        /// <summary>
        /// Descripción de los síntomas reportados por el paciente.
        /// </summary>
        public string Sintomas { get; set; }

        /// <summary>
        /// Diagnóstico realizado por el profesional de salud.
        /// </summary>
        public string Diagnostico { get; set; }

        /// <summary>
        /// Tratamiento indicado al paciente.
        /// </summary>
        public string Tratamiento { get; set; }

        /// <summary>
        /// Identificador del paciente o mascota atendida.
        /// </summary>
        public int? MascotaId { get; set; }

        /// <summary>
        /// Usuario que registró la hoja de atención.
        /// </summary>
        public string AdicionadoPor { get; set; }

        /// <summary>
        /// Fecha en que se agregó el registro.
        /// </summary>
        public DateTime? FechaAdicion { get; set; }

        /// <summary>
        /// Usuario que realizó la última modificación.
        /// </summary>
        public string ModificadoPor { get; set; }

        /// <summary>
        /// Fecha en que se realizó la última modificación del registro.
        /// </summary>
        public DateTime? FechaModificacion { get; set; }
    }
}