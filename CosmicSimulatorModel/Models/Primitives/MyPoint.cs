using CosmicSimulatorModel.Enums;
using OpenTK;

namespace CosmicSimulatorModel.Models.Primitives
{
    public class MyPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public MyPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static MyPoint operator +(MyPoint point1, MyPoint point2)
        {
            return Do(Operation.Sum, point1, point2);
        }
        public static MyPoint operator -(MyPoint point1, MyPoint point2)
        {
            return Do(Operation.Sub, point1, point2);
        }
        public static MyPoint operator *(MyPoint point1, MyPoint point2)
        {
            return Do(Operation.Mul, point1, point2);
        }
        public static MyPoint operator /(MyPoint point1, MyPoint point2)
        {
            return Do(Operation.Div, point1, point2);
        }

        public static MyPoint operator +(MyPoint point, double value)
        {
            return Do(Operation.Sum, point, value);
        }
        public static MyPoint operator -(MyPoint point, double value)
        {
            return Do(Operation.Sub, point, value);
        }
        public static MyPoint operator *(MyPoint point, double value)
        {
            return Do(Operation.Mul, point, value);
        }
        public static MyPoint operator /(MyPoint point, double value)
        {
            return Do(Operation.Div, point, value);
        }

        private static MyPoint Do(Operation operation, MyPoint point1, MyPoint point2)
        {
            double X;
            double Y;

            switch (operation)
            {
                case Operation.Sum:
                    X = point1.X + point2.X;
                    Y = point1.Y + point2.Y;
                    break;

                case Operation.Sub:
                    X = point1.X - point2.X;
                    Y = point1.Y - point2.Y;
                    break;

                case Operation.Mul:
                    X = point1.X * point2.X;
                    Y = point1.Y * point2.Y;
                    break;

                default:
                    X = point1.X / point2.X;
                    Y = point1.Y / point2.Y;
                    break;
            }

            return new MyPoint(X, Y);
        }
        private static MyPoint Do(Operation operation, MyPoint point, double value)
        {
            return Do(operation, point, new MyPoint(value, value));
        }

        public static implicit operator Vector2d(MyPoint point)
        {
            return new Vector2d(point.X, point.Y);
        }
    }
}