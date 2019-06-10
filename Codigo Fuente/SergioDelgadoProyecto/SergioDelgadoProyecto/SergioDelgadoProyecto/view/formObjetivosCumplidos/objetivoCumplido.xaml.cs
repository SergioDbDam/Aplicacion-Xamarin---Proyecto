using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.formObjetivosCumplidos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class objetivoCumplido : ContentPage
    {
       /// <summary>
       /// Ventana de objetivos cumplidos
       /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/sigmaPCumplidos/objetivo/";
        private string Url = urL + RestClient<UserDetailsCredentials>.idMiembro;
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Cumplidos> _post;
        public objetivoCumplido()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo para Mostrar objetivos Cumplidos
        /// </summary>
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Cumplidos> posts = JsonConvert.DeserializeObject<List<Cumplidos>>(content);
            _post = new ObservableCollection<Cumplidos>(posts);
            MyListView.ItemsSource = _post;
            base.OnAppearing();
        }
        /// <summary>
        /// Metodo para seleccionar objetivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {


            BindingContext = e.SelectedItem as Model_Post;


            Console.WriteLine("Enviado");
        }
    }
}
