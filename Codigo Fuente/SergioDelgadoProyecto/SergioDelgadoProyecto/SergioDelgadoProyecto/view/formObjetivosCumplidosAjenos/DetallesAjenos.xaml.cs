// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-12-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="DetallesAjenos.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.view.formObjetivosCumplidosAjenos
{
    /// <summary>
    /// Class DetallesAjenos.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesAjenos : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DetallesAjenos"/> class.
        /// </summary>
        public DetallesAjenos()
        {
            InitializeComponent();
            txtFecha.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Handles the <see cref="E:SaveButtonClicked" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var dict = new Dictionary<string, string>();
            dict.Add("objetivos", objetives.Text);
            dict.Add("fecha", txtFecha.Text);
            dict.Add("cumplido", "0");
            dict.Add("registro_id", Registro.Text);

            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Put, "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/" + ide.Text) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);
            await DisplayAlert("El objetivo ha sido actualizado", "Actualizacion correcta", "OK");

        }
        /// <summary>
        /// Handles the <see cref="E:DeletedButtonClicked" /> event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        async void OnDeletedButtonClicked(object sender, EventArgs e)
        {




            var dict = new Dictionary<string, string>();
            dict.Add("objetivos", objetives.Text);
            dict.Add("fecha", "2019-06-01");
            dict.Add("cumplido", "1");
            dict.Add("registro_id", Registro.Text);

            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Delete, "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/" + ide.Text) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);
            await DisplayAlert("El objetivo ha sido borrado", "borrado correctamente", "OK");

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


