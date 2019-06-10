using Newtonsoft.Json;
using SergioDelgadoProyecto.ServicioRest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace SergioDelgadoProyecto.formObjetivos
{
   
    public partial class Objetivos : ContentPage
    {
        /// <summary>
        /// Muestra de objetivos
        /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/";
        private  string Url = urL + RestClient<UserDetailsCredentials>.idMiembro;
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Model_Post> _post;
        public Objetivos()
        {
            InitializeComponent();
           
        }
        /// <summary>
        /// Metodo para mostrar los objetivos
        /// </summary>
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
            _post = new ObservableCollection<Model_Post>(posts);
            MyListView.ItemsSource = _post;
            int contador = posts.Count;
            Console.WriteLine("CONTADOOOOOOOOOOOOOOR    " + contador);
            base.OnAppearing();
        }
        /// <summary>
        /// Metodo para seleccionar los objetivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ventanaObjetivo
            {
                BindingContext = e.SelectedItem as Model_Post
                
            } );
            Console.WriteLine("Enviado");
        }
    }
}
