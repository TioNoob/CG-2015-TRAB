using CosmicSimulatorModel.Primitives.Models;

namespace CosmicSimulatorModel.Models
{
    public class Orb
    {
        public string Name { get; set; }

        public double Mass { get; set; }

        public double Radius { get; set; }

        public OrbVectors Vectors { get; set; }

        public MyPoint ActualPosition { get; set; }

        public Orb(string name, double mass, double radius, MyPoint actualPostion, Vector velocity)
        {
            Name = name;
            Mass = mass;
            Radius = radius;
            ActualPosition = actualPostion;

            Vectors = new OrbVectors()
            {
                Velocity = velocity,
                Attraction = new Vector(new MyPoint(0,0))
            };
        }
    }
}