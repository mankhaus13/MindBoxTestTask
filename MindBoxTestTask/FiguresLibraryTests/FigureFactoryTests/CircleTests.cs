using MindBoxTestTask.FiguresLibrary.Factories;
using MindBoxTestTask.FiguresLibrary.Figures;
using MindBoxTestTask.FiguresLibrary.Interfaces;
using Xunit;

namespace MindBoxTestTask.FiguresLibraryTests.FigureFactoryTests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(1.0)]
        [InlineData(2.0)]
        [InlineData(3.0)]
        public void Create_Circle_ShouldReturnCircle(double r)
        {
            IFigure figure = FigureFactory.CreateFigure("circle", r);

            Assert.NotNull(figure);
            Assert.IsType<Circle>(figure);
            Assert.Equal(r, ((Circle)figure).Radius);
        }
    }
}
