namespace TennisTournament.Models
{
    public class Woman : Player
    {
        public int ReactionTime { get; set; }
        
        public Woman(string name, int skillLevel, int reactionTime) : base(name, skillLevel, "Female")
        {
            ReactionTime = reactionTime;
        }

        public override double CreateScore()
        {
            return SkillLevel * 0.6 + ReactionTime * 0.4;
        }
    }
}
