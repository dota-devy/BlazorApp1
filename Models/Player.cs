namespace BlazorApp1.Models
{
    public class Player
    {
        public string Id { get; set; } // Unique identifier for the player
        public string Name { get; set; } // Player's name
        public decimal Cash { get; set; } // Cash in dollars
        public int ExperiencePoints { get; set; } // Experience points
        public int EnergyPoints { get; set; } // Energy points
        public int HealthPoints { get; set; } // Health points

        // Constructor to create a Player from a PlayerRecord
        public Player(PlayerRecord record)
        {
            Id = record.Id;
            Name = record.Name;
            Cash = record.Cash;
            ExperiencePoints = record.ExperiencePoints;
            EnergyPoints = record.EnergyPoints;
            HealthPoints = record.HealthPoints;
        }
    }
}