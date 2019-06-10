using System;
using System.Collections.Generic;
using System.Text;

namespace SergioDelgadoProyecto.ServicioRest
{
    /// <summary>
    /// Modelo de Objetivos
    /// </summary>
    public class Model_Post
    {
        public int id { get; set; }
        public string objetivos { get; set; }
        public DateTime fecha { get; set; }
        public int registro_id { get; set; }

    }
}
