using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SergioDelgadoProyecto.ServicioRest;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.formObjetivos
{
    public partial class ventanaObjetivos : ContentPage
    {
        public ventanaObjetivos()
        {
            InitializeComponent();
            string objetivos = this.FindByName<Label>("objetives").Text;
            string fecha = this.FindByName<Label>("Fecha").Text;
            string registro = this.FindByName<Label>("Registro").Text;

        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            DateTime parsedDate = DateTime.Parse(Fecha.Text);
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