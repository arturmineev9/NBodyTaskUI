namespace NBody;

public class BodiesCoordGenerator : IBodyGenerator
{
    private int n;


    private Random random;
    private int randomMin;
    private int randomMax;

    public BodiesCoordGenerator(int n)
    {
        this.n = n;
        //this.width = width;
        //this.height = height;

        random = new Random();
        randomMin = 0;
        randomMax = 700;
    }

    public Point[] GenerateBodies()
    {

        var points = new HashSet<Point>();

        while (points.Count < n)
        {
            int x = random.Next(1, 500); // ���������� ��������� ����� ��� x � ��������� �� 1 �� 500
            int y = random.Next(1, 500); // ���������� ��������� ����� ��� y � ��������� �� 1 �� 500

            var point = new Point(x, y);

            points.Add(point); // ��������� ����� � HashSet. ���� ����� ��� ����������, ��� �� ����� ���������
        }

        return points.ToArray();
    }

}

public interface IBodyGenerator
{
    Point[] GenerateBodies();
}