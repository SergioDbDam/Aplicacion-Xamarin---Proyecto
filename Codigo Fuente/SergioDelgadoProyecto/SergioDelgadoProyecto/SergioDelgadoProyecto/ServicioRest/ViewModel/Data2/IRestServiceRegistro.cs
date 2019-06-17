// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="IRestServiceRegistro.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Interface IRestServiceRegistro
    /// </summary>
    public interface IRestServiceRegistro
	{
        /// <summary>
        /// Servicio Rest para Inicio de sesion
        /// </summary>
        /// <returns>Mostrar datos</returns>
        Task<List<registros>> RefreshDataAsync ();

        /// <summary>
        /// Saves the todo item asynchronous.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Task.</returns>
        Task SaveTodoItemAsync (registros item);

        /// <summary>
        /// Deletes the todo item asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteTodoItemAsync (int id);
	}
}
