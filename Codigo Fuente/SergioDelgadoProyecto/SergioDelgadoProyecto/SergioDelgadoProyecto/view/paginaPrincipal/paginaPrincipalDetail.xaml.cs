// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="paginaPrincipalDetail.xaml.cs" company="SergioDelgadoProyecto">
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

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Class paginaPrincipalDetail.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class paginaPrincipalDetail : ContentPage
    {
        /// <summary>
        /// Detalles de la pagina principal
        /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/";
        /// <summary>
        /// The URL
        /// </summary>
        private string Url = urL + RestClient<UserDetailsCredentials>.idMiembro;
        /// <summary>
        /// The ur l1
        /// </summary>
        public const string urL1 = "http://damnation.ddns.net/sergio/sigmaPCumplidos/objetivo/";
        /// <summary>
        /// The url1
        /// </summary>
        private string Url1 = urL1 + RestClient<UserDetailsCredentials>.idMiembro;

        /// <summary>
        /// The client
        /// </summary>
        private readonly HttpClient client = new HttpClient();
        /// <summary>
        /// The post
        /// </summary>
        private ObservableCollection<Model_Post> _post;

        /// <summary>
        /// Initializes a new instance of the <see cref="paginaPrincipalDetail"/> class.
        /// </summary>
        public paginaPrincipalDetail()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cuando se invalida, permite a los desarrolladores de aplicaciones personalizar el comportamiento inmediatamente antes de que <see cref="T:Xamarin.Forms.Page" /> sea visible.
        /// </summary>
        protected async override void OnAppearing()
        {
            try
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
            catch (Exception)
            {
                await DisplayAlert("No Hay datos disponibles", "", "OK");
            }
        }
    }
}