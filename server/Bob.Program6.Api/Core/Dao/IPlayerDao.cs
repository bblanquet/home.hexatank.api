using Bob.Program6.Api.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Dao
{
    public interface IPlayerDao
    {
        Task<Player> GetPlayer(string name, string password);
        Task<Player> GetUser(string name);
        Task<List<Player>> GetPlayers();
        Task Update(Player user, int score);
        Task<bool> Exist(string name);
        Task<bool> Create(AuthenticateRequest request);
        Task<int> GetCount();
    }
}
