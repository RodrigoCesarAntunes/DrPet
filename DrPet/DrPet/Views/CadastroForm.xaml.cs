using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrPet.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrPet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroForm : ContentView
	{
		public CadastroForm ()
		{
			InitializeComponent ();
            Init();
		}

        private void Init()
        {
            
            btnConcluirCadastro.BackgroundColor = Color.DimGray;
            btnConcluirCadastro.TextColor = Color.White;
            btnConcluirCadastro.BorderColor = Color.Black;
            //btnConcluirCadastro.BorderRadius = 
            BackgroundColor = DrPet.Model.Constants.BackGroundColor;
            entryNome.Completed += (s, e) => entryEmail.Focus();
            entryEmail.Completed += (s, e) => entryCPF.Focus();
            entryCPF.Completed += (s, e) => entryCelular.Focus();
            entryCelular.Completed += (s, e) => entryIdade.Focus();
            entryIdade.Completed += (s, e) => entryEndereco.Focus();
            entryEndereco.Completed += (s, e) => entryCEP.Focus();
            entryCEP.Completed += (s, e) => entrySenha.Focus();
            entrySenha.Completed += (s, e) => entrySenha2.Focus();
            entrySenha2.Completed += (s, e) => btnConcluirCadastro_Clicked(s,e);
        }

        private async void btnConcluirCadastro_Clicked(object sender, EventArgs e)
        {
            if(!ChecarSenha())
            {
                await App.Current.MainPage.DisplayAlert("Senhas diferentes", "As duas senhas precisam ser iguais", "OK");
                return;
            }
            Autenticacao autenticacao = new Autenticacao();
            autenticacao.Email = entryEmail.Text;
            autenticacao.Senha = entrySenha.Text;

            Cliente_pessoa cliente_Pessoa = new Cliente_pessoa();
            cliente_Pessoa.UsuarioEmail = entryEmail.Text;

            Usuario usuario = new Usuario();
            usuario.Autenticacao = autenticacao;
            usuario.ClientePessoa = cliente_Pessoa;

            usuario.Nome = entryNome.Text;
            usuario.Email = entryEmail.Text;
            usuario.CpfCnpj = entryCPF.Text;
            usuario.Celular = entryCelular.Text;
            usuario.Idade = Convert.ToInt16(entryIdade.Text);
            usuario.Endereco = entryEndereco.Text;
            usuario.Cep = entryCEP.Text;
            try
            {
                String resp;
                DrPet.Controller.Login.Cadastrar cadastrar = new Controller.Login.Cadastrar();
                DesabilitarForms(false);
                resp = await cadastrar.CadastrarCliente(usuario);
                DesabilitarForms(true);
                await App.Current.MainPage.DisplayAlert("Mensagem", resp, "OK");
            }
            catch(Exception erro)
            {
                await App.Current.MainPage.DisplayAlert("Erro", "Algo deu errado, verifique se há conexão com a internet " + erro.Message + "  " + erro.StackTrace,"OK");
                DesabilitarForms(true);
            }

        }

        private void DesabilitarForms(bool isHabilitado)
        {
            btnConcluirCadastro.IsEnabled = isHabilitado;
            entryNome.IsEnabled = isHabilitado;
            entryEmail.IsEnabled = isHabilitado;
            entryCPF.IsEnabled = isHabilitado;
            entryCelular.IsEnabled = isHabilitado;
            entryIdade.IsEnabled = isHabilitado;
            entryEndereco.IsEnabled = isHabilitado;
            entryCEP.IsEnabled = isHabilitado;
            entrySenha.IsEnabled = isHabilitado;
        }

        private bool ChecarSenha()
        {
            if(entrySenha.Text != entrySenha2.Text)
            {
                return false;
            }
            return true;
        }
    }
}