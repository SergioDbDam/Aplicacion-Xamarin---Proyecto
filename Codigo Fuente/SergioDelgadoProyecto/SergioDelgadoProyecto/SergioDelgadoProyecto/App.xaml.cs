using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SergioDelgadoProyecto
{
    public partial class App : Application
    {
        public static TodoItemManager TodoManager { get; private set; }
        public App()
        {
            InitializeComponent();

           TodoManager = new TodoItemManager(new RestService());
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
