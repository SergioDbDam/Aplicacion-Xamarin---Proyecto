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
    public partial class paginaPrincipalMasterA : ContentPage
    {
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

        class paginaPrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<paginaPrincipalMenuItemA> MenuItems { get; set; }
            
            public paginaPrincipalMasterViewModel()
            {
                /// <summary>
                /// Objetos del menu 
                /// </summary>
                MenuItems = new ObservableCollection<paginaPrincipalMenuItemA>(new[]
                {
                    new paginaPrincipalMenuItemA { Id = 0, Title = "Gasolinera",TargetType=typeof(formGasolinera.Gasolinera) },
                    new paginaPrincipalMenuItemA { Id = 1, Title = "Objetivos",TargetType=typeof(formObjetivos.Objetivos) },
                   new paginaPrincipalMenuItemA { Id = 2, Title = "Crear Objetivos",TargetType=typeof(formCrearObjetivo.crearObjetivos) },
                    new paginaPrincipalMenuItemA { Id = 3, Title = "Objetivos Cumplidos" ,TargetType=typeof(formObjetivosCumplidos.objetivoCumplido)},
                    new paginaPrincipalMenuItemA { Id = 4, Title = "Objetivos Ajenos",TargetType=typeof(formObjetivosCumplidosAjenos.OcAjenos)},
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