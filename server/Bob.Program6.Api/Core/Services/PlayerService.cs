using Bob.Program6.Api.Core.Dao;
using Bob.Program6.Api.Core.Model;
using System;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bob.Program6.Security.Core.Model;
using Bob.Program6.Security.Core;

namespace Bob.Program6.Api.Core.Services
{
    public class PlayerService : IPlayerService
    {
        private const int MAX = 1000;
        private readonly IPlayerDao _playerDao;
        private readonly ITokenManager _tokenMgr;
        public PlayerService(IPlayerDao userDao, ITokenManager tokenMgr)
        {
            this._playerDao = userDao;
            this._tokenMgr = tokenMgr;
        }

        public async Task<AuthenticateResponse> SignUp(AuthenticateRequest request)
        {
            var count = await this._playerDao.GetCount();
            if (MAX < count) {
                return null;
            }

            var exist = await this._playerDao.Exist(request.Name);

            if (!exist)
            {
                var created = await this._playerDao.Create(request);
                return await this.SignIn(request);
            }
            return null;
        }

        public async Task<AuthenticateResponse> SignIn(AuthenticateRequest request)
        {
            var user = await this._playerDao.GetPlayer(request.Name, request.Password);
            if(user == null)
            {
                return null;
            }
            var token = this.GenerateToken(user);
            return new AuthenticateResponse(user.Name, token);
        }

        private string GenerateToken(Player user)
        {
            var claims = new[] { new Claim(nameof(Player.Name), user.Name) };
            var date = DateTime.Now.AddHours(1);
            return this._tokenMgr.GetToken(claims,date);
        }

        public async Task<Player> GetByName(string name)
        {
            return await this._playerDao.GetUser(name);
        }

        public async Task<List<PlayerInfo>> Get100Players()
        {
            return (await this._playerDao.GetPlayers())
                .OrderByDescending(p=>p.Score)
                .Take(100)
                .Select((p, i) => new PlayerInfo { 
                    Rank = i+1,
                    Name = p.Name,
                    Score = p.Score
                }).ToList();
        }

        public async Task Update(Player user)
        {
            await this._playerDao.Update(user);
        }

        public async Task<int> GetRank(string name)
        {
            return (await this._playerDao.GetPlayers())
                .OrderByDescending(p => p.Score)
                .Select((p, i) => new PlayerInfo
                {
                    Rank = i + 1,
                    Name = p.Name,
                    Score = p.Score
                }).FirstOrDefault(p=>p.Name == name).Rank;
        }
    }
}
