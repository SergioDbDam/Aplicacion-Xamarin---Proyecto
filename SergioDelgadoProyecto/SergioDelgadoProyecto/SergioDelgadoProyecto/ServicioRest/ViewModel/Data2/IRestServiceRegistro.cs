using System.Collections.Generic;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
namespace SergioDelgadoProyecto
{
	public interface IRestServiceRegistro
	{
        /// <summary>
        /// Servicio Rest para Inicio de sesion 
        /// </summary>
        /// <returns>Mostrar datos</returns>
        Task<List<registros>> RefreshDataAsync ();

		Task SaveTodoItemAsync (registros item);

		Task DeleteTodoItemAsync (int id);
	}
}
