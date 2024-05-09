using NBodyTaskContract;
using NBodyTaskRealisation;

namespace NBody;

public class Body : IBody
{
    public IMyPoint Position { get; set; }
    public IMyPoint Velocity { get; set; }
    public IMyPoint Force { get; set; }
    public double Mass { get; set; }

    public Body(MyPoint position, double mass)
    {
        Position = (IMyPoint) new MyPoint(position.X, position.Y);
        Velocity = (IMyPoint) new MyPoint(0.0, 0.0);
        Force = (IMyPoint) new MyPoint(0.0, 0.0);
        Mass = mass;
    }
}