// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-10-2019
// ***********************************************************************
// <copyright file="RestClient.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace SergioDelgadoProyecto
{

    /// <summary>
    /// Class RestClient.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RestClient<T>
    {
        /// <summary>
        /// The identifier miembro
        /// </summary>
        public static int idMiembro;
        /// <summary>
        /// The rol
        /// </summary>
        public static string rol;
        /// <summary>
        /// The resultado
        /// </summary>
        public static string resultado;
        /// <summary>
        /// The nombre
        /// </summary>
        public static string nombre;
        /// <summary>
        /// The main web service URL
        /// </summary>
        private const string MainWebServiceUrl = "http://damnation.ddns.net/sergio/";
        /// <summary>
        /// The login web service URL
        /// </summary>
        private const string LoginWebServiceUrl = MainWebServiceUrl+"sigmaP/login.php/?";
        /// <summary>
        /// Comprobacion del inicio de sesión
        /// </summary>
        /// <param name="username">usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
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