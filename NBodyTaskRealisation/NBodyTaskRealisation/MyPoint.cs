using NBodyTaskContract;

namespace NBodyTaskRealisation;

public class MyPoint(double x, double y) : IMyPoint
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

}