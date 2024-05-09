using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    public interface IPhysics
    {

        private const double G = 6.67e-11;
        public abstract static IMyPoint GetDv(IBody body, double dt); // dv = F / m * dt
        public abstract static IMyPoint GetDp(IBody body, double dt, IMyPoint dv); // dp = (v + dv / 2) * dt
        public abstract static double GetGravityMagnitude(double m1, double m2, double r);
        public abstract static IMyPoint GetDirection(IBody curr, IBody other);
        public abstract static double GetDistance(IBody curr, IBody other);
    }
}
