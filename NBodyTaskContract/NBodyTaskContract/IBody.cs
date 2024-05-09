using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    public interface IBody
    {
        public IMyPoint Position { get; set; }
        public IMyPoint Velocity { get; set; }
        public IMyPoint Force { get; set; }
        public double Mass { get; set; }
    }
}
