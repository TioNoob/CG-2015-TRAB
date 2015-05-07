using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace CosmicSimulator.Extensions
{
    public static class GameExtensions
    {
        public static double ConvertToPIRad(this GameWindow game, double angle)
        {
            double OnePIRad = 180;

            return angle / OnePIRad;
        }

        public static double HeightInPercent(this GameWindow game, double height)
        {
            return height / game.Height;
        }

        public static double WidthInPercent(this GameWindow game, double width)
        {
            return width / game.Width;
        }

        public static void DrawCircle(this GameWindow game, double radius, Vector2d center, double circleAngle = 360)
        {
            int amountPoints = 360;

            double rad;
            double angle;

            double x;
            double y;

            Vector2d centerPercent = new Vector2d(game.WidthInPercent(center.X), game.HeightInPercent(center.Y));

            rad = game.ConvertToPIRad(circleAngle);

            GL.Begin(PrimitiveType.TriangleFan);

            GL.Vertex2(centerPercent);
            for (int actualPoint = 0; actualPoint <= amountPoints; actualPoint++)
            {
                angle = rad * Math.PI * actualPoint / amountPoints;
                x = (Math.Cos(angle) * game.WidthInPercent(radius)) + centerPercent.X;
                y = (Math.Sin(angle) * game.HeightInPercent(radius)) + centerPercent.Y;

                GL.Vertex2(x, y);
            }
            GL.End();
        }
    }
}