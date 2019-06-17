// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-14-2019
// ***********************************************************************
// <copyright file="crearObjetivos.xaml.cs" company="SergioDelgadoProyecto">
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

namespace SergioDelgadoProyecto.formCrearObjetivo
{
    /// <summary>
    /// Class crearObjetivos.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class crearObjetivos : ContentPage
    {
        /// <summary>
        /// Creaciond de objetivos
        /// </summary>
        /// 192.168.1.21
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
        /// Initializes a new instance of the <see cref="crearObjetivos"/> class.
        /// </summary>
        public crearObjetivos()
        {
            InitializeComponent();
            Fecha.Format = ("yyyy-MM-dd");
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }
        /// <summary>
        /// Mostrar objetivos
        /// </summary>
        protected async override void OnAppearing()
        {
            RestServiceRegistro viewmodel = new RestServiceRegistro();
            await viewmodel.RefreshDataAsync();
            MyListView.ItemsSource = viewmodel.Items;
            base.OnAppearing();
        }
        /// <summary>
        /// Seleccionar Objetivo
        /// </summary>
        /// <param name="sender">Objeto seleccionado</param>
        /// <param name="e">Envio de objetivo</param>
        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {

            BindingContext = e.SelectedItem as RestServiceRegistro ;
            registros itm = (registros)e.SelectedItem;
            ID.Text = itm.id.ToString();
            Console.WriteLine("Enviado" + itm.id);
        }
        /// <summary>
        /// Guardar objetivo
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async void OnSaveButtonClicked(object sender, EventArgs e)
        { 
            var dict = new Dictionary<string, string>();
            dict.Add("objetivos", objetives.Text);
            dict.Add("fecha", txtFecha.Text);
            dict.Add("cumplido", "0");
            dict.Add("registro_id", ID.Text);
            if (objetives.Text != null && txtFecha.Text != null)
            {
                var client = new HttpClient();
                var req = new HttpRequestMessage(HttpMethod.Post, "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo")
                { Content = new FormUrlEncodedContent(dict) };
                var res = await client.SendAsync(req);
                await DisplayAlert("Objetivo Creado", "El objetivo ha sido creado correctamente", "Vale", "Cancelar");
            }
            else {
                await DisplayAlert("Rellena todo los Campos", "El objetivo No ha sido creado", "Vale", "Cancelar");
            }
        }

        /// <summary>
        /// Handles the DateSelected event of the Fecha control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DateChangedEventArgs"/> instance containing the event data.</param>
        public void Fecha_DateSelected(object sender, DateChangedEventArgs e)
        {
            txtFecha.Text = e.NewDate.ToString("yyyy-MM-dd");
           
        }
    }
}