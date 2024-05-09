using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    public interface IBodyMover
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public void Call();
    }
}
