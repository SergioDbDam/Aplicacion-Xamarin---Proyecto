// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-09-2019
// ***********************************************************************
// <copyright file="RestService.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
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
    /// <summary>
    /// Class RestService.
    /// Implements the <see cref="SergioDelgadoProyecto.IRestService" />
    /// </summary>
    /// <seealso cref="SergioDelgadoProyecto.IRestService" />
    public class RestService : IRestService
    {
        /// <summary>
        /// Servicio Rest
        /// </summary>
        HttpClient _client;

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<Model_Post> Items { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RestService"/> class.
        /// </summary>
        public RestService()
        {
            _client = new HttpClient();
        }
        /// <summary>
        /// Mostrar Datos
        /// </summary>
        /// <returns>Muestra una Lista con los datos de los objetivos</returns>
        public async Task<List<Model_Post>> RefreshDataAsync()
        {
            
            Items = new List<Model_Post>();

            var uri = new Uri(string.Format("http://damnation.ddns.net/sergio/proyectobdSigma/objetivos", string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<Model_Post>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }
        /// <summary>
        /// Guarda el objetivo de manera asíncrona
        /// </summary>
        /// <param name="item">el objeto</param>
        /// <returns>Tarea.</returns>
        public async Task SaveTodoItemAsync(Model_Post item)
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
        /// Borra el objetivo de forma asíncrona
        /// </summary>
        /// <param name="id">Identificador</param>
        /// <returns>Tarea.</returns>
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
