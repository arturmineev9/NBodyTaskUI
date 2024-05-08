using NBody;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using Timer = System.Windows.Forms.Timer;

namespace NBodyTask
{
    public partial class Form1 : Form
    {

        static Body[] _bodies;
        private NBodySolver solver;
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            btnStart.Click += button1_Click;
            timer = new Timer();
            timer.Interval = 100; // Обновляем каждые 100 мс
            timer.Tick += Timer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*int bodiesCount = int.Parse(tbBodiesCount.Text);
            double bodyMass = double.Parse(tbBodyMass.Text);
            double deltaTime = int.Parse(tbDeltaTime.Text);
            int threadsNum = int.Parse(tbThreadsNum.Text);*/

            int bodiesCount = 10;
            double bodyMass = 1000;
            int deltaTime = 1;
            int threadsNum = 2;

            NBodySettings settings = new NBodySettings(bodyMass, deltaTime, 0.01, threadsNum);

            BodiesCoordGenerator generator = new BodiesCoordGenerator(bodiesCount);
            NBody.Point[] bodiesCoords = generator.GenerateBodies();
            solver = new NBodySolver(bodiesCoords, settings);

            timer.Start();

        }

        /*private void DrawBody(Body body)
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                // Преобразование координат тела в координаты панели
                int x = (int)(body.Position.x);
                int y = (int)(body.Position.y);

                // Рисование тела
                g.FillEllipse(Brushes.Red, x, y, 10, 10);
            }
        }*/

        /*protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (_bodies != null)
            {
                foreach (Body body in _bodies)
                {
                    // Преобразование координат тела в координаты на форме
                    int x = (int)(body.Position.x * this.Width);
                    int y = (int)(body.Position.y * this.Height);

                    // Рисование точки на форме
                    e.Graphics.FillEllipse(Brushes.Black, x, y, 50, 50);
                }
            }
        }*/
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Вычисляем новые координаты тел
            solver.CalculateBodiesCoords();

            // Перерисовываем панель
            panel.Invalidate();
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
