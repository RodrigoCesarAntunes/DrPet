using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                var paginaLogin = new ContentPage() {Content = new LoginForm()};
                App.Current.MainPage = new NavigationPage(paginaLogin);
                //Navigation.InsertPageBefore(paginaLogin, this);
            }
            else
                App.Current.MainPage.DisplayAlert("Erro", login.MensagemErro, "OK");
        }
	}
}