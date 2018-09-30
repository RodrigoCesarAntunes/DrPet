﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using DrPet.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DrPet.Views.Pets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarPetsForm : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        public ObservableCollection<string> Raca { get; set; }
        public List<Model.Pets> Mascote { get; set; }
        public MostrarPetsForm()
        {
            InitializeComponent();
            listarPets();
            Mascote = DrPet.Controller.Login.Login.UsuarioAtivo.Cliente_pessoa[0].pets;
            MyListView.ItemsSource = Mascote;
            MyListView.HasUnevenRows = true;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void listarPets()
        {
            
            Items = new ObservableCollection<string>();
            Raca = new ObservableCollection<string>();
            foreach (var pet in DrPet.Controller.Login.Login.UsuarioAtivo.Cliente_pessoa[0].pets)
            {
                Items.Add(pet.Nome);
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