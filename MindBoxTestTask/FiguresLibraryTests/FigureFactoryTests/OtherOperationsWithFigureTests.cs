using MindBoxTestTask.FiguresLibrary.Factories;
using MindBoxTestTask.FiguresLibrary.Figures;
using MindBoxTestTask.FiguresLibrary.Interfaces;
using Xunit;

namespace MindBoxTestTask.FiguresLibraryTests.FigureFactoryTests
{
    public class OtherOperationsWithFigureTests
    {
        [Theory]
        [InlineData("pentagon", new double[] { 1.0, 1.0, 1.0, 1.0, 1.0 })]
        [InlineData("hexagon", new double[] { 2.0, 2.0, 2.0, 2.0, 2.0, 2.0 })]
        [InlineData("unknown", new double[] { })]
        public void Create_WithUnknownType_ShouldThrowArgumentException(string unknown, double[] parametersFigure)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FigureFactory.CreateFigure(unknown, parametersFigure);
            });
        }

        [Theory]
        [InlineData("square", new double[] { 4.0 }, typeof(Circle))]
        public void Register_NewFigureType_ShouldAllowCreation(string figure, double[] parameters, Type expectedType)
        {
            FigureFactory.FigureRegister(figure, paramArray =>
            {
                if (expectedType == typeof(Circle))
                    return new Circle(paramArray[0]);
                else if (expectedType == typeof(Triangle))
                    return new Triangle(paramArray[0], paramArray[1], paramArray[2]);
                else if (expectedType == typeof(Square))
                    return new Square(parameters[0]);
                else
                    throw new NotImplementedException();
            });

            IFigure newFigure = FigureFactory.CreateFigure(figure, parameters);

            Assert.NotNull(newFigure);
            Assert.IsType(expectedType, newFigure);
        }
    }
}
