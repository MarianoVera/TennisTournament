namespace TennisTournament.Models
{
    public abstract class Player
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public string Gender { get; set; }

        public Player(string name, int skillLevel, string gender)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name cannot be NULL.");
            if (skillLevel < 0 || skillLevel > 100) throw new ArgumentException("The skill level must be between 0 and 100.");
            
            Name = name;
            SkillLevel = skillLevel;
            Gender = gender;
        }

        public abstract double CreateScore();
    }
}
