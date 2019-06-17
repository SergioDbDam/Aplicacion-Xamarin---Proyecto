// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="LoginService.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Class LoginService.
    /// </summary>
    public class LoginService
    {
        /// <summary>
        /// The rest client
        /// </summary>
        RestClient<UserDetailsCredentials> _restClient = new RestClient<UserDetailsCredentials>();
        /// <summary>
        /// Comprobacion del inicio de sesion
        /// </summary>
        /// <param name="username">Usuario</param>
        /// <param name="password">contraseña</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> CheckLoginIfExists(string username, string password)
        {
            var check = await _restClient.checkLogin(username, password);
            Console.WriteLine("[CHEKEO] "+check.ToString());
            return check;
        }
    }
}
