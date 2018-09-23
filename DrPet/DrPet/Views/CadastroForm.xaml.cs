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
            BackgroundColor = DrPet.Model.Constants.BackGroundColor;
            entryNome.Completed += (s, e) => entryEmail.Focus();
            entryEmail.Completed += (s, e) => entryCPF.Focus();
            entryCPF.Completed += (s, e) => entryCelular.Focus();
            entryCelular.Completed += (s, e) => entryIdade.Focus();
            entryIdade.Completed += (s, e) => entryEndereco.Focus();
            entryEndereco.Completed += (s, e) => entryCEP.Focus();
            entryCEP.Completed += (s, e) => entrySenha.Focus();
            entrySenha.Completed += (s, e) => btnConcluirCadastro_Clicked(s,e);
        }

        private async void btnConcluirCadastro_Clicked(object sender, EventArgs e)
        {
            Autenticacao autenticacao = new Autenticacao();
            autenticacao.Email = entryEmail.Text;
            autenticacao.Senha = entrySenha.Text;

            Cliente_pessoa cliente_Pessoa = new Cliente_pessoa();
            cliente_Pessoa.Usuario_Email = entryEmail.Text;

            Usuario usuario = new Usuario();
            usuario.Autenticacao = autenticacao;
            List<Cliente_pessoa> usuarios = new List<Cliente_pessoa>();
            usuarios.Add(cliente_Pessoa);
            usuario.Cliente_pessoa = usuarios;

            usuario.Nome = entryNome.Text;
            usuario.Email = entryEmail.Text;
            usuario.Cpf_Cnpj = entryCPF.Text;
            usuario.Celular = entryCelular.Text;
            usuario.Idade = Convert.ToInt16(entryIdade.Text);
            usuario.Endereco = entryEndereco.Text;
            usuario.CEP = entryCEP.Text;
            try
            {
                DrPet.Controller.Login.Cadastrar cadastrar = new Controller.Login.Cadastrar();
                DesabilitarForms(false);
                await cadastrar.CadastrarCliente(usuario);
                DesabilitarForms(true);
                await App.Current.MainPage.DisplayAlert("Sucesso", "Usuario cadastrado com sucesso", "OK");
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
    }
}