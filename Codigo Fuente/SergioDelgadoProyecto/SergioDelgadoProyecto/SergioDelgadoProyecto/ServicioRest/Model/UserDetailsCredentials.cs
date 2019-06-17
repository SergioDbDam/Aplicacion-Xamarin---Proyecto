// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="UserDetailsCredentials.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Modelo de Datos de Usuarios
    /// </summary>
    public class UserDetailsCredentials
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [JsonProperty("id")]
        public int id { get; set; }
        /// <summary>
        /// Gets or sets the usuario.
        /// </summary>
        /// <value>The usuario.</value>
        [JsonProperty("usuario")]
        public string usuario { get; set; }
        /// <summary>
        /// Gets or sets the contrasena.
        /// </summary>
        /// <value>The contrasena.</value>
        [JsonProperty("contrasena")]
        public string contrasena { get; set; }
        /// <summary>
        /// Gets or sets the rol.
        /// </summary>
        /// <value>The rol.</value>
        [JsonProperty("rol")]
        public string rol { get; set; }
    }
}
