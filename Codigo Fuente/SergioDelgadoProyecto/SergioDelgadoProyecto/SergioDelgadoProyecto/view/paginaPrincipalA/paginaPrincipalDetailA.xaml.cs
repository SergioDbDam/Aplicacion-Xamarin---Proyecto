using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto
{
    /// <summary>
    /// Clase paginaPrincipalDetailA.
    /// Implementa el<see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class paginaPrincipalDetailA : ContentPage
    {
    
        public paginaPrincipalDetailA()
        {
            
            InitializeComponent();
            nombre.Text = RestClient<UserDetailsCredentials>.nombre;
        }

  
    }
}