using TennisTournament.Models;

namespace TennisTournament.Interfaces
{
    public interface IMatch
    {
        Player GetWinner(Player player1, Player player2);
    }
}
