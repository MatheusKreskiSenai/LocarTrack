using LocarAndTrack.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace LocarAndTrack.online.Services
{
    public class VeiculoService
    {
        private readonly HttpClient _httpClient;

        public VeiculoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Veiculo>> ObterVeiculosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Veiculo>>("api/Veiculos");
        }
    }
}

