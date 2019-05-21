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

		public Task<List<Model_Post>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

        public Task SaveTaskAsync(Model_Post item)
		{
			return restService.SaveTodoItemAsync (item);
		}

		public Task DeleteTaskAsync (Model_Post item)
		{
            return restService.DeleteTodoItemAsync(item.id);
		}
	}
}
