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
        private const string Url = "http://192.168.1.21/proyectobdSigma/objetivos";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Model_Post> _post;
        public Objetivos()
        {
            InitializeComponent();
           
        }
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
            _post = new ObservableCollection<Model_Post>(posts);
            MyListView.ItemsSource = _post;
            base.OnAppearing();
        }
        async void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ventanaObjetivos
            {
                BindingContext = e.SelectedItem as Model_Post

            } );
            Console.WriteLine("Enviado");
        }
    }
}
