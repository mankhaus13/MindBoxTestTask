using MindBoxTestTask.FiguresLibrary.Factories;
using MindBoxTestTask.FiguresLibrary.Figures;
using MindBoxTestTask.FiguresLibrary.Interfaces;
using Xunit;

namespace MindBoxTestTask.FiguresLibraryTests.FigureFactoryTests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(1.0, 2.0, 3.0)]
        [InlineData(4.0, 8.0, 20.0)]
        [InlineData(9.0, 11.0, 19.0)]
        public void Create_Triangle_ShouldReturnTriangle(double sideA, double sideB, double sideC)
        {
            IFigure figure = FigureFactory.CreateFigure("triangle", sideA, sideB, sideC);

            Assert.NotNull(figure);
            Assert.IsType<Triangle>(figure);

            Triangle triangle = (Triangle)figure;
            Assert.Equal(sideA, triangle.SideA);
            Assert.Equal(sideB, triangle.SideB);
            Assert.Equal(sideC, triangle.SideC);
        }

        [Theory]
        [InlineData(-1.0, 2.0, 3.0)]
        [InlineData(-1.0, -2.0, -3.0)]
        public void Create_TriangleNotPositiveSides_ShouldThrowArgumentException(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => FigureFactory.CreateFigure("triangle", sideA, sideB, sideC));
        }
    }
}
