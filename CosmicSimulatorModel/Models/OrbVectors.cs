using CosmicSimulatorModel.Models.Primitives;

namespace CosmicSimulatorModel.Models
{
    public class OrbVectors
    {
        public Vector Velocity { get; set; }
        public Vector Attraction { get; set; }
        public Vector Resultant
        {
            get
            {
                return Velocity + Attraction;
            }
        }
    }
}