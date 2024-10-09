using System;
using TennisTournament.Interfaces;
using TennisTournament.Models;

namespace TennisTournament.Services
{
    public class Match : IMatch
    {
        private readonly Random _random = new Random();
        public Player GetWinner(Player player1, Player player2)
        {
            double player1Score = player1.CreateScore();
            double player2Score = player2.CreateScore();
            bool isGoodWeather = _random.Next(0, 2) == 0;
            double luckFactor = isGoodWeather ? 0.1 : -0.1;

            player1Score += player1Score * luckFactor;
            player2Score += player2Score * luckFactor;

            return player1Score > player2Score ? player1 : player2;
        }

        
    }
}
