namespace BlazorApp1.Models
{
    public class Player
    {
        public string Id { get; set; } // Unique identifier for the player
        public string Name { get; set; } // Player's name

        private decimal _cash;
        public decimal Cash
        {
            get => _cash;
            set
            {
                var delta = value - _cash;
                _cash = value;
                LogChange("Cash", delta);
            }
        }

        private int _experiencePoints;
        public int ExperiencePoints
        {
            get => _experiencePoints;
            set
            {
                var delta = value - _experiencePoints;
                _experiencePoints = value;
                LogChange("ExperiencePoints", delta);
            }
        }

        private int _energyPoints;
        public int EnergyPoints
        {
            get => _energyPoints;
            set
            {
                var delta = value - _energyPoints;
                _energyPoints = value;
                LogChange("EnergyPoints", delta);
            }
        }

        private int _healthPoints;
        public int HealthPoints
        {
            get => _healthPoints;
            set
            {
                var delta = value - _healthPoints;
                _healthPoints = value;
                LogChange("HealthPoints", delta);
            }
        }

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

        // Method to log changes
        private void LogChange(string propertyName, decimal delta)
        {
            Console.WriteLine($"{propertyName} changed by {delta}");
        }
    }
}