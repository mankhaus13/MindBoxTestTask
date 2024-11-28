using MindBoxTestTask.FiguresLibrary.Interfaces;
using MindBoxTestTask.FiguresLibrary.MathToolbox;

namespace MindBoxTestTask.FiguresLibrary.Figures
{
    public class Triangle : IFigure
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        public Triangle(double _sideA, double _sideB, double _sideC)
        {
            if (!IsValid(_sideA, _sideB, _sideC))
                throw new ArgumentException();

            SideA = _sideA;
            SideB = _sideB;
            SideC = _sideC;
        }

        public double CalculateArea()
        {
            double s = (SideA + SideB + SideC) / 2.0;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }

        public bool IsRightTriangle()
        {
            double a = SideA * SideA;
            double b = SideB * SideB;
            double c = SideC * SideC;

            return MathUtils.AreEqual(a + b, c) ||
                   MathUtils.AreEqual(a + c, b) ||
                   MathUtils.AreEqual(b + c, a);
        }

        private static bool IsValid(double a, double b, double c)
        {
            return a + b > c
                && a + c > b
                && b + c > a;
        }
    }
}
