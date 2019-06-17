// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="paginaPrincipalMaster.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Class PaginaPrincipalMaster.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalMaster : ContentPage
    {
        /// <summary>
        /// The ListView
        /// </summary>
        public ListView ListView;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginaPrincipalMaster" /> class.
        /// </summary>
        public PaginaPrincipalMaster()
        {
            InitializeComponent();

            BindingContext = new paginaPrincipalMasterViewModel();
            ListView = MenuItemsListView;
        }
        /// <summary>
        /// clase paginaPrincipalMasterViewModel
        /// Implements the <see cref="System.ComponentModel.INotifyPropertyChanged" />
        /// </summary>
        /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
        class paginaPrincipalMasterViewModel : INotifyPropertyChanged
        {
            /// <summary>
            /// Gets or sets the menu items.
            /// </summary>
            /// <value>The menu items.</value>
            public ObservableCollection<paginaPrincipalMenuItem> MenuItems { get; set; }
            /// <summary>
            /// Creación de Menú
            /// </summary>

            public paginaPrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<paginaPrincipalMenuItem>(new[]
                {
                    new paginaPrincipalMenuItem { Id = 0, Title = "Inicio",TargetType=typeof(paginaPrincipalDetail) },
                    new paginaPrincipalMenuItem { Id = 1, Title = "Gasolinera",TargetType=typeof(formGasolinera.Gasolinera) },
                    new paginaPrincipalMenuItem { Id = 2, Title = "Objetivos",TargetType=typeof(formObjetivos.Objetivos) },
                  /*
                    new paginaPrincipalMenuItem { Id = 3, Title = "Page 4" },
                    new paginaPrincipalMenuItem { Id = 4, Title = "Page 5" },*/
                });

            }

            #region INotifyPropertyChanged Implementation
            /// <summary>
            /// Occurs when a property value changes.
            /// </summary>
            /// <returns></returns>
            public event PropertyChangedEventHandler PropertyChanged;
            /// <summary>
            /// Called when [property changed].
            /// </summary>
            /// <param name="propertyName">Name of the property.</param>
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }

    }
    
}