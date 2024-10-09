using System.Numerics;

namespace TennisTournament.Models
{
    public class Man : Player
    {

        public int Strength { get; set; }
        public int Speed { get; set; }
        public Man(string name, int skillLevel, int strength, int speed) : base(name, skillLevel, "Male")
        {
            Strength = strength;
            Speed = speed;
        }

        public override double CreateScore()
        {
            return SkillLevel * 0.6 + Strength * 0.2 + Speed * 0.2;
        }
    }
}
