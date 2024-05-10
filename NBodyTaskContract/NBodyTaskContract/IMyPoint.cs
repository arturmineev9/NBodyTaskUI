using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    /// <summary>
    /// Интерфейс для представления точки в двухмерном пространстве.
    /// </summary>
    public interface IMyPoint
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}
