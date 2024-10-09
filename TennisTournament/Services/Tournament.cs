using TennisTournament.Interfaces;
using TennisTournament.Models;

namespace TennisTournament.Services
{
    public class Tournament
    {
        private List<Player> _players;
        private IMatch _match;

        public Tournament(List<Player> players, IMatch match) 
        { 
            _players = players;
            _match = match;
        }


        public Player PlayTournament ()
        {
            if((_players.Count & (_players.Count - 1)) != 0)
            {
                throw new ArgumentException("The players must be a power of 2.");
            }

            while(_players.Count > 1)
            {
                List<Player> winners = new List<Player>();

                for(int i = 0; i < _players.Count; i++)
                {
                    Player winner = _match.GetWinner(_players[i], _players[i+1]);
                    winners.Add(winner);
                }
                _players = winners;
            }

            return _players[0];
        }

       

        
    }
}
