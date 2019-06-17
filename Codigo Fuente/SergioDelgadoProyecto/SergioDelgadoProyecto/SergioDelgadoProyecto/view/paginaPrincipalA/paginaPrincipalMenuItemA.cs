// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="paginaPrincipalMenuItemA.cs" company="SergioDelgadoProyecto">
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
    /// Modelo de los objetos del menú.
    /// </summary>
    public class paginaPrincipalMenuItemA
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="paginaPrincipalMenuItemA"/> class.
        /// </summary>
        public paginaPrincipalMenuItemA()
        {
            TargetType = typeof(paginaPrincipalDetailA);
        }
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the target.
        /// </summary>
        /// <value>The type of the target.</value>
        public Type TargetType { get; set; }
    }
}