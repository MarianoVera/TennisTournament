using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisTournament.Tests
{
    public class TournamentResultsIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public TournamentResultsIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GetTournamentResults_ShouldReturnResults()
        {
            // Act
            var response = await _client.GetAsync("/results?date=2024-10-10&gender=Male");

            // Assert
            response.EnsureSuccessStatusCode();  
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(responseString);  
        }
    }

}
