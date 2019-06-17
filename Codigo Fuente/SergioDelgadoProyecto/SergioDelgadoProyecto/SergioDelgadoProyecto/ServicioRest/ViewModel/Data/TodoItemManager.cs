// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="TodoItemManager.cs" company="SergioDelgadoProyecto">
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
    /// Class TodoItemManager.
    /// </summary>
    public class TodoItemManager
	{
        /// <summary>
        /// The rest service
        /// </summary>
        IRestService restService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoItemManager"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public TodoItemManager (IRestService service)
		{
			restService = service;
		}
        /// <summary>
        /// Muestra Objetivos
        /// </summary>
        /// <returns>Task&lt;List&lt;Model_Post&gt;&gt;.</returns>
		public Task<List<Model_Post>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}
        /// <summary>
        /// Guarda Objetivo
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Task.</returns>
        public Task SaveTaskAsync(Model_Post item)
		{
			return restService.SaveTodoItemAsync (item);
		}
        /// <summary>
        /// Borra Objetivo
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Task.</returns>
		public Task DeleteTaskAsync (Model_Post item)
		{
            return restService.DeleteTodoItemAsync(item.id);
		}
	}
}
