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

            //MainPage = ;

            var page = new Pagina();
            
            //    new NavigationPage(new ContentPage
            //{
            //    Content = new DrPet.Views.LoginForm()
            //})
            //{
            //    BarBackgroundColor = Model.Constants.BackGroundColor,
            //    BarTextColor = Color.Black,
            //};

            MainPage = page.GerarPaginaNavegacao(
                new DrPet.Views.LoginForm(), 
                Model.Constants.BackGroundColor,
                Model.Constants.MainTextColor); 
            
            //new ContentPage()
            //{
            //    Content = new DrPet.Views.LoginForm()
            //};


            //MainPage = new NavigationPage(new DrPet.Views.CadastroForm());

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
