// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-10-2019
// ***********************************************************************
// <copyright file="OcAjenos.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using SergioDelgadoProyecto.ServicioRest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.formObjetivosCumplidosAjenos
{
    /// <summary>
    /// Class OcAjenos.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OcAjenos : ContentPage
    {
        /// <summary>
        /// Mostrar objetivos ajenos
        /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/sigmaPUsuarios/registros";
        // private string Url = urL + RestClient<UserDetailsCredentials>.idMiembro;
        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient client = new HttpClient();
        /// <summary>
        /// The post
        /// </summary>
        private ObservableCollection<registros> _post;
        /// <summary>
        /// The identifier registro
        /// </summary>
        private BindableProperty idRegistro;
        /// <summary>
        /// The identifier objetivo
        /// </summary>
        public static string idObjetivo;
        /// <summary>
        /// Initializes a new instance of the <see cref="OcAjenos"/> class.
        /// </summary>
        public OcAjenos()
        {
            InitializeComponent();
            //Fecha.Format = ("yyyy-MM-dd");
        }
        /// <summary>
        /// Metodo para mostrar una lista con todos los Ids y nombres de los usuarios
        /// </summary>
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(urL);
            List<registros> posts = JsonConvert.DeserializeObject<List<registros>>(content);
            _post = new ObservableCollection<registros>(posts);
            MyListView.ItemsSource = _post;

            base.OnAppearing();
        }
        /// <summary>
        /// Metodo para seleccionar un usuario
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            registros itm = (registros)e.SelectedItem;
                     idObjetivo = itm.id.ToString();
            await Navigation.PushAsync(new TodosObjetivos
            {
                BindingContext = e.SelectedItem as registros
                 
        });
           
            Console.WriteLine(itm.id);
            /*BindingContext = e.SelectedItem as registros;
            registros itm = (registros)e.SelectedItem;
            //ID.Text = itm.id.ToString();
            Console.WriteLine("Enviado" + itm.id);*/
        }
    }
}