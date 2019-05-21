using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergioDelgadoProyecto
{
    public class UserDetailsCredentials
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("usuario")]
        public string usuario { get; set; }
        [JsonProperty("contrasena")]
        public string contrasena { get; set; }
        [JsonProperty("rol")]
        public string rol { get; set; }
    }
}
