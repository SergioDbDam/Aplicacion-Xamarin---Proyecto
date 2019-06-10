using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
	public class TodoItemManagerRegistro
	{
		IRestServiceRegistro restService;

		public TodoItemManagerRegistro (IRestServiceRegistro service)
		{
			restService = service;
		}
        /// <summary>
        /// Muestra Registros
        /// </summary>
        /// <returns></returns>
		public Task<List<registros>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}
        /// <summary>
        /// Guarda Registro
        /// </summary>
        /// <param name="item">Objeto de registro</param>
        /// <returns></returns>
        public Task SaveTaskAsync(registros item)
		{
			return restService.SaveTodoItemAsync (item);
		}
        /// <summary>
        /// Borra Registro
        /// </summary>
        /// <param name="item">ID de registro</param>
        /// <returns></returns>
		public Task DeleteTaskAsync (registros item)
		{
            return restService.DeleteTodoItemAsync(item.id);
		}
	}
}
