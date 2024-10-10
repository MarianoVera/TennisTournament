using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TennisTournament.Data;
using TennisTournament.DTO;
using TennisTournament.Models;
using TennisTournament.Services;

namespace TennisTournament.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TournamentController : ControllerBase
    {
        private readonly TournamentFactory _tournamentFactory;
        private readonly ApplicationDbContext _context;

        public TournamentController(TournamentFactory tournamentFactory, ApplicationDbContext context)
        {
            _tournamentFactory = tournamentFactory;
            _context = context;
        }

        [HttpPost("simulate")]
        public async Task<IActionResult> SimulateTournamentAsync([FromBody] List<PlayerDTO> playerDTO)
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

            var tournament = _tournamentFactory.Create();
            var winner = tournament.PlayTournament(players);

            var tournamentDTO = new TournamentDTO
            {
                Winner = winner.Name,
                TournamentType = players.Any(p => p is Man) ? "Male" : "Female", 
                Date = DateTime.Now,
                Gender = players.Any(p => p is Man) ? "Male" : "Female"
            };

            _context.TournamentResults.Add(tournamentDTO);
            await _context.SaveChangesAsync();

            return Ok(winner);
        }

        [HttpGet("results")]
        public async Task<ActionResult<List<TournamentDTO>>> GetTournamentResults(DateTime? date = null, string gender = null)
        {
            var results = await _context.Tournaments
            .Where(t => !date.HasValue || t.Date.Date == date.Value.Date)
            .Select(t => new TournamentDTO
            {
                Winner = t.Winner, 
                TournamentType = t.Gender, 
                Date = t.Date
            })
            .ToListAsync();

            return Ok(results);
        }
    }
}