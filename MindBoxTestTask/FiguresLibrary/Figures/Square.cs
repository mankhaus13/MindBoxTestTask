using MindBoxTestTask.FiguresLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindBoxTestTask.FiguresLibrary.Figures
{
    public class Square : IFigure
    {
        public double Side { get; }
        public Square(double side)
        {
            if (side <= 0)
                throw new ArgumentException();

            Side = side;
        }

        public double CalculateArea()
        {
            return Side * Side;
        }
    }
}
