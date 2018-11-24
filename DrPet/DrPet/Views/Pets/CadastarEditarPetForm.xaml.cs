using System;
using DrPet.Controller.Login;
using DrPet.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrPet.Views.Pets
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastarEditarPetForm : ContentPage
	{
		public CadastarEditarPetForm ()
		{
			InitializeComponent ();
            initPickers();

        }

        private void initPickers()
        {
            //Genero
            pickerGenero.Items.Add("Macho");
            pickerGenero.Items.Add("Femea");

            //Peso
            pickerPeso.Items.Add("Menos de 1KG");
            pickerPeso.Items.Add("Entre 1KG e 5KG");
            pickerPeso.Items.Add("Entre 5KG e 10KG");
            pickerPeso.Items.Add("Entre 10KG e 15KG");
            pickerPeso.Items.Add("Entre 15KG e 20KG");
            pickerPeso.Items.Add("Mais de 20KG");

            //Tamanho
            pickerTamanho.Items.Add("Pequeno");
            pickerTamanho.Items.Add("Médio");
            pickerTamanho.Items.Add("Grande");

        }

        private async void btnConcluirCadastro_Clicked(object sender, EventArgs e)
        {
             
            Model.Pets pet = new Model.Pets();
            pet.Nome = entryNome.Text;
            pet.Raca = entryRaca.Text;
            pet.Especie = entryTipo.Text;
            pet.Idade = entryIdade.Text;
            pet.Tamanho = (string)pickerTamanho.SelectedItem;
            pet.Peso = (string)pickerPeso.SelectedItem;
            pet.Genero = (string)pickerGenero.SelectedItem;
            pet.Descricao = editorDescricao.Text;
            pet.ClientePessoaEmail = Login.UsuarioAtivo.UsuarioEmail;

            pet.ClientePessoa = Login.UsuarioAtivo;
            pet.ClientePessoa.Usuario = Login.UsuarioAtivo.Usuario;

            Controller.Mascotes.Adicionar adicionar = new Controller.Mascotes.Adicionar();

            await adicionar.Add(pet);

            Login logar = new Login();
            await logar.GetUsuariotAsync();
            //Navigation.InsertPageBefore(paginaLogin, this);
            //App.Current.MainPage = new NavigationPage(new Pets.MostrarPetsForm());


            await PilhaDeNavegacao.Navegacao.PopAsync();
            //await Navigation.PushModalAsync(new Pets.MostrarPetsForm());
        }
    }
}