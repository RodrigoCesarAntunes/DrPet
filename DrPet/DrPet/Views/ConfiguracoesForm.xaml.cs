using System;
using DrPet.Utils.UI;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrPet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfiguracoesForm : ContentPage
	{
		public ConfiguracoesForm ()
		{
			InitializeComponent ();
		}

        public void Sair_onclick(object sender, EventArgs e)
        {
            Controller.Login.Login login = new Controller.Login.Login();
            if (login.AnularDetalhesDoUsuario())
            {
                var page = new  Pagina();
                App.Current.MainPage = page.GerarPaginaNavegacao(
                new LoginForm(),
                Model.Constants.BackGroundColor,
                Model.Constants.MainTextColor);
                //Navigation.InsertPageBefore(paginaLogin, this);
            }
            else
                App.Current.MainPage.DisplayAlert("Erro", login.MensagemErro, "OK");
        }
	}
}