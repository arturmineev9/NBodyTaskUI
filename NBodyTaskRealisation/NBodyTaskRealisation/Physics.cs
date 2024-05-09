using NBody;
using NBodyTaskContract;

namespace NBodyTaskRealisation;

public class Physics : IPhysics
{
    private const double G = 6.67e-11;

    public static IMyPoint GetDv(IBody body, double dt) // dv = F / m * dt
    {
        return (IMyPoint) new MyPoint(body.Force.X / body.Mass * dt, body.Force.Y / body.Mass * dt);
    }

    public static IMyPoint GetDp(IBody body, double dt, IMyPoint dv) // dp = (v + dv / 2) * dt
    {

        return (IMyPoint) new MyPoint((body.Velocity.X + dv.X / 2) * dt, (body.Velocity.Y + dv.Y / 2) * dt);
    }

    public static double GetGravityMagnitude(double m1, double m2, double r)
    {
        return G * m1 * m2 / Math.Pow(r, 2);
    }

    public static IMyPoint GetDirection(IBody curr, IBody other)
    {
        return (IMyPoint) new MyPoint(other.Position.X - curr.Position.X,
            other.Position.Y - curr.Position.Y);
    }

    public static double GetDistance(IBody curr, IBody other)
    {
        return Math.Sqrt(Math.Pow(curr.Position.X - other.Position.X, 2) +
                         Math.Pow(curr.Position.Y - other.Position.Y, 2));
    }
}