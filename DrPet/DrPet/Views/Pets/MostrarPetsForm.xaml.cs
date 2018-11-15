using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DrPet.Model;
using DrPet.Views.PaginaInicial;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrPet.Views.Pets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarPetsForm : ContentPage
    {
        public ObservableCollection<string> Nome { get; set; }
        public ObservableCollection<string> Raca { get; set; }
        public List<Model.Pets> Mascote { get; set; }
        public MostrarPetsForm()
        {
            InitializeComponent();
            IniciarListaMascote();
        }

        public void IniciarListaMascote()
        {
            listarPets();
            Mascote = DrPet.Controller.Login.Login.UsuarioAtivo.Pets.ToList();
            MyListView.ItemsSource = Mascote;
            MyListView.HasUnevenRows = true;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            var petSelecionado = e.Item as Model.Pets;
            //await DisplayAlert("selected", "An item was tapped.", "OK");
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void listarPets()
        {
            
            Nome = new ObservableCollection<string>();
            Raca = new ObservableCollection<string>();
            if (DrPet.Controller.Login.Login.UsuarioAtivo.Pets ==null)
            {
                return;
            }
               
            foreach (var pet in DrPet.Controller.Login.Login.UsuarioAtivo.Pets)
            {
                Nome.Add(pet.Nome);
                Raca.Add(pet.Raca);
            }
            
            
            //DisplayAlert("teste",Items[0], "ok");
        }

        private async void AddPet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastarEditarPetForm());
        }
    }
}
