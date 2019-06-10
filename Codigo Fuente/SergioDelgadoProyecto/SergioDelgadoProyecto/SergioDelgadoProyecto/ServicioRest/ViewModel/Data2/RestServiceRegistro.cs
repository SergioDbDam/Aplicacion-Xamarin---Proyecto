using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SergioDelgadoProyecto.ServicioRest;

namespace SergioDelgadoProyecto
{
    public class RestServiceRegistro : IRestServiceRegistro
    {
        /// <summary>
        /// Servicio Rest
        /// </summary>
        HttpClient _client;

        public List<registros> Items { get; private set; }

        public RestServiceRegistro()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Mostrar Datos
        /// </summary>
        /// <returns>Muestra una Lista con los datos de los Registros</returns>
        public async Task<List<registros>> RefreshDataAsync()
        {
            Items = new List<registros>();

            var uri = new Uri(string.Format("", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<registros>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
        /// <summary>
        /// Guardar Datos
        /// </summary>
        /// <param name="item">Objeto de Registros</param>
        /// <returns>Guarda un Registro</returns>
        public async Task SaveTodoItemAsync(registros item)
        {
            var uri = new Uri(string.Format("http://192.168.1.21/proyectobdSigma/objetivo", string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
              
              response = await _client.PutAsync(uri, content);
              

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        /// <summary>
        /// Borra Registros
        /// </summary>
        /// <param name="id">id de Registro</param>
        /// <returns>Borra un registro por id</returns>
        public async Task DeleteTodoItemAsync(int id)
        {
            var uri = new Uri(string.Format("", id));

            try
            {
                var response = await _client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

      
    }
}
