// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="TodoItemManagerRegistro.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Class TodoItemManagerRegistro.
    /// </summary>
    public class TodoItemManagerRegistro
	{
        /// <summary>
        /// The rest service
        /// </summary>
        IRestServiceRegistro restService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemManagerRegistro"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public TodoItemManagerRegistro (IRestServiceRegistro service)
		{
			restService = service;
		}
        /// <summary>
        /// Muestra Registros
        /// </summary>
        /// <returns>Task&lt;List&lt;registros&gt;&gt;.</returns>
		public Task<List<registros>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}
        /// <summary>
        /// Guarda Registro
        /// </summary>
        /// <param name="item">Objeto de registro</param>
        /// <returns>Task.</returns>
        public Task SaveTaskAsync(registros item)
		{
			return restService.SaveTodoItemAsync (item);
		}
        /// <summary>
        /// Borra Registro
        /// </summary>
        /// <param name="item">ID de registro</param>
        /// <returns>Task.</returns>
		public Task DeleteTaskAsync (registros item)
		{
            return restService.DeleteTodoItemAsync(item.id);
		}
	}
}
