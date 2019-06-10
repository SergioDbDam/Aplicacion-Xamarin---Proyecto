using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Modelo de los objetos del menú.
    /// </summary>
    public class paginaPrincipalMenuItemA
    {
        public paginaPrincipalMenuItemA()
        {
            TargetType = typeof(paginaPrincipalDetailA);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}