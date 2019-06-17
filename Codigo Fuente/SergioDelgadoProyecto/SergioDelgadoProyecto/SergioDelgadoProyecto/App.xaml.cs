// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-11-2019
// ***********************************************************************
// <copyright file="App.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Class App.
    /// Implements the <see cref="Xamarin.Forms.Application" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Application" />
    public partial class App : Application
    {
        /// <summary>
        /// Gets the todo manager.
        /// </summary>
        /// <value>The todo manager.</value>
        public static TodoItemManager TodoManager { get; private set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

           TodoManager = new TodoItemManager(new RestService());
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
        }

        /// <summary>
        /// Los desarrolladores de aplicaciones reemplazan este método para que lleve a cabo acciones cuando la aplicación se inicie.
        /// </summary>
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        /// <summary>
        /// Los desarrolladores de aplicaciones reemplazan este método para que lleve a cabo acciones cuando la aplicación entre en un estado inactivo.
        /// </summary>
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        /// <summary>
        /// Los desarrolladores de aplicaciones reemplazan este método para que lleve a cabo acciones cuando la aplicación se reanude desde un estado inactivo.
        /// </summary>
        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
