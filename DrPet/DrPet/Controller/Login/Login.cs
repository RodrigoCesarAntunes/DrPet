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
            
            path = Constants.URI + "?email=" + email + "&senha=" + senha;
            string usuariojson = "";
            Usuario _usuario = null;
            try
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    usuariojson = await client.GetStringAsync(path);
                }
                _usuario = (Usuario)JsonConvert.DeserializeObject(usuariojson);
                UsuarioAtivo = _usuario;
                return "sucesso";
            }
            catch(Exception erro)
            {
                return null;
            }
        }


    }
}
