using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTask
{
    internal class BodiesAcceptableParams
    {
        public static readonly int minBodiesNum = 1;
        public static readonly int maxBodiesNum = 1024;

        public static readonly double minBodyMass = 1e3;
        public static readonly double maxBodyMass = 9e14;

        public static readonly int MIN_DELTA_TIME = 16;
        public static readonly int MAX_DELTA_TIME = 1_000;

    }
}
