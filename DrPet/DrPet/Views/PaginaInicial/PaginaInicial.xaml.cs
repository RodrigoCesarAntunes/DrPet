﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrPet.Model;
namespace DrPet.Views.PaginaInicial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaInicial : MasterDetailPage
    {
        public PaginaInicial()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        public PaginaInicial(Usuario usuario)
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
            
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as PaginaInicialMenuItem;

            if (item == null)
                return;
            else if(item.Title == "Pagina Inicial")
                Detail = new PaginaInicial() { Title = "Meus Bichinhos" };
            else if(item.Title == "Meus Pets")
                Detail = new NavigationPage( new Pets.MostrarPetsForm()) { Title = "Meus Bichinhos" };
            
            //var page = (Page)Activator.CreateInstance(item.TargetType);
            //page.Title = item.Title;

            //Navigation.PushAsync(page);
             //Detail = new NavigationPage(new Pets.MostrarPetsForm()) { Title = "Meus Bichinhos"};
            
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}