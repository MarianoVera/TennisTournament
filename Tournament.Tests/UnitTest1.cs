using Moq;
using TennisTournament.Interfaces;
using TennisTournament.Models;
using TennisTournament.Services;

namespace TennisTournament.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayTournament_ShouldReturnWinner()
        {
            //Arrange
            var players = new List<Player>
            {
                new Man ( "Player1", 80, 70, 75 ),
                new Woman ( "Player2", 85, 90 )
            };

            var mock = new Mock<IMatch>();

            mock.Setup(mock => mock.GetWinner(It.IsAny<Player>(), It.IsAny<Player>())).Returns(players[1]);

            var tournament = new Tournament(mock.Object);

            //Act
            var winner = tournament.PlayTournament(players);

            //Arrange
            Assert.Equal("Player2", winner.Name);
        }

        [Fact]
        public void PlayTournament_ShouldException_PlayersCountIsNotPowerOfTwo()
        {
            // Arrange
            var players = new List<Player>
            {
            new Man ( "Player1", 80, 70, 75 ),
            new Woman ("Player2", 85, 90 ),
            new Man ("Player3", 90, 70, 75 )
            };
            
            var mockMatch = new Mock<IMatch>();
            var tournamentService = new Tournament(mockMatch.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => tournamentService.PlayTournament(players));
        }
    }

}