using NBodyTaskContract;
using System.Collections;
using System.Diagnostics;
using System.Reflection;

namespace NBodyTaskGUI
{
    public partial class Form1 : Form
    {
        //static object _bodies;
        private object solver;
        private object settingsInstance;
        private object generatorInstance;
        private object acceptableParamsInstance;

        Assembly realizationAssembly;
        Type solverType;
        Type settingsType;
        Type generatorType;
        Type paramsType;
        public Form1(Assembly realizationAssembly)
        {
            InitializeComponent();
            this.realizationAssembly = realizationAssembly;
            InitializeDllComponent();
            this.DoubleBuffered = true;
            btnStart.Click += button1_Click;
            this.WindowState = FormWindowState.Maximized;

            this.Padding = new Padding(left: 200, right: 10, top: 20, bottom: 20); 

            
            panel.Dock = DockStyle.Fill;
            //timer = new Timer();
            //timer.Interval = 1000; 
            //timer.Tick += Timer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!IsCorrectNum(tbBodiesCount.Text, (int)paramsType.GetField("minBodiesNum").GetValue(null), (int)paramsType.GetField("maxBodiesNum").GetValue(null)))
            {
                MessageBox.Show("Ошибка в поле \"Количество тел\".\nВведите значение от 1 до 1000.");
                return;
            }

            int bodiesCount = int.Parse(tbBodiesCount.Text);

            if (!IsCorrectNum(tbBodyMass.Text, (double)paramsType.GetField("minBodyMass").GetValue(null), (double)paramsType.GetField("maxBodyMass").GetValue(null)))
            {
                MessageBox.Show("Ошибка в поле \"Масса тел\".\nВведите значение от 1e3 до 9e14.");
                return;
            }

            double bodyMass = double.Parse(tbBodyMass.Text);

            if (!IsCorrectNum(tbDeltaTime.Text, (int)paramsType.GetField("minDeltaTime").GetValue(null), (int)paramsType.GetField("maxDeltaTime").GetValue(null)))
            {
                MessageBox.Show("Ошибка в поле \"Дельта-T\".\nВведите значение от 16 до 1000.");
                return;
            }

            int deltaTime = int.Parse(tbDeltaTime.Text);

            if (!IsCorrectNum(tbThreadsNum.Text, (int)paramsType.GetField("minThreadsNum").GetValue(null), (int)paramsType.GetField("maxThreadsNum").GetValue(null)))
            {
                MessageBox.Show("Ошибка в поле \"Количество потоков\".\nВведите значение от 1 до 128.");
                return;
            }

            int threadsNum = int.Parse(tbThreadsNum.Text);


            //int bodiesCount = 1000;
            //double bodyMass = 1e10;
            //int deltaTime = 20;
            //threadsNum = 100;
            //NBodySettings settings = new NBodySettings(bodyMass, deltaTime, 0.01, threadsNum);

            settingsInstance = Activator.CreateInstance(settingsType, new object[] { bodyMass, deltaTime, 0.01, threadsNum });

            //BodiesCoordGenerator generator = new BodiesCoordGenerator(bodiesCount, panel.Width, panel.Height);
            generatorInstance = Activator.CreateInstance(generatorType, new object[] { bodiesCount, panel.Width, panel.Height });
            MethodInfo generateBodiesMethod = generatorType.GetMethod("GenerateBodies");
            
            object bodiesCoords = generateBodiesMethod.Invoke(generatorInstance, null);
            //solver = new NBodySolver(bodiesCoords, settings);
            solver = Activator.CreateInstance(solverType, new object[] { bodiesCoords, settingsInstance });

            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000000000; i += (int)settingsType.GetField("DeltaTime").GetValue(settingsInstance))
            {
                //solver.CalculateBodiesCoords();
                MethodInfo methodInfo = solverType.GetMethod("CalculateBodiesCoords");
                methodInfo.Invoke(solver, null);
                //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Reset();
                //Body[] b = solver.GetBodies();
                //MessageBox.Show($"{b[0].Position.x}, {b[0].Position.y}");

                
                await Task.Run(() =>
                {
                    panel.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        panel.Invalidate();
                    });
                });
                await Task.Delay(500);
            }
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (solver != null)
            {
                MethodInfo methodInfo1 = solverType.GetMethod("GetBodies");
                object bodies = methodInfo1.Invoke(solver, null);

                foreach (var body in (IEnumerable)bodies)
                {
                    Type bodyType = body.GetType();
                    PropertyInfo positionProperty = bodyType.GetProperty("Position");
                    object position = positionProperty.GetValue(body, null);

                    Type positionType = position.GetType();
                    PropertyInfo xProperty = positionType.GetProperty("X");
                    PropertyInfo yProperty = positionType.GetProperty("Y");

                    float x = (float)(double)xProperty.GetValue(position, null);
                    float y = (float)(double)yProperty.GetValue(position, null);

                    e.Graphics.FillEllipse(Brushes.Red, x, y, 10, 10);
                }
            }
        }



        public bool IsCorrectNum(string strNum, double minNum, double maxNum)
        {
            double number;
            if (double.TryParse(strNum, out number))
            {
                if (number >= minNum && number <= maxNum)
                {
                    return true;
                }
            }
            return false;
        }

        private void InitializeDllComponent()
        {
            
         
            //Assembly.LoadFile(@"D:\CSProjects\8QueensContract\8QueensContracts\obj\Debug\net8.0\8QueensContracts.dll");
            solverType = realizationAssembly.GetType("NBodyTaskRealisation.NBodySolver");
            settingsType = realizationAssembly.GetType("NBodyTaskRealisation.NBodySettings");
            generatorType = realizationAssembly.GetType("NBodyTaskRealisation.BodiesCoordGenerator");
            paramsType = realizationAssembly.GetType("NBodyTaskRealisation.BodiesAcceptableParams");
        }

        private bool CheckComplianceContract()
        {
            var interfaces = new Type[6];
            interfaces[0] = typeof(IBody); interfaces[1] = typeof(IBodyMover);
            interfaces[2] = typeof(IForceCalculator); interfaces[3] = typeof(IMyPoint);
            interfaces[4] = typeof(INBodySolver); interfaces[5] = typeof(IPhysics);
            
            var types = realizationAssembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && !t.IsSealed);

            foreach (var interfaceType in interfaces)
            {
                bool isImplemented = types.Any(t => interfaceType.IsAssignableFrom(t));

                if (!isImplemented)
                {
                    MessageBox.Show("????????? ???????????? ??????.", $"???????? {interfaceType.Name} ?? ??????????.");
                    return false;
                }
            }

            return true;
        }
    }
}
