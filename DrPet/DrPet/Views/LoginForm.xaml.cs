﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DrPet.Model;

namespace DrPet.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginForm : ContentView
	{
        
		public LoginForm ()
		{
			InitializeComponent();
            Init();
            
		}

        public void Init()
        {
            BackgroundColor = Constants.BackGroundColor;
            lblEmail.TextColor = Constants.MainTextColor;
            lblSenha.TextColor = Constants.MainTextColor;
            rodadorAtividade.IsVisible = false;
            iconeLogin.HeightRequest = Constants.loginIconHeight;
            //muda para linha de senha quando email estiver completo
            entryEmail.Completed += (s, e) => entrySenha.Focus();
            entrySenha.Completed += (s, e) => Entrar_Clicked(s, e);
        }
        public async void Entrar_Clicked(object sender, EventArgs e)
        {
            string resposta;
            indicadorAtividade.IsRunning = true;
            DrPet.Controller.Login.Login logar = new Controller.Login.Login();
            resposta = await logar.GetUsuariotAsync(entryEmail.Text, entrySenha.Text);
            if (resposta == "sucesso")
            {
                App.Current.MainPage = new NavigationPage(new DrPet.Views.PaginaInicial.PaginaInicial());
                indicadorAtividade.IsRunning = false;
            }
            else
            {
               await App.Current.MainPage.DisplayAlert("Erro","Erro ao tentar se conectar: " + resposta, "OK");
                indicadorAtividade.IsRunning = false;
            }
            
        }

        public async void CriarConta_Clicked(object sender, EventArgs e)
        {
            try
            {
                //App.Current.MainPage = new NavigationPage(new ContentPage { Content = new DrPet.Views.CadastroForm() });
                await Navigation.PushAsync(new ContentPage { Content = new DrPet.Views.CadastroForm() });
            }
            catch(Exception erro)
            {
                await App.Current.MainPage.DisplayAlert("erro",erro.Message,"cancelar");
            }
        }

    }
}