using TennisTournament.Interfaces;

namespace TennisTournament.Services
{
    public class TournamentFactory
    {
        private readonly IMatch _match;

        public TournamentFactory(IMatch match)
        {
            _match = match;
        }

        public Tournament Create()
        {
            return new Tournament
            {
                Match = _match
            };
        }
    }
}
