﻿
using System.Text.Json.Serialization;

namespace Bob.Program6.Api.Core.Model
{
    public class Player
    {
        public string Name { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public int Score { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Red { get; set; }
        public void Update(Player player)
        {
            this.Green = player.Green;
            this.Red = player.Red;
            this.Blue = player.Blue;
            this.Score = player.Score;
        }
    }
}
