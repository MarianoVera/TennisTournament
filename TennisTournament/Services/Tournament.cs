using System.ComponentModel.DataAnnotations.Schema;
using TennisTournament.Interfaces;
using TennisTournament.Models;

namespace TennisTournament.Services
{
    public class Tournament : ITournament
    {
        public int Id { get; set; }
        [NotMapped]
        public IMatch Match { get; set; }
        public DateTime Date { get; set; }
        public string Winner { get; set; }
        public string Gender { get; set; }

        public Tournament() { }


        public Player PlayTournament (List<Player> players)
        {
            if((players.Count & (players.Count - 1)) != 0)
            {
                throw new ArgumentException("The players must be a power of 2.");
            }

            while(players.Count > 1)
            {
                List<Player> winners = new List<Player>();

                for(int i = 0; i < players.Count; i+=2)
                {
                    Player winner = Match.GetWinner(players[i], players[i+1]);
                    winners.Add(winner);
                }
                players = winners;
            }

            return players[0];
        }

       

        
    }
}
