using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    /// <summary>
    /// Интерфейс для расчета сил, действующих на тела в системе N-тел.
    /// </summary>
    public interface IForceCalculator
    {
     /// <summary>
     /// Границы множества, в котором будет работать класс.
     /// </summary>
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        /// <summary>
        /// Вызов метода для расчёта сил.
        /// </summary>
        public void Calculate();
    }
}
