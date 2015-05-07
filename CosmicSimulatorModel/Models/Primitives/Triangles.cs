using CosmicSimulatorModel.Primitives.Models;
using System;

namespace CosmicSimulatorModel.Models.Primitives
{
    public class Triangles
    {
        /*
         * d = ( (x1 - x2)^2 + (y1 - y2)^2 ) ^ (1/2)
         */
        public static double CalculateHypotenuse(MyPoint point1, MyPoint point2)
        {
            double x;
            double y;

            double powX;
            double powY;

            double distance;

            x = point1.X - point2.X;
            y = point1.Y - point2.Y;

            powX = Math.Pow(x, 2);
            powY = Math.Pow(y, 2);

            distance = Math.Sqrt(powX + powY);

            return distance;
        }

        /// <summary>
        /// Sin(teta) = OppositeCateto / Hypotenuse
        /// OppositeCateto = Sin(teta) * Hypotenuse
        /// </summary>
        /// <param name="sinTeta"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double OppositeCateto(double teta, double hypotenuse)
        {
            return Math.Sin(teta) * hypotenuse;
        }

        public static double SinTeta(double oppositeCateto, double hypotenuse)
        {
            return oppositeCateto / hypotenuse;
        }

        /// <summary>
        /// Cos(teta) = AdjacentCateto / Hypotenuse
        /// AdjacentCateto = Cos(teta) * Hypotenuse
        /// </summary>
        /// <param name="teta"></param>
        /// <param name="hypotenuse"></param>
        /// <returns></returns>
        public static double AdjacentCateto(double teta, double hypotenuse)
        {
            return Math.Cos(teta) * hypotenuse;
        }

        public static double CosTeta(double adjacentCateto, double hypotenuse)
        {
            return adjacentCateto / hypotenuse;
        }
    }
}