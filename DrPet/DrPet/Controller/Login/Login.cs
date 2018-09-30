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
        
        public Login()
        {
            client = new HttpClient();
        }

        public async Task<String> GetUsuariotAsync(string email, string senha)
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


    }
}
