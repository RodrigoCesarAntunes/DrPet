using DrPet.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DrPet.Controller.Mascotes
{
    public class Adicionar
    {
        private HttpClient client;

        public Adicionar()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            
        }

        public async Task<String> Add(Model.Pets pet)
        {
            var json = JsonConvert.SerializeObject(pet,new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = null;
            Model.Token.TokenDeCancelamento tokenDeCancelamento = new Model.Token.TokenDeCancelamento();

            response = await client.PostAsync(Constants.URIPet, content, tokenDeCancelamento.getCancellationToken());
            if (response.IsSuccessStatusCode)
            {
                return "Pet cadastrado com sucesso";
            }
            else
            {
                string resposta = response.Content.ReadAsStringAsync().Result;
                return resposta;
            }

        }
    }
}
