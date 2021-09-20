using Bob.Program6.Api.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Services
{
    public interface IPlayerService
    {
        Task<AuthenticateResponse> SignUp(AuthenticateRequest request);
        Task<AuthenticateResponse> SignIn(AuthenticateRequest request);
        Task<Player> GetByName(string name);
        Task<List<PlayerInfo>> Get100Players();
        Task Update(Player user, int score);
        Task<int> GetRank(string name);
    }
}
