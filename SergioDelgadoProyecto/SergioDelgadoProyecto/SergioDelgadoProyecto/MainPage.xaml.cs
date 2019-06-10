using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



using System.Net.Http;

namespace SergioDelgadoProyecto
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //imagen.Source = "sigmapyme.png";
        }
        private async void ButtonLogin_Clicked(object sender, EventArgs e)
        {
            
        LoginService services = new LoginService();
            var getLoginDetails = await services.CheckLoginIfExists(EntryUsername.Text, EntryPassword.Text);
            Console.WriteLine("MainPage : "+getLoginDetails);
          
            var httpClient = new HttpClient();
            Console.WriteLine(RestClient<UserDetailsCredentials>.rol);
            if (RestClient<UserDetailsCredentials>.resultado == "1" && RestClient<UserDetailsCredentials>.rol.Equals("Comercial"))
            {
                //await Navigation.PushAsync(new NavigationPage(new formObjetivos.Objetivos()));
                Console.WriteLine("xkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkk");
                await ((NavigationPage)Parent).PushAsync(new paginaPrincipal());
            }
           else if (RestClient<UserDetailsCredentials>.resultado == "1" && RestClient<UserDetailsCredentials>.rol.Equals("Admin")) {

                await ((NavigationPage)Parent).PushAsync(new paginaPrincipalA());
                Console.WriteLine("SIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
            }
            else if (RestClient<UserDetailsCredentials>.nombre=="error")
            {
                await DisplayAlert("Login failed", "Username or Password is incorrect or not exists", "Okay", "Cancel");
            }
        }
    }
}
