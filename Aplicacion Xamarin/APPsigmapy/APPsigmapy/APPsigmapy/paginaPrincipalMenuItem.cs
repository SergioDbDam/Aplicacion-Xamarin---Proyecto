using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPsigmapy
{

    public class paginaPrincipalMenuItem
    {
        public paginaPrincipalMenuItem()
        {
            TargetType = typeof(paginaPrincipalDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}