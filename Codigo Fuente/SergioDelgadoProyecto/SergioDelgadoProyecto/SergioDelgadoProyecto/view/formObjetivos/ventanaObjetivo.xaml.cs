using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.formObjetivos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ventanaObjetivo : ContentPage
    {
        /// <summary>
        /// Ventana secundaria de objetivos
        /// </summary>
        public ventanaObjetivo()
        {
            InitializeComponent();


        }
        /// <summary>
        /// Metodo para guardar los objetivos y pasarlos a cumplidos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

       

         
            var dict = new Dictionary<string, string>();
            dict.Add("objetivos", objetives.Text);
            dict.Add("fecha", "2019-06-01");
            dict.Add("cumplido", "1");
            dict.Add("registro_id", Registro.Text);

            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Put, "http://damnation.ddns.net/sergio/proyectobdSigma/objetivo/"+ide.Text) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);

        }
    }

}
