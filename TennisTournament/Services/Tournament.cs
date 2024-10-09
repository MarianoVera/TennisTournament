using TennisTournament.Interfaces;
using TennisTournament.Models;

namespace TennisTournament.Services
{
    public class Tournament : ITournament
    {
        //private List<Player> _players;
        private IMatch _match;

        public Tournament(IMatch match) 
        { 
            _match = match;
        }


        public Player PlayTournament (List<Player> players)
        {
            if((players.Count & (players.Count - 1)) != 0)
            {
                throw new ArgumentException("The players must be a power of 2.");
            }

            while(players.Count > 1)
            {
                List<Player> winners = new List<Player>();

                for(int i = 0; i < players.Count; i++)
                {
                    Player winner = _match.GetWinner(players[i], players[i+1]);
                    winners.Add(winner);
                }
                players = winners;
            }

            return players[0];
        }

       

        
    }
}
