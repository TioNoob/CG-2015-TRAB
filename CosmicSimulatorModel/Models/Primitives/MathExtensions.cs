using System;

namespace CosmicSimulatorModel.Models.Primitives
{
    public static class MyMath
    {
        public static double RadianToDegree(double angle)
        {
            return angle * (180.0 / Math.PI);
        }

        public static double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}