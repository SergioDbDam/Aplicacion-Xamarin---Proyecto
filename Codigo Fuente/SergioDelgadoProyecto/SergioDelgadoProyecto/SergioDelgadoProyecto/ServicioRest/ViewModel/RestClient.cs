
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace SergioDelgadoProyecto
{
    
    public class RestClient<T>
    {
        public static int idMiembro;
        public static string rol;
        public static string resultado;
        public static string nombre;
        private const string MainWebServiceUrl = "http://damnation.ddns.net/sergio/";
        private const string LoginWebServiceUrl = MainWebServiceUrl+"sigmaP/login.php/?";
        /// <summary>
        /// Comprobacion del inicio de sesión
        /// </summary>
        /// <param name="username">usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns></returns>
        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();
            //respuestas de inicio de sesion 
            var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "&" + "password=" + password);
            var response1 =  await httpClient.GetStringAsync(LoginWebServiceUrl + "username=" + username + "&" + "password=" + password);
            UserDetailsCredentials userObj = JsonConvert.DeserializeObject<UserDetailsCredentials>(response1.ToString());
            //comprobaciones
            if (response1.Contains("null")) {
                resultado = "0";
            }
            if (!response1.Contains("null")){
                resultado = "1";
            }
            UserDetailsCredentials detalles = new UserDetailsCredentials();
            //Console.WriteLine("Respuesta Usuario "+resultado);
            Console.WriteLine("Respuesta: "+userObj.rol);
            Console.WriteLine("id : " + userObj.id);
            idMiembro = userObj.id;
            rol = userObj.rol;
            nombre = userObj.usuario;
            return response.IsSuccessStatusCode;
        }
    }

}