using Bob.Program6.Api.Core.Model;
using Bob.Program6.Api.Core.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bob.Program6.Api.Core.Dao
{
    public class PlayerDao : IPlayerDao
    {
        private IDataAccess _dataAccess;

        public PlayerDao(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<Player> GetPlayer(string name, string password)
        {
            var players = await this.GetPlayers();
            var hashedPassword = CipheringHelper.ToSha256Hash(password);
            return players.FirstOrDefault(u => u.Name == name && u.Password == hashedPassword);
        }

        public async Task<int> GetCount()
        {
            var players = await this.GetPlayers();
            return players.Count;
        }

        public async Task<Player> GetUser(string name)
        {
            var players = await this.GetPlayers();
            return players.FirstOrDefault(u => u.Name == name);
        }

        public async Task<List<Player>> GetPlayers()
        {
            return await this._dataAccess.LoadAll<Player>("player");
        }

        public async Task Update(Player player, int score)
        {
            player.Score = score;
            await this._dataAccess.Update<Player>("player",player, p=>p.Name);
        }

        public async Task<bool> Exist(string name)
        {
            var players = await this.GetPlayers();
            return players.Any(p=>p.Name == name);
        }

        public async Task<bool> Create(AuthenticateRequest request)
        {
            await this._dataAccess.Add("player", new Player
            {
                Name = request.Name,
                Password = CipheringHelper.ToSha256Hash(request.Password),
                Score = 0
            });
            return true;
        }
    }
}
