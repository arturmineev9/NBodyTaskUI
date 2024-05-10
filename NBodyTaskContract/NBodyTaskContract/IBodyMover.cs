using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    /// <summary>
    /// Интерфейс для перемещения тел в системе N-тел.
    /// </summary>
    public interface IBodyMover
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public void Move();
    }
}
