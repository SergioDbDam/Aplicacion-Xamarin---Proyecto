using System;
using System.Collections.Generic;
using System.Text;

namespace SergioDelgadoProyecto.ServicioRest
{
    /// <summary>
    /// Modelo de objetivos Cumplidos
    /// </summary>
    class Cumplidos
    {
        public int id { get; set; }
        public string objetivos { get; set; }
        public DateTime fecha { get; set; }
        public int cumplido { get; set; }
        public int registro_id { get; set; }
    }
}
