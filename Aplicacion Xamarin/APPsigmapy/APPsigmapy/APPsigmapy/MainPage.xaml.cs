using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MySql.Data.MySqlClient;

using Xamarin.Forms;
using System.Net.Http;

namespace APPsigmapy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            
        LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(EntryUsername.Text, EntryPassword.Text);
            Console.WriteLine("MainPage : "+getLoginDetails);
            var httpClient = new HttpClient();
            //Console.WriteLine("RESPUESTAA FINAAAL"+RestClient<UserDetailsCredentials>.resultado);
            if (RestClient<UserDetailsCredentials>.resultado=="1")
            {
                await Navigation.PushAsync(new NavigationPage(new paginaPrincipal()));
                
            }
           
            else
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }
}
