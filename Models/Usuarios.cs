using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AsignacionSemana8.Models
{
    public class Usuarios
    {
        public int USU_ID { get; set; }
        public string USU_USUARIO { get; set; }
        public string USU_CLAVE { get; set; }
        public string USU_ESTADO { get; set; }
        public string USU_ADICIONADO_POR { get; set; }
        public DateTime USU_FECHA_ADICION { get; set; }
        public string USU_MODIFICADO_POR { get; set; }
        public DateTime USU_FECHA_MODIFICACION { get; set; }

        public Usuarios()
        {
        }
    }
}