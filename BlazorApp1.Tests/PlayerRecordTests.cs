using System.Threading.Tasks;
using BlazorApp1.Models;
using Mongo2Go;
using MongoDB.Driver;
using Xunit;

namespace BlazorApp1.Tests
{
    public class PlayerRecordTests
    {
        private readonly MongoDbRunner _runner;
        private readonly IMongoCollection<PlayerRecord> _collection;

        public PlayerRecordTests()
        {
            // Start an in-memory MongoDB instance
            _runner = MongoDbRunner.Start();
            var client = new MongoClient(_runner.ConnectionString);
            var database = client.GetDatabase("TestDatabase");
            _collection = database.GetCollection<PlayerRecord>("Players");
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPlayer_WhenPlayerExists()
        {
            // Arrange
            var player = new PlayerRecord
            {
                Id = "605c72ef5f1b2c3a4d8e4f1a",
                Name = "John Doe",
                Cash = 100,
                ExperiencePoints = 200,
                EnergyPoints = 50,
                HealthPoints = 75
            };
            await _collection.InsertOneAsync(player);

            // Act
            var result = await PlayerRecord.GetByIdAsync(_collection, player.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(player.Id, result.Id);
            Assert.Equal(player.Name, result.Name);
        }

        [Fact]
        public async Task SearchByNameAsync_ShouldReturnPlayers_WhenNameMatches()
        {
            // Arrange
            var player1 = new PlayerRecord { Name = "John Doe" };
            var player2 = new PlayerRecord { Name = "Jane Doe" };
            await _collection.InsertManyAsync(new[] { player1, player2 });

            // Act
            var results = await PlayerRecord.SearchByNameAsync(_collection, "Doe");

            // Assert
            Assert.NotEmpty(results);
            Assert.Equal(2, results.Count);
        }

        protected void Dispose()
        {
            _runner.Dispose();
        }
    }
}