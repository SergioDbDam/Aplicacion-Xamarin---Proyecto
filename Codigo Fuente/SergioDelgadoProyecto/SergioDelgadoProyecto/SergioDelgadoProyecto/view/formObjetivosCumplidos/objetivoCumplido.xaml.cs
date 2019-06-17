// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-10-2019
// ***********************************************************************
// <copyright file="objetivoCumplido.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.formObjetivosCumplidos
{
    /// <summary>
    /// Class objetivoCumplido.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class objetivoCumplido : ContentPage
    {
        /// <summary>
        /// Ventana de objetivos cumplidos
        /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/sigmaPCumplidos/objetivo/";
        /// <summary>
        /// The URL
        /// </summary>
        private string Url = urL + RestClient<UserDetailsCredentials>.idMiembro;
        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient client = new HttpClient();
        /// <summary>
        /// The post
        /// </summary>
        private ObservableCollection<Cumplidos> _post;
        /// <summary>
        /// Initializes a new instance of the <see cref="objetivoCumplido"/> class.
        /// </summary>
        public objetivoCumplido()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo para Mostrar objetivos Cumplidos
        /// </summary>
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Cumplidos> posts = JsonConvert.DeserializeObject<List<Cumplidos>>(content);
            _post = new ObservableCollection<Cumplidos>(posts);
            MyListView.ItemsSource = _post;
            base.OnAppearing();
        }
        /// <summary>
        /// Metodo para seleccionar objetivos
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {


            BindingContext = e.SelectedItem as Model_Post;


            Console.WriteLine("Enviado");
        }
    }
}
