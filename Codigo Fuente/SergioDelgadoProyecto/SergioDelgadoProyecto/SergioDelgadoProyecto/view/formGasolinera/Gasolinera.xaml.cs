// ***********************************************************************
// Assembly         : SergioDelgadoProyecto
// Author           : Sergio
// Created          : 06-10-2019
//
// Last Modified By : Sergio
// Last Modified On : 06-13-2019
// ***********************************************************************
// <copyright file="Gasolinera.xaml.cs" company="SergioDelgadoProyecto">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

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
    /// <summary>
    /// Class Gasolinera.
    /// Implements the <see cref="Xamarin.Forms.ContentPage" />
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Gasolinera : ContentPage
    {
        /// <summary>
        /// The client
        /// </summary>
        private static readonly HttpClient client = new HttpClient();

        /// <summary>
        /// Initializes a new instance of the <see cref="Gasolinera"/> class.
        /// </summary>
        public Gasolinera()
        {
            InitializeComponent();
        }
        /// <summary>
        /// send email as an asynchronous operation.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SendEmailAsync(object sender, EventArgs e)
        {
            try
            {


                //enviar datos a la base de datos.


                var dict = new Dictionary<string, string>();
                dict.Add("nombre", RestClient<UserDetailsCredentials>.nombre);
                dict.Add("importe", envioImporte.Text);
                dict.Add("fecha", DateTime.Today.ToString("yyyy-MM-dd"));
                dict.Add("registro_id", RestClient<UserDetailsCredentials>.idMiembro.ToString());
                if (!envioImporte.Text.Equals(null))
                {
                    var client = new HttpClient();
                    var req = new HttpRequestMessage(HttpMethod.Post, "http://damnation.ddns.net/sergio/proyectobd/index.php/gasolinera") { Content = new FormUrlEncodedContent(dict) };
                    var res = await client.SendAsync(req);
                    await DisplayAlert("importe Enviado", "El importe se ha guardado en la base de datos", "OK", "Cancelar");
                }
                else
                {
                    await DisplayAlert("importe No Enviado", "Introduce un Importe", "OK", "Cancelar");
                }
            }catch(System.NullReferenceException)
            {
                await DisplayAlert("importe No Enviado", "Introduce un Importe", "OK", "Cancelar");
            }
            catch (System.IO.FileNotFoundException)
            {
                await DisplayAlert("importe No se ha Enviado", "El importe no se ha guardado en la base de datos", "OK", "Cancelar");
            }
            catch (System.IO.IOException )
            {
                await DisplayAlert("importe No se ha Enviado", "El importe no se ha guardado en la base de datos", "OK", "Cancelar");
            }
            catch (System.UnauthorizedAccessException)
            {
                await DisplayAlert("importe No se ha Enviado", "El importe no se ha guardado en la base de datos", "OK", "Cancelar");
            }
            }
        /// <summary>
        /// Enviars the correo.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void enviarCorreo(object sender, EventArgs e) {
           
                NewMethod();
                
           
        }
        /// <summary>
        /// Creates new method.
        /// </summary>
        private void NewMethod()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("sergiopruebasigma@gmail.com");
                mail.To.Add("sergiopruebasigma@gmail.com");
                mail.Subject = "Importe de gasolina";
                mail.Body = "Importe de gasolina de : " + RestClient<UserDetailsCredentials>.nombre + " Cantidad : " + envioImporte.Text + " Fecha  : " + DateTime.Today.ToString("yyyy-MM-dd");
                Attachment attachment;
                attachment = new Attachment(fileLabel.Text);
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Host = "smtp.gmail.com";
                SmtpServer.EnableSsl = true;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("sergiopruebasigma@gmail.com", "12345678s.");
                if (envioImporte.Text.Equals(""))
                {
                    DisplayAlert("Introduce un importe antes de enviar la imagen", "", "OK");
                }
                else
                {
                    SmtpServer.Send(mail);
                    DisplayAlert("La imagen se ha enviado correctamente", "", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Fallo de envio", ex.Message, "OK");
            }
        }




        /// <summary>
        /// Files the specified sender.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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