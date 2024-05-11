using NBodyTaskContract;
using NBodyTaskRealisation;
using System.Drawing;

namespace NBody;

public class Body : IBody
{
    public IMyPoint Position { get; set; }
    public IMyPoint Velocity { get; set; }
    public IMyPoint Force { get; set; }
    public double Mass { get; set; }
    public Color BodyColor { get; set; }

    private static Random rand = new Random();


    public Body(MyPoint position, double mass)
    {
        Position = (IMyPoint) new MyPoint(position.X, position.Y);
        Velocity = (IMyPoint) new MyPoint(0.0, 0.0);
        Force = (IMyPoint) new MyPoint(0.0, 0.0);
        Mass = mass;
        BodyColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
    }
}