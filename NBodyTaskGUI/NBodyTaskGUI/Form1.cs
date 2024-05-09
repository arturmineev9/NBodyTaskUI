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
            
            this.DoubleBuffered = true;
            paramsType = realizationAssembly.GetType("NBodyTaskRealisation.BodiesAcceptableParams");
            btnStart.Click += button1_Click;
            
            
            //timer = new Timer();
            //timer.Interval = 1000; 
            //timer.Tick += Timer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*if (!IsCorrectNum(tbBodiesCount.Text, (int)paramsType.GetField("minBodiesNum").GetValue(null), (int)paramsType.GetField("maxBodiesNum").GetValue(null)))
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

            int threadsNum = int.Parse(tbThreadsNum.Text);*/

            int bodiesCount = 1000;
            double bodyMass = 1e10;
            int deltaTime = 20;
            int threadsNum = 100;

            Form2 form2 = new Form2(realizationAssembly, bodiesCount, bodyMass, deltaTime, threadsNum);
            form2.Show();
            this.Hide();
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

        /*private void InitializeDllComponent()
        {
            //Assembly.LoadFile(@"D:\CSProjects\8QueensContract\8QueensContracts\obj\Debug\net8.0\8QueensContracts.dll");
            solverType = realizationAssembly.GetType("NBodyTaskRealisation.NBodySolver");
            settingsType = realizationAssembly.GetType("NBodyTaskRealisation.NBodySettings");
            generatorType = realizationAssembly.GetType("NBodyTaskRealisation.BodiesCoordGenerator");
            
        }*/
    }
}
