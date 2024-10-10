using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisTournament.DTO;

namespace TennisTournament.Tests
{
    public class TournamentIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TournamentIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task SimulateTournament_ShouldReturnWinner()
        {
            // Arrange
            var players = new List<PlayerDTO>
        {
            new PlayerDTO { Name = "Player1", SkillLevel = 80, Gender = "Male", Strength = 85, Speed = 90 },
            new PlayerDTO { Name = "Player2", SkillLevel = 75, Gender = "Male", Strength = 80, Speed = 88 }
        };

            var content = new StringContent(JsonConvert.SerializeObject(players), Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/simulate", content);

            // Assert
            response.EnsureSuccessStatusCode();  
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Player", responseString);  
        }
    }

}
