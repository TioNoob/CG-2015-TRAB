using CosmicSimulatorModel.Models;
using CosmicSimulatorModel.Models.Primitives;
using CosmicSimulatorModel.Primitives.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CosmicSimulatorController
{
    public class CosmicController
    {
        public const double GravitationalConstant = 6.673E-11;

        private static CosmicController _Instance;

        public static CosmicController Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new CosmicController();

                return _Instance;
            }
        }

        public List<Orb> Orbs { get; set; }

        private CosmicController()
        {
            Orbs = new List<Orb>();
        }

        public void LoadSolarSystem()
        {
            Orb Earth = new Orb("Earth", 40, 100, new MyPoint(0, 0), new Vector(new MyPoint(20, 20)));
            Orb Moon = new Orb("Moon", 10, 35, new MyPoint(300, 200), new Vector(new MyPoint(20, 20)));

            Orbs.Add(Earth);
            Orbs.Add(Moon);
        }

        public void UpdateOrbsPosition()
        {
            Orbs.ForEach(orb => {
                CalculateInteration(orb, Orbs);
                UpdatePosition(orb);
            });
        }

        public void UpdatePosition(Orb orb) {

            OrbVectors orbVectors;

            orbVectors = orb.Vectors;

            orb.ActualPosition += orbVectors.Resultant.EndPoint;
        }

        public void CalculateInteration(Orb orb, List<Orb> allOrbs)
        {
            IEnumerable<Orb> otherOrbs;
            OrbVectors orbVectors;

            Vector attraction;

            otherOrbs = allOrbs.Where(otherOrb => otherOrb != orb);
            orbVectors = orb.Vectors;

            orbVectors.Attraction = new Vector(new MyPoint(0,0));
            foreach(Orb otherOrb in otherOrbs)
            {
                attraction = CalculateAttraction(orb, otherOrb);
    
                orbVectors.Attraction += attraction;
            }
        }

        private Vector CalculateAttraction(Orb orb1, Orb orb2)
        {
            Vector GravitationalForce;
            Vector Acceleration;
            Vector Velocity;

            GravitationalForce = CalculateGravitationalForce(orb1, orb2);
            Acceleration = CalculateAcceleration(GravitationalForce, orb1.Mass);
            Velocity = CalculateVelocity(orb1.Mass, Acceleration);

            return Velocity;
        }

        /// <summary>
        /// V = ma
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="acceleration"></param>
        /// <returns></returns>
        private Vector CalculateVelocity(double mass, Vector acceleration)
        {
            return acceleration * mass;
        }

        /// <summary>
        /// F = ma <=> a = F/m 
        /// </summary>
        /// <param name="force"></param>
        /// <param name="mass"></param>
        /// <returns></returns>
        private Vector CalculateAcceleration(Vector force, double mass)
        {
            return force / mass;
        }

        private Vector CalculateGravitationalForce(Orb orb1, Orb orb2)
        {
            double gravitationalIntensity;

            Vector gravitationalForce;
            MyPoint positionEndPoint;
            
            gravitationalIntensity = CalculateGravitationalIntensity(orb1, orb2);

            positionEndPoint = CalculatePositionEndPoint(orb1, orb2, gravitationalIntensity);

            gravitationalForce = new Vector(orb1.ActualPosition, positionEndPoint);

            return gravitationalForce;
        }

        /// <summary>
        /// Fg = G * ((M1 * M2) / r^2) 
        /// </summary>
        /// <param name="orb1"></param>
        /// <param name="orb2"></param>
        /// <returns></returns>
        private double CalculateGravitationalIntensity(Orb orb1, Orb orb2)
        {
            double distanceBetweenOrbs;

            distanceBetweenOrbs = Triangles.CalculateHypotenuse(orb1.ActualPosition, orb2.ActualPosition);

            return GravitationalConstant * ((orb1.Mass * orb2.Mass) / Math.Pow(distanceBetweenOrbs, 2));
        }

        private MyPoint CalculatePositionEndPoint(Orb orb1, Orb orb2, double forceIntensity)
        {
            DecomposedVector decomposedVector;

            double triangleMajorAdjacentCateto;
            double triangleMajorHypotenuse;

            double triangleMinorAdjacentCateto;
            double triangleMinorOppositeCateto;
            double triangleMinorHypotenuse;

            double angleBetweenHypotenuseAndAdjacentCateto;

            decomposedVector = new DecomposedVector(orb1.ActualPosition, orb2.ActualPosition);

            triangleMajorAdjacentCateto = decomposedVector.HorizontalPoint.X;
            triangleMajorHypotenuse = Triangles.CalculateHypotenuse(orb1.ActualPosition, orb2.ActualPosition);

            // *180 to convert radianos to degrees
            angleBetweenHypotenuseAndAdjacentCateto = Math.Acos(Triangles.CosTeta(triangleMajorAdjacentCateto, triangleMajorHypotenuse)) * 180;

            triangleMinorHypotenuse = forceIntensity;
            triangleMinorAdjacentCateto = Triangles.AdjacentCateto(angleBetweenHypotenuseAndAdjacentCateto, triangleMinorHypotenuse);
            triangleMinorOppositeCateto = Triangles.OppositeCateto(angleBetweenHypotenuseAndAdjacentCateto, triangleMinorHypotenuse);

            return new MyPoint(triangleMinorAdjacentCateto, triangleMinorOppositeCateto);
        }
    }
}