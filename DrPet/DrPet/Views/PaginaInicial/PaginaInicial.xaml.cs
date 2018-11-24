using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrPet.Model;
using DrPet.Utils;

namespace DrPet.Views.PaginaInicial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : MasterDetailPage
    {
        public PaginaInicial()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public PaginaInicial(Usuario usuario)
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PaginaInicialMenuItem;
            //PilhaDeNavegacao.Navegacao = App.Current.MainPage.Navigation;
            if (item == null)
                return;
            else if (item.Title == "Pagina Inicial")
                Detail.Navigation.PushAsync(new PaginaInicial() { Title = "Pagina"});
            else if(item.Title == "Meus Pets")
                Detail.Navigation.PushAsync(new Pets.MostrarPetsForm() { Title = "Meus Bichinhos" });
            else if (item.Title == "Configurações")
                Detail.Navigation.PushAsync(new Views.ConfiguracoesForm() { Title = "Configurações" });

            PilhaDeNavegacao.Navegacao = Detail.Navigation;

            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Navigation.PushAsync(page);
            //Detail = new NavigationPage(new Pets.MostrarPetsForm()) { Title = "Meus Bichinhos"};

            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}