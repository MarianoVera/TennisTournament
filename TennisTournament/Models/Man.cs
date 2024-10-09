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

    }
}
