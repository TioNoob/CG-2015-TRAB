using CosmicSimulatorModel.Enums;

namespace CosmicSimulatorModel.Primitives.Models
{
    public class DecomposedVector
    {
        public MyPoint CentralPoint { get; set; }

        private MyPoint _HorizontalPoint;
        private MyPoint _VerticalPoint;

        public MyPoint HorizontalPoint
        {
            get
            {
                return _HorizontalPoint;
            }
            set
            {
                _HorizontalPoint = value;
            }
        }

        public MyPoint VerticalPoint
        {
            get
            {
                return _VerticalPoint;
            }
            set
            {
                _VerticalPoint = value;
            }
        }

        public DecomposedVector(MyPoint initialPoint, MyPoint endPoint)
        {
            CentralPoint = initialPoint;
            DecomposeVector(initialPoint, endPoint, out _HorizontalPoint, out _VerticalPoint);
        }

        public DecomposedVector(MyPoint centralPoint, MyPoint horizontalPoint, MyPoint verticalPoint)
        {
            this.CentralPoint = centralPoint;

            this.HorizontalPoint = horizontalPoint;
            this.VerticalPoint = verticalPoint;
        }

        public void DecomposeVector(MyPoint initialPoint, MyPoint endPoint, out MyPoint horizontalPoint, out MyPoint verticalPoint)
        {
            double X1;
            double Y1;

            double X2;
            double Y2;

            X1 = endPoint.X;
            Y1 = initialPoint.Y;

            X2 = initialPoint.X;
            Y2 = endPoint.Y;

            horizontalPoint = new MyPoint(X1, Y1);
            verticalPoint = new MyPoint(X2, Y2);
        }

        public static DecomposedVector operator +(DecomposedVector vector1, DecomposedVector vector2)
        {
            return Do(Operation.Sum, vector1, vector2);
        }
        public static DecomposedVector operator -(DecomposedVector vector1, DecomposedVector vector2)
        {
            return Do(Operation.Sub, vector1, vector2);
        }
        public static DecomposedVector operator *(DecomposedVector vector1, DecomposedVector vector2)
        {
            return Do(Operation.Mul, vector1, vector2);
        }
        public static DecomposedVector operator /(DecomposedVector vector1, DecomposedVector vector2)
        {
            return Do(Operation.Div, vector1, vector2);
        }

        private static DecomposedVector Do(Operation operation, DecomposedVector vector1, DecomposedVector vector2)
        {
            MyPoint centralPoint;

            MyPoint horizontalPoint;
            MyPoint verticalPoint;

            switch (operation)
            {
                case Operation.Sum:
                    centralPoint = vector1.CentralPoint + vector2.CentralPoint;
                    horizontalPoint = vector1.HorizontalPoint + vector2.HorizontalPoint;
                    verticalPoint = vector1.VerticalPoint + vector2.VerticalPoint;
                    break;

                case Operation.Sub:
                    centralPoint = vector1.CentralPoint - vector2.CentralPoint;
                    horizontalPoint = vector1.HorizontalPoint - vector2.HorizontalPoint;
                    verticalPoint = vector1.VerticalPoint - vector2.VerticalPoint;
                    break;

                case Operation.Mul:
                    centralPoint = vector1.CentralPoint * vector2.CentralPoint;
                    horizontalPoint = vector1.HorizontalPoint * vector2.HorizontalPoint;
                    verticalPoint = vector1.VerticalPoint * vector2.VerticalPoint;
                    break;

                default:
                    centralPoint = vector1.CentralPoint / vector2.CentralPoint;
                    horizontalPoint = vector1.HorizontalPoint / vector2.HorizontalPoint;
                    verticalPoint = vector1.VerticalPoint / vector2.VerticalPoint;
                    break;
            }

            return new DecomposedVector(centralPoint, horizontalPoint, verticalPoint);
        }
    }
}