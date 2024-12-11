using LocarAndTrack.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace LocarAndTrack.web.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _http;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthenticationService(HttpClient http, AuthenticationStateProvider authStateProvider)
        {
            _http = http;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<string> Login(ClienteLogin request)
        {
            try
            {
                var result = await _http.PostAsJsonAsync("api/auth/login", request);
                //var user = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    var user = await result.Content.ReadFromJsonAsync<ClienteDto>();

                    return user.Token;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Register(RegisterModel request)
        {
            var result = await _http.PostAsJsonAsync("api/auth/register", request);
            return result.IsSuccessStatusCode;
        }
    }
}
