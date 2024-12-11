using LocarAndTrack.Models;

namespace LocarAndTrack.online.Services
{
    public interface IAuthenticationService
    {
        Task<bool> IsUserAuthenticated();
        Task<string> Login(ClienteLogin request);
        Task<bool> Register(RegisterModel request);
    }
}
