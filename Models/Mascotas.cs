using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace AsignacionSemana8.Models
{
    public class Mascotas
    {
        public int MAS_ID { get; set; }
        public string MAS_NOMBRE { get; set; }
        public DateTime MAS_FECHA_NACIMIENTO { get; set; }
        public string MAS_SEXO { get; set; }
        public float MAS_PESO { get; set; }
        public string MAS_ALERGIAS { get; set; }
        public int MAS_PRO_ID { get; set; }
        public string MAS_ADICIONADO_POR { get; set; }
        public DateTime MAS_FECHA_ADICION { get; set; }
        public string MAS_MODIFICADO_POR { get; set; }
        public DateTime MAS_FECHA_MODIFICACION { get; set; }
        public Mascotas()
        {
        }
    }
}