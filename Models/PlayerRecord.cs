using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace BlazorApp1.Models
{
    public class PlayerRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString(); // Default value for Id

        [BsonElement("name")]
        public required string Name { get; set; } // Player's name

        [BsonElement("cash")]
        public decimal Cash { get; set; } // Cash in dollars

        [BsonElement("experiencePoints")]
        public int ExperiencePoints { get; set; } // Experience points

        [BsonElement("energyPoints")]
        public int EnergyPoints { get; set; } // Energy points

        [BsonElement("healthPoints")]
        public int HealthPoints { get; set; } // Health points

        // Static method to retrieve a player record by ID
        public static async Task<PlayerRecord> GetByIdAsync(IMongoCollection<PlayerRecord> collection, string id)
        {
            return await collection.Find(record => record.Id == id).FirstOrDefaultAsync();
        }

        // Static method to search for a player record by name
        public static async Task<List<PlayerRecord>> SearchByNameAsync(IMongoCollection<PlayerRecord> collection, string name)
        {
            return await collection.Find(record => record.Name.ToLower().Contains(name.ToLower())).ToListAsync();
        }
    }
}