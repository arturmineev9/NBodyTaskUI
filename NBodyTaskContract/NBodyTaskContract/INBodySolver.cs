using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBodyTaskContract
{
    public interface INBodySolver
    {
        private static IBody[]? _bodies;
        private static int _dt;
        private static double _errorDistance;

        /*private readonly IForceCalculator[] _recalcingCallables;
        private readonly IBodyMover[] _movingCallables;
        private Task[] _forceCalculatingTasks;
        private Task[] _movingTasks;
        private TaskFactory _taskFactory;*/

        public IBody[] GetBodies();
        public void CalculateBodiesCoords();
        public void RecalculateBodiesForces();
        public void MoveNBodies();
    }
}
