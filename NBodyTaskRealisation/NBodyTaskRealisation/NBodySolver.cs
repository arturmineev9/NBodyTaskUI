using NBody;

namespace NBodyTaskRealisation;

using NBodyTaskContract;

using System.Threading.Tasks;

// Класс для решения задачи N-тел.
public class NBodySolver : INBodySolver
{
    // Массив тел, участвующих в симуляции.
    private static Body[]? _bodies;
    // Временной шаг для каждого цикла симуляции.
    private static int _dt;
    // Допустимая ошибка расстояния для симуляции.
    private static double _errorDistance;

    // Массивы для хранения экземпляров ForceCalculator и BodyMover.
    private readonly ForceCalculator[] _forceCalculators;
    private readonly BodyMover[] _bodyMovers;

    // Массивы задач для расчета сил и перемещения тел.
    private readonly Task[] _forceCalculatingTasks;
    private readonly Task[] _movingTasks;
    // Фабрика задач для создания новых задач.
    private readonly TaskFactory _taskFactory;

    // Конструктор класса NBodySolver.
    public NBodySolver(MyPoint[] bodiesCoords, NBodySettings settings)
    {
        // Инициализация массива тел.
        _bodies = new Body[bodiesCoords.Length];
        for (int i = 0; i < _bodies.Length; i++)
        {
            _bodies[i] = new Body(bodiesCoords[i], settings.BodyMass);
        }

        // Установка временного шага и допустимой ошибки расстояния.
        _dt = settings.DeltaTime;
        _errorDistance = settings.ErrorDistance;

        // Распределение тел по потокам
        int[][] recalcingRanges = Helpers.GetRanges(0, _bodies.Length - 2, settings.ThreadsNum);
        int[][] movingRanges = Helpers.GetRanges(1, _bodies.Length, settings.ThreadsNum);

        // Инициализация массивов _forceCalculators и _bodyMovers.
        _forceCalculators = new ForceCalculator[recalcingRanges.Length];
        _bodyMovers = new BodyMover[movingRanges.Length];

        for (int i = 0; i < recalcingRanges.Length; i++)
        {
            _forceCalculators[i] = new ForceCalculator(recalcingRanges[i][0], recalcingRanges[i][1]);
            _bodyMovers[i] = new BodyMover(movingRanges[i][0], movingRanges[i][1]);
        }

        // Инициализация фабрики задач и массивов задач.
        _taskFactory = new TaskFactory();
        _forceCalculatingTasks = new Task[settings.ThreadsNum];
        _movingTasks = new Task[settings.ThreadsNum];
    }

    // Метод для получения массива тел.
    public IBody[] GetBodies()
    {
        return _bodies;
    }

    // Метод для вычисления координат тел.
    public void CalculateBodiesCoords()
    {
        RecalculateBodiesForces();
        MoveNBodies();
    }

    // Метод для пересчета сил, действующих на тела.
    public void RecalculateBodiesForces()
    {
        for (int i = 0; i < _forceCalculators.Length; i++)
        {
            _forceCalculatingTasks[i] = _taskFactory.StartNew(_forceCalculators[i].Calculate);
        }

        Task.WaitAll(_forceCalculatingTasks);
    }

    // Метод для перемещения тел.
    public void MoveNBodies()
    {
        for (int i = 0; i < _bodyMovers.Length; i++)
        {
            _movingTasks[i] = _taskFactory.StartNew(_bodyMovers[i].Move);
        }

        Task.WaitAll(_movingTasks);
    }

    // Вложенный класс для расчета сил.
    private class ForceCalculator : IForceCalculator
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public ForceCalculator(int leftIndex, int rightIndex)
        {
            this.LeftIndex = leftIndex;
            this.RightIndex = rightIndex;
        }

        // Метод для расчета сил.
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

    // Вложенный класс для перемещения тел.
    private class BodyMover : IBodyMover
    {
        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public BodyMover(int rangeStart, int rangeEnd)
        {
            LeftIndex = rangeStart - 1;
            RightIndex = rangeEnd - 1;
        }

        // Метод для перемещения тел.
        public void Move()
        {
            MyPoint deltaV; // dv = F / m * dt
            MyPoint deltaP; // dp = (v + dv / 2) * dt

            for (int i = LeftIndex; i <= RightIndex; i++)
            {
                Body current = _bodies[i];

                // Вычисление изменения скорости
                deltaV = (MyPoint)Physics.GetDv(current, _dt);

                // Вычисление изменения позиции
                deltaP = (MyPoint)Physics.GetDp(current, _dt, (IMyPoint)deltaV);

                // Обновление скорости и позиции
                current.Velocity.X += deltaV.X;
                current.Velocity.Y += deltaV.Y;
                current.Position.X += deltaP.X;
                current.Position.Y += deltaP.Y;

                // Сброс силы
                current.Force.X = current.Force.Y = 0.0;
            }
        }

    }
}
