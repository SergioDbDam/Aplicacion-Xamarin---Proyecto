// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-14-2019
// ***********************************************************************
// <copyright file="MainPage.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



using System.Net.Http;
using System.Reflection;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Class MainPage.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPage"/> class.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            //imagen.Source = "sigmapyme.png";
          

        }
        /// <summary>
        /// Cuando se invalida, permite a los desarrolladores de aplicaciones personalizar el comportamiento inmediatamente antes de que <see cref="T:Xamarin.Forms.Page" /> sea visible.
        /// </summary>
        protected async override void OnAppearing()
        {

            EntryUsername.Text = "";
            EntryPassword.Text = "";
            base.OnAppearing();

        }
        /// <summary>
        /// Handles the Clicked event of the ButtonLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            
        LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(EntryUsername.Text, EntryPassword.Text);
            Console.WriteLine("MainPage : "+getLoginDetails);
          
            var httpClient = new HttpClient();
            Console.WriteLine(RestClient<UserDetailsCredentials>.rol);
            if (RestClient<UserDetailsCredentials>.resultado == "1" && RestClient<UserDetailsCredentials>.rol.Equals("Comercial"))
            {
                //await Navigation.PushAsync(new NavigationPage(new formObjetivos.Objetivos()));
                //Console.WriteLine("xkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");
                await ((NavigationPage)Parent).PushAsync(new paginaPrincipal());
            }
           else if (RestClient<UserDetailsCredentials>.resultado == "1" && RestClient<UserDetailsCredentials>.rol.Equals("Admin")) {

                await ((NavigationPage)Parent).PushAsync(new paginaPrincipalA());
                //Console.WriteLine("SIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
            }
            else if (RestClient<UserDetailsCredentials>.nombre=="error")
            {
                await DisplayAlert("Inicio Incorrecto", "Usuario o contraseña es Invalido o no existe", "Vale", "Cancelar");
            }
        }
        /// <summary>
        /// Class ImageResourceExtension.
        /// Implements the <see cref="Xamarin.Forms.Xaml.IMarkupExtension" />
        /// </summary>
        /// <seealso cref="Xamarin.Forms.Xaml.IMarkupExtension" />
        [ContentProperty("Source")]
        public class ImageResourceExtension : IMarkupExtension
        {
            /// <summary>
            /// Gets or sets the source.
            /// </summary>
            /// <value>The source.</value>
            public string Source { get; set; }

            /// <summary>
            /// Devuelve el objeto creado a partir de la extensión de marcado.
            /// </summary>
            /// <param name="serviceProvider">Servicio que proporciona el valor.</param>
            /// <returns>El objeto</returns>
            public object ProvideValue(IServiceProvider serviceProvider)
            {
                if (Source == null)
                {
                    return null;
                }
                // Do your translation lookup here, using whatever method you require
                var imageSource = ImageSource.FromResource(Source);

                return imageSource;
            }
           
        }
    }
}
