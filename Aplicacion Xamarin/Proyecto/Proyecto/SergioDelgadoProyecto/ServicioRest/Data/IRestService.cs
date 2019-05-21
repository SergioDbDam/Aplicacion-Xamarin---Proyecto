using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
	public interface IRestService
	{
		Task<List<Model_Post>> RefreshDataAsync ();

		Task SaveTodoItemAsync (Model_Post item);

		Task DeleteTodoItemAsync (int id);
	}
}
