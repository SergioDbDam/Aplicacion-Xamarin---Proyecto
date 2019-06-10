using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class paginaPrincipalA : MasterDetailPage
    {
        /// <summary>
        /// Detalles de la pagina Principal de Administradores
        /// </summary>
        public paginaPrincipalA()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }
        /// <summary>
        /// Maneja el evento ItemSelected del control ListView.
        /// </summary>
        /// <param name="sender">La fuente del evento.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instancia que contiene los datos del evento</param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as paginaPrincipalMenuItemA;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;
           
            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}