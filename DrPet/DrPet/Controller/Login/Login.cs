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
        #region Campos
        private  HttpClient client;
        private static string path = ""; //https://localhost:54578/api/PessoaFisica
        public static Cliente_pessoa UsuarioAtivo { get; set; }
        private static Autenticacao autenticacao { get; set; }
        private static string email;
        private static string senha;
        #endregion

        #region Construtor
        public Login()
        {
            client = new HttpClient();
           

            if (App.Current.Properties.ContainsKey("UserDetail"))
            {
                Autenticacao aut = JsonConvert.DeserializeObject<Autenticacao>((string)App.Current.Properties["UserDetail"]);
                autenticacao = aut;
                email = aut.Email;
                senha = aut.Senha;
            }
        }
        public Login(string _email, string _senha)
        {
            client = new HttpClient();
            senha = _senha;
            email = _email;
            if (!App.Current.Properties.ContainsKey("UserDetail"))
            {
                App.Current.Properties.Add("UserDetail", null);
                App.Current.Properties.Add("IsLoggedIn", false);
            }
            GuardarInformacoes();
        }
        #endregion

        #region Propriedades
        public string MensagemErro { get; set; }

        public bool EstaLogado
        { get
            {
                if (!App.Current.Properties.ContainsKey("IsLoggedIn"))
                    return false;
                else
                {
                    try
                    {
                        return Convert.ToBoolean((string)App.Current.Properties["IsLoggedIn"]);
                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                }   
            }
            set
            {
                EstaLogado = value;
                this.EstaLogado = Convert.ToBoolean((string)App.Current.Properties["IsLoggedIn"]);
            }
        }
        #endregion

        public async Task<String> GetUsuariotAsync()
        {
            path = Constants.URIPessoaFisica + "?email=" + email + "&senha=" + senha;   
            Cliente_pessoa _usuario = null;
            try
            {
                Model.Token.TokenDeCancelamento tokenDeCancelamento = new Model.Token.TokenDeCancelamento();
                
                HttpResponseMessage response = await client.GetAsync(path, tokenDeCancelamento.getCancellationToken());
                if (response.IsSuccessStatusCode)
                {
                    var conteudo = await response.Content.ReadAsStringAsync();
                    _usuario = JsonConvert.DeserializeObject<Cliente_pessoa>(conteudo);
                    
                    UsuarioAtivo = _usuario;
                    UsuarioAtivo.Usuario.Autenticacao = autenticacao;
                    //UsuarioAtivo.Autenticacao.Senha = senha;
                    return "sucesso";
                }
                else
                {
                    string resp = response.Content.ReadAsStringAsync().Result;
                    return resp;
                }
                
            }
            catch(Exception erro)
            {
                MensagemErro = erro.Message;
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

        public bool AnularDetalhesDoUsuario()
        {
            try
            {
                App.Current.Properties["UserDetail"] = null;
                App.Current.Properties["IsLoggedIn"] = Boolean.FalseString;
                return true;
            }
            catch(Exception e)
            {
                MensagemErro = e.Message;
                return false;
            }
        }
        
    }

}