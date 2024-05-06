using NBody;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace NBodyTask
{
    public partial class Form1 : Form
    {

        //NBody.Point[] bodiesCoords;
        public Form1()
        {
            InitializeComponent();
            btnStart.Click += button1_Click;
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

            NBodySettings settings = new NBodySettings(bodyMass, deltaTime, 1e2, threadsNum);

            BodiesCoordGenerator generator = new BodiesCoordGenerator(bodiesCount);
            NBody.Point[] bodiesCoords = generator.GenerateBodies();

            NBodySolver solver = new NBodySolver(bodiesCoords, settings);

            for (int i = 0; i < 1000000000; i += deltaTime)
            {
                solver.CalculateBodiesCoords();
            }


        }

        /*protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (bodiesCoords != null)
            {
                foreach (NBody.Point point in bodiesCoords)
                {
                    // ѕреобразование координат тела в координаты на форме
                    double x = point.x * this.Width;
                    double y = point.y * this.Height;

                    // –исование точки на форме
                    e.Graphics.FillEllipse(Brushes.Black, (float)x, (float)y, 2, 2);
                }
            }
        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void MoveCircle(Body body, int newX, int newY)
        {
            Random random = new Random();

            body.Position.x = newX;
            body.Position.y = newY;
            this.Invalidate(); // Ёто вызовет перерисовку формы и круг переместитс€
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}
