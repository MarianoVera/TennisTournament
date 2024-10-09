namespace TennisTournament.Models
{
    public class Player
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public string Gender { get; set; }

        public Player(string name, int skillLevel, string gender)
        {
            Name = name;
            SkillLevel = skillLevel;
            Gender = gender;
        }
    }
}
