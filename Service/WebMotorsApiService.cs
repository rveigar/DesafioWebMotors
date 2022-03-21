using DesafioWebMotors.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;


namespace DesafioWebMotors.Service
{
    public class WebMotorsApiService
    {
        private HttpClient _httpClient;
        public WebMotorsApiService()
        {
            _httpClient = new HttpClient();
        }

        public string _urlDaAPI = "https://desafioonline.webmotors.com.br/api/OnlineChallenge/";
        public async Task<List<Marca>> ListarMarcas()
        {
            var resposta = await _httpClient.GetAsync(_urlDaAPI + "Make");

            if (resposta.IsSuccessStatusCode)
            {
                var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                var conversaoDoJson = JsonConvert.DeserializeObject<List<Marca>>(conteudoDaResposta);
                return conversaoDoJson;
            }

            return new List<Marca>();
        }

        public async Task<List<Modelo>> ListarModelos(int id)
        {
            var resposta = await _httpClient.GetAsync(_urlDaAPI+"Model?MakeID="+id);

            if (resposta.IsSuccessStatusCode)
            {
                var conteudoDaResposta = await resposta.Content.ReadAsStringAsync();
                var conversaoDoJson = JsonConvert.DeserializeObject<List<Modelo>>(conteudoDaResposta);
                return conversaoDoJson;
            }

            return new List<Modelo>();
        }
    }
}
