using TennisTournament.Models;

namespace TennisTournament.Interfaces
{
    public interface ITournament
    {
        Player PlayTournament(List<Player> players);
    }
}
