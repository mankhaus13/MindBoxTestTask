namespace MindBoxTestTask.FiguresLibrary.MathToolbox
{
    public static class MathUtils
    {
        public static bool AreEqual(double x, double y, double t = 1e-12)
        {
            return Math.Abs(x - y) < t;
        }
    }
}
