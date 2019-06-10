
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergioDelgadoProyecto
{
    public class LoginService
    {
        RestClient<UserDetailsCredentials> _restClient = new RestClient<UserDetailsCredentials>();
        /// <summary>
        /// Comprobacion del inicio de sesion
        /// </summary>
        /// <param name="username">Usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns></returns>
        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.checkLogin(username, password);
            Console.WriteLine("[CHEKEO] "+check.ToString());
            return check;
        }
    }
}
