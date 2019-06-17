// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="Objetivos.xaml.cs" company="SergioDelgadoProyecto">
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


namespace SergioDelgadoProyecto.formObjetivos
{

    /// <summary>
    /// Class Objetivos.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class Objetivos : ContentPage
    {
        /// <summary>
        /// Muestra de objetivos
        /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/";
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
        private ObservableCollection<Model_Post> _post;
        /// <summary>
        /// Initializes a new instance of the <see cref="Objetivos"/> class.
        /// </summary>
        public RestService viewmodel = new RestService();
        public Objetivos()
        {
            InitializeComponent();
           
        }
        /// <summary>
        /// Metodo para mostrar los objetivos
        /// </summary>
        protected async override void OnAppearing()
        {

            
            await viewmodel.RefreshDataAsync();
            MyListView.ItemsSource = viewmodel.Items;
            base.OnAppearing();
            
            
            }

        /// <summary>
        /// Metodo para seleccionar los objetivos
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {

            await Navigation.PushAsync(new ventanaObjetivo
            {

                BindingContext = e.SelectedItem as Model_Post

            }) ;  ;
            Console.WriteLine("Enviado");
        }
    }
}
