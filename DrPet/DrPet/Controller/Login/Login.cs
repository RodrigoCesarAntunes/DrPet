using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using DrPet.Model;
using Newtonsoft.Json;

namespace DrPet.Controller.Login
{
    public class Login
    {
        private  HttpClient client;
        private static string path = "http://localhost:54578/api/PessoaFisica";
        public static Usuario UsuarioAtivo { get; set; }
        private static string email;
        private static string senha;
        public bool EstaLogado
        { get
            {
                if (!App.Current.Properties.ContainsKey("IsLoggedIn"))
                    return false;
                else
                    return true;
            }
            set
            {
                EstaLogado = value;
                this.EstaLogado = JsonConvert.DeserializeObject<bool>((string)App.Current.Properties["IsLoggedIn"]);
            }
        }

        public Login(string _email, string _senha)
        {
            client = new HttpClient();
            senha = _senha;
            email = _email;
            App.Current.Properties.Add("UserDetail", null);
            App.Current.Properties.Add("IsLoggedIn", false);
            GuardarInformacoes();
        }

        public Login()
        {
            client = new HttpClient();
            if (App.Current.Properties.ContainsKey("UserDetail")) 
            {
                Autenticacao aut = JsonConvert.DeserializeObject<Autenticacao>((string)App.Current.Properties["UserDetail"]);
                email = aut.Email;
                senha = aut.Senha;
            }
            
        }


        public async Task<String> GetUsuariotAsync()
        {
            
            path = Constants.URIPessoaFisica + "?email=" + email + "&senha=" + senha;
            
            Usuario _usuario = null;
            try
            {
                Model.Token.TokenDeCancelamento tokenDeCancelamento = new Model.Token.TokenDeCancelamento();
                HttpResponseMessage response = await client.GetAsync(path, tokenDeCancelamento.getCancellationToken());
                if (response.IsSuccessStatusCode)
                {
                    var conteudo = await response.Content.ReadAsStringAsync();
                    _usuario = JsonConvert.DeserializeObject<Usuario>(conteudo);
                    UsuarioAtivo = _usuario;
                    //UsuarioAtivo.Autenticacao.Senha = senha;
                    return "sucesso";
                }
                else
                {
                    string resp = response.Content.ReadAsStringAsync().ToString();
                    return resp;
                }
                
            }
            catch(Exception erro)
            {
                return null;
            }
        }

        private async void GuardarInformacoes()
        {
            Autenticacao aut = new Autenticacao();
            aut.Email = email;
            aut.Senha = senha;
            App.Current.Properties["UserDetail"] = JsonConvert.SerializeObject(aut);
            App.Current.Properties["IsLoggedIn"] = Boolean.TrueString;
            await App.Current.SavePropertiesAsync();
        }

        
    }
}
