using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DrPet.Model;
using System.Net.Http;

namespace DrPet.Controller.Login
{
    public class Cadastrar
    {

        private HttpClient client;

        public Cadastrar()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<String> CadastrarCliente(Usuario usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;

            response = await client.PostAsync(Constants.URI, content, Constants.getCancellationToken());
            if(response.IsSuccessStatusCode)
            {
                return "Cliente cadastrado com sucesso";
            }
            else
            {
                string resposta = response.Content.ReadAsStringAsync().ToString();
                return resposta;
            }
                
        }

        public void SetNovoUsuario()
        {

        }

    }
}
