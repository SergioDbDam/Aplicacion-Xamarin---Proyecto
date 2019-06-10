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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipalMaster : ContentPage
    {
        public ListView ListView;
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginaPrincipalMaster"/> class.
        /// </summary>
        public PaginaPrincipalMaster()
        {
            InitializeComponent();

            BindingContext = new paginaPrincipalMasterViewModel();
            ListView = MenuItemsListView;
        }
        /// <summary>
        /// clase paginaPrincipalMasterViewModel
        /// Implements the <see cref="System.ComponentModel.INotifyPropertyChanged" /></summary>
        /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
        class paginaPrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<paginaPrincipalMenuItem> MenuItems { get; set; }
            /// <summary>
            /// Creación de Menú
            /// </summary>
           
            public paginaPrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<paginaPrincipalMenuItem>(new[]
                {
                    new paginaPrincipalMenuItem { Id = 0, Title = "Gasolinera",TargetType=typeof(formGasolinera.Gasolinera) },
                    new paginaPrincipalMenuItem { Id = 1, Title = "Objetivos",TargetType=typeof(formObjetivos.Objetivos) },
                   new paginaPrincipalMenuItem { Id = 2, Title = "Page 3" },/*
                    new paginaPrincipalMenuItem { Id = 3, Title = "Page 4" },
                    new paginaPrincipalMenuItem { Id = 4, Title = "Page 5" },*/
                });

            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
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