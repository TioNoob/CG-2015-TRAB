using CosmicSimulatorModel.Primitives.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
