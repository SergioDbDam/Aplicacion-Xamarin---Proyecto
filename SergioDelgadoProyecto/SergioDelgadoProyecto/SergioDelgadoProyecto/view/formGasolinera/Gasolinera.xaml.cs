
using Newtonsoft.Json.Linq;
using Plugin.FilePicker.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto.formGasolinera
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gasolinera : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();

        public Gasolinera()
        {
            InitializeComponent();
        }
        private async void SendEmailAsync(object sender, EventArgs e)
        {
            string subject = "subject here ";
            string body = "body here ";
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("smtp.gmail.com", 587);
            mail.From = new MailAddress("sergiopruebasigma@gmail.com");
            mail.To.Add("feralthas@gmail.com");
            mail.Subject = subject;
            mail.Body = body;
            Attachment attachment;
            attachment = new Attachment(fileLabel.Text);
            mail.Attachments.Add(attachment);
            smtpServer.Credentials = new NetworkCredential("sergiopruebasigma@gmail.com", "12345678s.");

            smtpServer.UseDefaultCredentials = false;
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);

            //enviar datos a la base de datos.
            var request = (HttpWebRequest)WebRequest.Create("http://192.168.0.100/proyectobd/index.php/gasolinera");

            var postData = "Nombre=hello";
            postData += "&Importe=" + envioImporte.Text;
            postData += "&Fecha=2019/02/21";
            postData += "&Registro_id=6";
            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd()

        ;
        }


        private async void File(object sender, EventArgs e)
        {


            var file = await Plugin.FilePicker.CrossFilePicker.Current.PickFile();

            if (file != null)
            {

                fileLabel.Text = file.FilePath;
            }
        }

    }
}