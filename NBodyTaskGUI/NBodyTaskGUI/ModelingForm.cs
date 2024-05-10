using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NBodyTaskGUI
{
    public partial class ModelingForm : Form
    {
        private object solverInstance;
        private object settingsInstance;
        private object generatorInstance;

        private CancellationTokenSource cts;

        private Assembly realizationAssembly;
        private Type solverType;
        private Type settingsType;
        private Type generatorType;

        int bodiesCount;
        double bodyMass;
        int deltaTime;
        int threadsNum;

        public ModelingForm(Assembly realizationAssembly, int bodiesCount, double bodyMass, int deltaTime, int threadsNum)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.realizationAssembly = realizationAssembly;
            this.bodiesCount = bodiesCount;
            this.bodyMass = bodyMass;
            this.deltaTime = deltaTime;
            this.threadsNum = threadsNum;
            this.WindowState = FormWindowState.Maximized;

            // Инициализация типов
            InitializeTypes();
            CreateAllInstances();
            this.FormClosing += new FormClosingEventHandler(Form2_FormClosing);
            

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            StartModelingAsync(cts.Token);
        }


        private void InitializeTypes()
        {
            solverType = realizationAssembly.GetType("NBodyTaskRealisation.NBodySolver");
            settingsType = realizationAssembly.GetType("NBodyTaskRealisation.NBodySettings");
            generatorType = realizationAssembly.GetType("NBodyTaskRealisation.BodiesCoordGenerator");
        }

        private async Task StartModelingAsync(CancellationToken ct)
        {


            for (; ; )
            {

                if (ct.IsCancellationRequested)
                {
                    // Операция была отменена
                    break;
                }

                MethodInfo methodInfo = solverType.GetMethod("CalculateBodiesCoords");
                methodInfo.Invoke(solverInstance, null);

                await Task.Run(() =>
                {
                    panel1.Invoke((System.Windows.Forms.MethodInvoker)delegate
                    {
                        panel1.Invalidate();
                    });
                });
                await Task.Delay(500);
            }
        }

        private void CreateAllInstances()
        {
            settingsInstance = Activator.CreateInstance(settingsType, new object[] { bodyMass, deltaTime, 1, threadsNum });
            generatorInstance = Activator.CreateInstance(generatorType, new object[] { bodiesCount, panel1.Width, panel1.Height });
            MethodInfo generateBodiesMethod = generatorType.GetMethod("GenerateBodies");
            object bodiesCoords = generateBodiesMethod.Invoke(generatorInstance, null);
            solverInstance = Activator.CreateInstance(solverType, new object[] { bodiesCoords, settingsInstance });
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (solverInstance != null)
            {
                MethodInfo methodInfo1 = solverType.GetMethod("GetBodies");
                object bodies = methodInfo1.Invoke(solverInstance, null);

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

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }

            // Создаем новый экземпляр Form1 и показываем его
            DataInputForm form1 = new DataInputForm(realizationAssembly);
            form1.Show();

            // Закрываем текущую форму (Form2)
            this.Close();
        }

    }

}
