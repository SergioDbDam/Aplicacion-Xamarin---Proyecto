using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
	public interface IRestService
	{
        /// <summary>
        ///Actualiza los datos de forma asíncrona.
        /// </summary>
        /// <returns>Task&lt;List&lt;Model_Post&gt;&gt;.</returns>
        Task<List<Model_Post>> RefreshDataAsync ();
        /// <summary>
        /// Guarda los datos  de forma asíncrona.
        /// </summary>
        /// <param name="item">el objeto</param>
        /// <returns>Tarea.</returns>
        Task SaveTodoItemAsync (Model_Post item);
        /// <summary>
        ///Borra los datos de forma asíncrona
        /// </summary>
        /// <param name="id">El identificador</param>
        /// <returns>Tarea</returns>
       Task DeleteTodoItemAsync (int id);
	}
}
