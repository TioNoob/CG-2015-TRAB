using CosmicSimulatorModel.Enums;
using CosmicSimulatorModel.Models.Primitives;

namespace CosmicSimulatorModel.Models.Primitives
{
    public class Vector
    {
        public MyPoint StartPoint { get; set; }
        public MyPoint EndPoint { get; set; }

        public Vector(MyPoint endPoint)
        {
            StartPoint = new MyPoint(0, 0);
            EndPoint = endPoint;
        }
        public Vector(MyPoint initialPoint, MyPoint endPoint)
        {
            StartPoint = new MyPoint(0,0);
            EndPoint = ConvertToOrthogonal(initialPoint, endPoint);
        }

        public MyPoint ConvertToOrthogonal(MyPoint initialPoint, MyPoint endPoint)
        {
            return endPoint - initialPoint;
        }

        public static Vector operator +(Vector vector1, Vector vector2)
        {
            return Do(Operation.Sum, vector1, vector2);
        }
        public static Vector operator -(Vector vector1, Vector vector2)
        {
            return Do(Operation.Sub, vector1, vector2);
        }
        public static Vector operator *(Vector vector1, Vector vector2)
        {
            return Do(Operation.Mul, vector1, vector2);
        }
        public static Vector operator /(Vector vector1, Vector vector2)
        {
            return Do(Operation.Div, vector1, vector2);
        }

        public static Vector operator +(Vector vector, double value)
        {
            return Do(Operation.Sum, vector, value);
        }
        public static Vector operator -(Vector vector, double value)
        {
            return Do(Operation.Sub, vector, value);
        }
        public static Vector operator *(Vector vector, double value)
        {
            return Do(Operation.Mul, vector, value);
        }
        public static Vector operator /(Vector vector, double value)
        {
            return Do(Operation.Div, vector, value);
        }

        public static implicit operator Vector(DecomposedVector decomposedVector)
        {
            MyPoint hypotenuseEnd;

            hypotenuseEnd = decomposedVector.HorizontalPoint + decomposedVector.VerticalPoint;

            return new Vector(hypotenuseEnd);
        }
        public static explicit operator DecomposedVector(Vector vector)
        {
            return new DecomposedVector(vector.StartPoint, vector.EndPoint);
        }

        private static Vector Do(Operation operation, Vector vector1, Vector vector2)
        {
            switch (operation)
            {
                case Operation.Sum:
                    return ((DecomposedVector)vector1) + ((DecomposedVector)vector2);
                case Operation.Sub:
                    return ((DecomposedVector)vector1) - ((DecomposedVector)vector2);
                case Operation.Mul:
                    return ((DecomposedVector)vector1) * ((DecomposedVector)vector2);
                default:
                    return ((DecomposedVector)vector1) / ((DecomposedVector)vector2);
            }
        }
        private static Vector Do(Operation operation, Vector vector, double value)
        {
            switch (operation)
            {
                case Operation.Sum:
                    vector.EndPoint += value;
                    break;
                case Operation.Sub:
                    vector.EndPoint -= value;
                    break;
                case Operation.Mul:
                    vector.EndPoint *= value;
                    break;
                default:
                    vector.EndPoint /= value;
                    break;
            }

            return vector;
        }
    }
}