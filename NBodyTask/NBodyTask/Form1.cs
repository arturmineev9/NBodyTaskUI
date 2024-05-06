using NBody;

namespace NBodyTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text; // —читывание значени€
            MessageBox.Show(text);
        }

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
    }
}
