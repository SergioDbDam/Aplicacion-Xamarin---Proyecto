using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
	public class TodoItemManager
	{
		IRestService restService;

		public TodoItemManager (IRestService service)
		{
			restService = service;
		}
        /// <summary>
        /// Muestra Objetivos
        /// </summary>
        /// <returns></returns>
		public Task<List<Model_Post>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}
        /// <summary>
        /// Guarda Objetivo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task SaveTaskAsync(Model_Post item)
		{
			return restService.SaveTodoItemAsync (item);
		}
        /// <summary>
        /// Borra Objetivo
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
		public Task DeleteTaskAsync (Model_Post item)
		{
            return restService.DeleteTodoItemAsync(item.id);
		}
	}
}
