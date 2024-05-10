using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{

    /// <summary>
    /// Интерфейс для выполнения физических расчетов в системе N-тел.
    /// </summary>
    public interface IPhysics
    {
        /// <summary>
        /// Константа гравитационной постоянной.
        /// </summary>
        private const double G = 6.67e-11;

        /// <summary>
        /// Вычисляет изменение скорости тела на основе действующей на него силы и временного шага.
        /// </summary>
        public abstract static IMyPoint GetDv(IBody body, double dt); // dv = F / m * dt

        /// <summary>
        /// Вычисляет изменение позиции тела на основе его текущей скорости, изменения скорости и временного шага.
        /// </summary>
        public abstract static IMyPoint GetDp(IBody body, double dt, IMyPoint dv); // dp = (v + dv / 2) * dt

        /// <summary>
        /// Вычисляет величину гравитационной силы между двумя телами на основе их масс и расстояния между ними.
        /// </summary>
        public abstract static double GetGravityMagnitude(double m1, double m2, double r);

        /// <summary>
        /// Вычисляет направление от одного тела к другому.
        /// </summary>
        public abstract static IMyPoint GetDirection(IBody curr, IBody other);

        /// <summary>
        /// Вычисляет расстояние между двумя телами.
        /// </summary>
        public abstract static double GetDistance(IBody curr, IBody other);
    }

}
