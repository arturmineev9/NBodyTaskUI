using NBody;

namespace NBodyTaskRealisation;

using NBodyTaskContract;

using System.Threading.Tasks;

// ����� ��� ������� ������ N-���.
public class NBodySolver : INBodySolver
{
    // ������ ���, ����������� � ���������.
    private static Body[]? _bodies;
    // ��������� ��� ��� ������� ����� ���������.
    private static int _dt;
    // ���������� ������ ���������� ��� ���������.
    private static double _errorDistance;

    // ������� ��� �������� ����������� ForceCalculator � BodyMover.
    private readonly ForceCalculator[] _forceCalculators;
    private readonly BodyMover[] _bodyMovers;

    // ������� ����� ��� ������� ��� � ����������� ���.
    private readonly Task[] _forceCalculatingTasks;
    private readonly Task[] _movingTasks;
    // ������� ����� ��� �������� ����� �����.
    private readonly TaskFactory _taskFactory;

    // ����������� ������ NBodySolver.
    public NBodySolver(MyPoint[] bodiesCoords, NBodySettings settings)
    {
        // ������������� ������� ���.
        _bodies = new Body[bodiesCoords.Length];
        for (int i = 0; i < _bodies.Length; i++)
        {
            _bodies[i] = new Body(bodiesCoords[i], settings.BodyMass);
        }

        // ��������� ���������� ���� � ���������� ������ ����������.
        _dt = settings.DeltaTime;
        _errorDistance = settings.ErrorDistance;

        // ������������� ��� �� �������
        int[][] recalcingRanges = Helpers.GetRanges(0, _bodies.Length - 2, settings.ThreadsNum);
        int[][] movingRanges = Helpers.GetRanges(1, _bodies.Length, settings.ThreadsNum);

        // ������������� �������� _forceCalculators � _bodyMovers.
        _forceCalculators = new ForceCalculator[recalcingRanges.Length];
        _bodyMovers = new BodyMover[movingRanges.Length];

        for (int i = 0; i < recalcingRanges.Length; i++)
        {
            _forceCalculators[i] = new ForceCalculator(recalcingRanges[i][0], recalcingRanges[i][1]);
            _bodyMovers[i] = new BodyMover(movingRanges[i][0], movingRanges[i][1]);
        }

        // ������������� ������� ����� � �������� �����.
        _taskFactory = new TaskFactory();
        _forceCalculatingTasks = new Task[settings.ThreadsNum];
        _movingTasks = new Task[settings.ThreadsNum];
    }

    // ����� ��� ��������� ������� ���.
    public IBody[] GetBodies()
    {
        return _bodies;
    }

    // ����� ��� ���������� ��������� ���.
    public void CalculateBodiesCoords()
    {
        RecalculateBodiesForces();
        MoveNBodies();
    }

    // ����� ��� ��������� ���, ����������� �� ����.
    public void RecalculateBodiesForces()
    {
        for (int i = 0; i < _forceCalculators.Length; i++)
        {
            _forceCalculatingTasks[i] = _taskFactory.StartNew(_forceCalculators[i].Calculate);
        }

        Task.WaitAll(_forceCalculatingTasks);
    }

    // ����� ��� ����������� ���.
    public void MoveNBodies()
    {
        for (int i = 0; i < _bodyMovers.Length; i++)
        {
            _movingTasks[i] = _taskFactory.StartNew(_bodyMovers[i].Move);
        }

        Task.WaitAll(_movingTasks);
    }

    // ��������� ����� ��� ������� ���.
    private class ForceCalculator : IForceCalculator
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public ForceCalculator(int leftIndex, int rightIndex)
        {
            this.LeftIndex = leftIndex;
            this.RightIndex = rightIndex;
        }

        // ����� ��� ������� ���.
        public void Calculate()
        {
            double distance;
            double magnitude;
            MyPoint direction;
            for (int i = LeftIndex; i <= RightIndex; i++)
            {
                for (int j = i + 1; j < _bodies.Length; j++)
                {
                    distance = Physics.GetDistance(_bodies[i], _bodies[j]);
                    if (!double.IsNaN(distance))
                    {
                        magnitude = distance < _errorDistance ? 0.0 : Physics.GetGravityMagnitude(_bodies[i].Mass, _bodies[j].Mass, distance);
                        direction = (MyPoint)Physics.GetDirection(_bodies[i], _bodies[j]);

                        _bodies[i].Force.X += magnitude * direction.X / distance;
                        _bodies[i].Force.Y += magnitude * direction.Y / distance;

                        lock (this)
                        {
                            _bodies[j].Force.X -= magnitude * direction.X / distance;
                            _bodies[j].Force.Y -= magnitude * direction.Y / distance;
                        }
                    }
                }
            }
        }
    }

    // ��������� ����� ��� ����������� ���.
    private class BodyMover : IBodyMover
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public BodyMover(int rangeStart, int rangeEnd)
        {
            LeftIndex = rangeStart - 1;
            RightIndex = rangeEnd - 1;
        }

        // ����� ��� ����������� ���.
        public void Move()
        {
            MyPoint deltaV; // dv = F / m * dt
            MyPoint deltaP; // dp = (v + dv / 2) * dt

            for (int i = LeftIndex; i <= RightIndex; i++)
            {
                Body current = _bodies[i];

                // ���������� ��������� ��������
                deltaV = (MyPoint)Physics.GetDv(current, _dt);

                // ���������� ��������� �������
                deltaP = (MyPoint)Physics.GetDp(current, _dt, (IMyPoint)deltaV);

                // ���������� �������� � �������
                current.Velocity.X += deltaV.X;
                current.Velocity.Y += deltaV.Y;
                current.Position.X += deltaP.X;
                current.Position.Y += deltaP.Y;

                // ����� ����
                current.Force.X = current.Force.Y = 0.0;
            }
        }

    }
}
