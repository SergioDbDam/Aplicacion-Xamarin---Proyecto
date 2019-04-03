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

namespace APPsigmapy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class paginaPrincipalMaster : ContentPage
    {
        public ListView ListView;

        public paginaPrincipalMaster()
        {
            InitializeComponent();

            BindingContext = new paginaPrincipalMasterViewModel();
            ListView = MenuItemsListView;
        }

        class paginaPrincipalMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<paginaPrincipalMenuItem> MenuItems { get; set; }
            
            public paginaPrincipalMasterViewModel()
            {
                MenuItems = new ObservableCollection<paginaPrincipalMenuItem>(new[]
                {
                    new paginaPrincipalMenuItem { Id = 0, Title = "Gasolinera" },
                    /*new paginaPrincipalMenuItem { Id = 1, Title = "Page 2" },
                    new paginaPrincipalMenuItem { Id = 2, Title = "Page 3" },
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