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

namespace SergioDelgadoProyecto.formObjetivosCumplidosAjenos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodosObjetivos : ContentPage {
       /// <summary>
       /// Mostrar objetivos Ajenos ordenados por usuario
       /// </summary>
        public const string urL = "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/";
    private string Url = urL + OcAjenos.idObjetivo;
        public const string urL1 = "http://damnation.ddns.net/sergio/sigmaPCumplidos/objetivo/";
        private string Url1 = urL1 + OcAjenos.idObjetivo ;
        
        private readonly HttpClient client = new HttpClient();
    private ObservableCollection<Model_Post> _post;
    
        public TodosObjetivos()
        {
            InitializeComponent();
            Console.WriteLine("Objetivos ID : "+OcAjenos.idObjetivo);
            
            
        }
        /// <summary>
        /// Mostrar objetivos de usuario
        /// </summary>
        protected async override void OnAppearing()
        {
            string content = await client.GetStringAsync(Url);
            List<Model_Post> posts = JsonConvert.DeserializeObject<List<Model_Post>>(content);
            _post = new ObservableCollection<Model_Post>(posts);
            MyListViewCumplido.ItemsSource = _post;
            string content1 = await client.GetStringAsync(Url1);
           
                List<Model_Post> posts1 = JsonConvert.DeserializeObject<List<Model_Post>>(content1);
                _post = new ObservableCollection<Model_Post>(posts1);
                MyListViewNoCumplido.ItemsSource = _post;
            
            
            base.OnAppearing();
        }
      
    }
}