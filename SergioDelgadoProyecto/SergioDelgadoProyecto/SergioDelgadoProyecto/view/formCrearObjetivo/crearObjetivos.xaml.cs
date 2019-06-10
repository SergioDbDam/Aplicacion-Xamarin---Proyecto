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

namespace SergioDelgadoProyecto.formCrearObjetivo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class crearObjetivos : ContentPage
    {
        /// <summary>
        /// Creaciond de objetivos
        /// </summary>
        /// 192.168.1.21
        public const string urL = "http://damnation.ddns.net/sergio/sigmaPUsuarios/registros";
        // private string Url = urL + RestClient<UserDetailsCredentials>.idMiembro;
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<registros> _post;
        private BindableProperty idRegistro;

        public crearObjetivos()
        {
            InitializeComponent();
            Fecha.Format = ("yyyy-MM-dd");
        }
        /// <summary>
        /// Mostrar objetivos
        /// </summary>
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(urL);
            List<registros> posts = JsonConvert.DeserializeObject<List<registros>>(content);
            _post = new ObservableCollection<registros>(posts);
            MyListView.ItemsSource = _post;
           
            base.OnAppearing();
        }
        /// <summary>
        /// Seleccionar Objetivo
        /// </summary>
        /// <param name="sender">Objeto seleccionado</param>
        /// <param name="e">Envio de objetivo</param>
        void OnItemSelected(Object sender, SelectedItemChangedEventArgs e)
        {

            BindingContext = e.SelectedItem as registros;
            registros itm = (registros)e.SelectedItem;
            ID.Text = itm.id.ToString();
            Console.WriteLine("Enviado" + itm.id);
        }
        /// <summary>
        /// Guardar objetivo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

           //string fecha = Fecha.ToString("yyyy-MM-dd");
            Console.WriteLine("Fechaaaaaaaaaa   " + Fecha.ToString());
          
            var dict = new Dictionary<string, string>();
            dict.Add("objetivos", objetives.Text);
            dict.Add("fecha", "2019-06-01");
            dict.Add("cumplido", "0");
            dict.Add("registro_id", ID.Text);
            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Post, "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo") { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);
        }
    }
}