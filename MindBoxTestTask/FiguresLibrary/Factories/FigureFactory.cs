using MindBoxTestTask.FiguresLibrary.Figures;
using MindBoxTestTask.FiguresLibrary.Interfaces;

namespace MindBoxTestTask.FiguresLibrary.Factories
{
    public class FigureFactory
    {
        private static readonly Dictionary<string, Func<double[], IFigure>> _registryDict = new();

        static FigureFactory()
        {
           FigureRegister("circle",
                parametersFigure =>
                    new Circle(parametersFigure[0]));

            FigureRegister("triangle",
                parametersFigure =>
                    new Triangle(parametersFigure[0], parametersFigure[1], parametersFigure[2]));
        }

        public static void FigureRegister(string figure, Func<double[], IFigure> creatorFigure)
        {
            _registryDict[figure.ToLower()] = creatorFigure;
        }

        public static IFigure CreateFigure(string figure, params double[] parametersFigure)
        {
            if (_registryDict.TryGetValue(figure.ToLower(), out var creatorFigure))
            {
                return creatorFigure(parametersFigure);
            }

            throw new ArgumentException();
        }
    }
}
