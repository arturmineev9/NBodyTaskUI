using NBody;
using System.Diagnostics;

namespace NBodyTask
{
    public partial class Form1 : Form
    {

        static Body[] _bodies;
        private NBodySolver solver;
        public Form1()
        {
            InitializeComponent();
            //this.DoubleBuffered = true;
            btnStart.Click += button1_Click;
            this.WindowState = FormWindowState.Maximized;

            this.Padding = new Padding(left: 200, right: 10, top: 20, bottom: 20); // Здесь 10 - это размер отступа в пикселях

            // Заполните всё доступное пространство панелью
            panel.Dock = DockStyle.Fill;
            //timer = new Timer();
            //timer.Interval = 1000; // Обновляем каждые 100 мс
            //timer.Tick += Timer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            /*int bodiesCount = int.Parse(tbBodiesCount.Text);
            double bodyMass = double.Parse(tbBodyMass.Text);
            double deltaTime = int.Parse(tbDeltaTime.Text);
            int threadsNum = int.Parse(tbThreadsNum.Text);*/

            int bodiesCount = 1000;
            double bodyMass = 1e10;
            int deltaTime = 20;
            int threadsNum = 100;

            NBodySettings settings = new NBodySettings(bodyMass, deltaTime, 0.01, threadsNum);

            BodiesCoordGenerator generator = new BodiesCoordGenerator(bodiesCount, panel.Width, panel.Height);
            NBody.Point[] bodiesCoords = generator.GenerateBodies();
            solver = new NBodySolver(bodiesCoords, settings);


            Stopwatch stopwatch = new Stopwatch();
            for (int i = 0; i < 1000000000; i += settings.DeltaTime)
            {
                stopwatch.Start();
                solver.CalculateBodiesCoords();
                stopwatch.Stop();
                //MessageBox.Show(stopwatch.ElapsedMilliseconds.ToString());
                stopwatch.Reset();
                Body[] b = solver.GetBodies();
                //MessageBox.Show($"{b[0].Position.x}, {b[0].Position.y}");

                // Вызываем метод для обновления отрисовки из другого потока
                await Task.Run(() =>
                {
                    panel.Invoke((MethodInvoker)delegate
                    {
                        panel.Invalidate();
                    });
                });
                await Task.Delay(200);
            }
        }


        private void panel_Paint(object sender, PaintEventArgs e)
        {
            if (solver != null)
            {
                Body[] bodies = solver.GetBodies();
                foreach (Body body in bodies)
                {

                    e.Graphics.FillEllipse(Brushes.Red, (float)body.Position.x, (float)body.Position.y, 10, 10);
                }
            }
        }


    }
}
