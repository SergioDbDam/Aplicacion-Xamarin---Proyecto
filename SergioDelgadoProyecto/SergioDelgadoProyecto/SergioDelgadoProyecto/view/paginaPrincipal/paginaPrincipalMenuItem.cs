using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergioDelgadoProyecto
{

    public class paginaPrincipalMenuItem
    {
        /// <summary>
        /// Modelo de los Objetos del Menú.
        /// </summary>
        public paginaPrincipalMenuItem()
        {
            TargetType = typeof(paginaPrincipalDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}