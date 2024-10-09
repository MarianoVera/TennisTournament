using Microsoft.AspNetCore.Mvc;
using TennisTournament.DTO;
using TennisTournament.Models;
using TennisTournament.Services;

namespace TennisTournament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly Tournament _tournament;

        public TournamentController(Tournament tournament)
        {
            _tournament = tournament;
        }

        [HttpPost("simulate")]
        public IActionResult SimulateTournament([FromBody] List<PlayerDTO> playerDTO)
        {
            var players = new List<Player>();

            foreach (var dto in playerDTO)
            {
                Player player;
                if (dto.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    player = new Man(dto.Name, dto.SkillLevel, dto.Strength, dto.Speed);
                }
                else if (dto.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase))
                {
                    player = new Woman(dto.Name, dto.SkillLevel, dto.ReactionTime);
                }
                else
                {
                    return BadRequest("The genre must be 'Male' o 'Female'.");
                }

                players.Add(player);
            }

            var winner = _tournament.PlayTournament(players);
            return Ok(winner);
        }

        [HttpGet("results")]
        public ActionResult<List<TournamentDTO>> GetTournamentResults(DateTime? date = null, string gender = null)
        {

            return Ok(new List<TournamentDTO>());
        }
    }
}