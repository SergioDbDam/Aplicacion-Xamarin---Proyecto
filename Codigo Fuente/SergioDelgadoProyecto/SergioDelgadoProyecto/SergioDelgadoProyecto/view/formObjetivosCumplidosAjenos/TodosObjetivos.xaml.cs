// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="TodosObjetivos.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Newtonsoft.Json;
using SergioDelgadoProyecto.ServicioRest;
using SergioDelgadoProyecto.view.formObjetivosCumplidosAjenos;
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
    /// Class TodosObjetivos.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodosObjetivos : ContentPage {
        /// <summary>
        /// Mostrar objetivos Ajenos ordenados por usuario
        /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/";
        /// <summary>
        /// The URL
        /// </summary>
        private string Url = urL + OcAjenos.idObjetivo;
        /// <summary>
        /// The ur l1
        /// </summary>
        public const string urL1 = "http://damnation.ddns.net/sergio/sigmaPCumplidos/objetivo/";
        /// <summary>
        /// The url1
        /// </summary>
        private string Url1 = urL1 + OcAjenos.idObjetivo ;

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient client = new HttpClient();
        /// <summary>
        /// The post
        /// </summary>
        private ObservableCollection<Model_Post> _post;

        /// <summary>
        /// Initializes a new instance of the <see cref="TodosObjetivos"/> class.
        /// </summary>
        public TodosObjetivos()
        {
            InitializeComponent();
            Console.WriteLine("Objetivos ID : "+OcAjenos.idObjetivo);
            
            
        }
        /// <summary>
        /// Mostrar objetivos de usuario
        /// </summary>
        protected async override void OnAppearing()
        {
           
                string content = await client.GetStringAsync(Url);
                List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
                _post = new ObservableCollection<Model_Post>(posts);
                MyListViewCumplido.ItemsSource = _post;
                string content1 = await client.GetStringAsync(Url1);

                List<Model_Post> posts1 = JsonConvert.DeserializeObject<List<Model_Post>>(content1);
                _post = new ObservableCollection<Model_Post>(posts1);
                MyListViewNoCumplido.ItemsSource = _post;


                base.OnAppearing();
            
           
        }
        /// <summary>
        /// Handles the <see cref="E:ItemSelected" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new DetallesAjenos
            {
                BindingContext = e.SelectedItem as Model_Post

            });
            Console.WriteLine("Enviado");
        }
    }
}