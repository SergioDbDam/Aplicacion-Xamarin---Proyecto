// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-14-2019
// ***********************************************************************
// <copyright file="paginaPrincipalMasterA.xaml.cs" company="SergioDelgadoProyecto">
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
    /// Class paginaPrincipalMasterA.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class paginaPrincipalMasterA : ContentPage
    {
        /// <summary>
        /// The ListView
        /// </summary>
        public ListView ListView;
        /// <summary>
        /// Lista del menu
        /// </summary>
        public paginaPrincipalMasterA()
        {
            InitializeComponent();

            BindingContext = new paginaPrincipalMasterViewModel();
            ListView = MenuItemsListView;
          
        }

        /// <summary>
        /// Class paginaPrincipalMasterViewModel.
        /// Implements the <see cref="System.ComponentModel.INotifyPropertyChanged" />
        /// </summary>
        /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
        class paginaPrincipalMasterViewModel : INotifyPropertyChanged
        {
            /// <summary>
            /// Gets or sets the menu items.
            /// </summary>
            /// <value>The menu items.</value>
            public ObservableCollection<paginaPrincipalMenuItemA> MenuItems { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="paginaPrincipalMasterViewModel"/> class.
            /// </summary>
            public paginaPrincipalMasterViewModel()
            {
                /// <summary>
                /// Objetos del menu 
                /// </summary>
                MenuItems = new ObservableCollection<paginaPrincipalMenuItemA>(new[]
                {
                    new paginaPrincipalMenuItemA { Id = 0, Title = "Inicio",TargetType=typeof(paginaPrincipalDetailA) },
                    new paginaPrincipalMenuItemA { Id = 1, Title = "Gasolinera",TargetType=typeof(formGasolinera.Gasolinera) },
                    new paginaPrincipalMenuItemA { Id = 2, Title = "Objetivos",TargetType=typeof(formObjetivos.Objetivos) },
                   new paginaPrincipalMenuItemA { Id = 3, Title = "Crear Objetivos",TargetType=typeof(formCrearObjetivo.crearObjetivos) },
                   
                    new paginaPrincipalMenuItemA { Id = 4, Title = "Objetivos Ajenos",TargetType=typeof(formObjetivosCumplidosAjenos.OcAjenos)},
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