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
        randomMax = 500;
    }

    public Point[] GenerateBodies()
    {
        Point[] bodiesCoord = new Point[n];

        for (int i = 0; i < bodiesCoord.Length; i++)
        {
            int x = random.Next(randomMin, randomMax);
            int y = random.Next(randomMin, randomMax);
            bodiesCoord[i] = new Point(x, y);
        }

        return bodiesCoord;
    }

}

public interface IBodyGenerator
{
    Point[] GenerateBodies();
}