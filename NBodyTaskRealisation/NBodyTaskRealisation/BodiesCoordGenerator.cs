namespace NBodyTaskRealisation;

public class BodiesCoordGenerator : IBodyGenerator
{
    private int n;
    private Random random;
    private int width;
    private int height;

    public BodiesCoordGenerator(int n, int width, int height)
    {
        this.n = n;
        this.width = width;
        this.height = height;

        random = new Random();
    }

    public MyPoint[] GenerateBodies()
    {

        var points = new HashSet<MyPoint>();

        while (points.Count < n)
        {
            int x = random.Next(1, width); // ���������� ��������� ����� ��� x � ��������� �� 1 �� 500
            int y = random.Next(1, height); // ���������� ��������� ����� ��� y � ��������� �� 1 �� 500

            var point = new MyPoint(x, y);

            points.Add(point); // ��������� ����� � HashSet. ���� ����� ��� ����������, ��� �� ����� ���������
        }

        return points.ToArray();
    }

}

public interface IBodyGenerator
{
    MyPoint[] GenerateBodies();
}