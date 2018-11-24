using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrPet.Utils.UI;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DrPet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var page = new Pagina();
            
            MainPage = page.GerarPaginaNavegacao(
                new DrPet.Views.LoginForm(), 
                Model.Constants.BackGroundColor,
                Model.Constants.MainTextColor);

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
