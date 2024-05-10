using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    public interface INBodySolver
    {
        /// <summary>
        /// Массив тел, участвующих в симуляции.
        /// </summary>
        private static IBody[]? _bodies;

        /// <summary>
        /// Временной шаг для каждого цикла симуляции.
        /// </summary>
        private static int _dt;

        /// <summary>
        /// Допустимая ошибка расстояния для симуляции.
        /// </summary>
        private static double _errorDistance;

        /// <summary>
        /// Возвращает массив тел, участвующих в симуляции.
        /// </summary>
        public IBody[] GetBodies();

        /// <summary>
        /// Вычисляет координаты тел на следующем временном шаге.
        /// </summary>
        public void CalculateBodiesCoords();

        /// <summary>
        /// Пересчитывает силы, действующие на каждое тело.
        /// </summary>
        public void RecalculateBodiesForces();

        /// <summary>
        /// Перемещает тела на основе вычисленных сил.
        /// </summary>
        public void MoveNBodies();
    }

}
