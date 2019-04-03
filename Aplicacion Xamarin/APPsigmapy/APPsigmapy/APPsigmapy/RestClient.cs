
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APPsigmapy
{
    
    public class RestClient<T>
    {
        public static string resultado;
        private const string MainWebServiceUrl = "http://192.168.0.158/";
        private const string LoginWebServiceUrl = MainWebServiceUrl+"sigmaP/login.php/?";

        public async Task<bool> checkLogin(string username, string password)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(LoginWebServiceUrl + "username=" + username + "&" + "password=" + password);
            var response1 =  await httpClient.GetStringAsync(LoginWebServiceUrl + "username=" + username + "&" + "password=" + password);
            if (response1.Contains("null")) {
                resultado = "0";
            }
            if (response1.Contains("1")){
                resultado = "1";
            }
            Console.WriteLine("Respuesta Usuario "+resultado);
            Console.WriteLine("Respuesta "+response1.ToString());
            return response.IsSuccessStatusCode;
        }
    }

}