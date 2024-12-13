using LocarAndTrack.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace LocarAndTrack.online.Services
{
    public class LocacaoService
    {
        private readonly HttpClient _httpClient;

        public LocacaoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Locacao>> ObterLocacoesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Locacao>>("api/Locacoes");
        }
    }
}
