using MindBoxTestTask.FiguresLibrary.Interfaces;

namespace MindBoxTestTask.FiguresLibrary.Figures
{
    public class Circle : IFigure
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException();
            Radius = radius;
        }

        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
