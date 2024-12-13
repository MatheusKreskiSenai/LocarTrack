using LocarAndTrack.Models;
using System.Net.Http.Json;

namespace LocarAndTrack.online.Services
{
    public class LocadoraService
    {
        private readonly HttpClient _httpClient;

        public LocadoraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Locadora>> ObterLocadorasAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Locadora>>("api/Locadoras");
        }

        public async Task<bool> PostLocadora(Locadora locadora)
        {
            var resposta = await _httpClient.PostAsJsonAsync("api/locadoras", locadora);

            return resposta.IsSuccessStatusCode;
        }
    }
}
