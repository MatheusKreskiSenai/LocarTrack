using LocarAndTrack.Models;

namespace LocarAndTrack.web.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsUserAuthenticated();
        Task<string> Login(ClienteLogin request);
        Task<bool> Register(RegisterModel request);
    }
}
