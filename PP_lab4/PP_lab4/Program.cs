using System;

// Батьківський клас Фігура
class Figure
{
    // Віртуальний метод для задання координат вершин
    public virtual void SetVertices(double[] x, double[] y)
    {
        Console.WriteLine("Setting vertices for generic figure...");
    }

    // Віртуальний метод для виведення координат вершин на екран
    public virtual void PrintVertices()
    {
        Console.WriteLine("Printing vertices for generic figure...");
    }

    // Віртуальний метод для обчислення площі фігури
    public virtual double CalculateArea()
    {
        Console.WriteLine("Calculating area for generic figure...");
        return 0;
    }
}

// Похідний клас Трикутник
class Triangle : Figure
{
    private double[] x = new double[3];
    private double[] y = new double[3];

    public override void SetVertices(double[] x, double[] y)
    {
        if (x.Length != 3 || y.Length != 3)
        {
            Console.WriteLine("Error: Invalid number of vertices for triangle.");
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            this.x[i] = x[i];
            this.y[i] = y[i];
        }
    }

    public override void PrintVertices()
    {
        Console.WriteLine("Triangle vertices:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Vertex {0}: ({1}, {2})", i + 1, x[i], y[i]);
        }
    }

    public override double CalculateArea()
    {
        double area = Math.Abs((x[0] * (y[1] - y[2]) + x[1] * (y[2] - y[0]) + x[2] * (y[0] - y[1])) / 2);
        Console.WriteLine("Area of triangle: {0}", area);
        return area;
    }
}

// Похідний клас Опуклий чотирикутник
class ConvexQuadrilateral : Figure
{
    private double[] x = new double[4];
    private double[] y = new double[4];

    public override void SetVertices(double[] x, double[] y)
    {
        if (x.Length != 4 || y.Length != 4)
        {
            Console.WriteLine("Error: Invalid number of vertices for convex quadrilateral.");
            return;
        }

        for (int i = 0; i < 4; i++)
        {
            this.x[i] = x[i];
            this.y[i] = y[i];
        }
    }

    public override void PrintVertices()
    {
        Console.WriteLine("Convex quadrilateral vertices:");
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine("Vertex {0}: ({1}, {2})", i + 1, x[i], y[i]);
        }
    }

    public override double CalculateArea()
    {
        double area1 = Math.Abs((x[0] * (y[1] - y[2]) + x[1] * (y[2] - y[0]) + x[2] * (y[0] - y[1])) / 2);
        double area2 = Math.Abs((x[2] * (y[3] - y[0]) + x[3] * (y[0] - y[1]) + x[0] * (y[1] - y[2])) / 2);
        double totalArea = area1 + area2;
        Console.WriteLine("Area of convex quadrilateral: {0}", totalArea);
        return totalArea;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();

        Figure[] figures = new Figure[2];
        int choice = rnd.Next(0, 2);

        if (choice == 0)
        {
            figures[0] = new Triangle();
            double[] x = { 0, 3, 0 };
            double[] y = { 0, 0, 4 };
            figures[0].SetVertices(x, y);
        }
        else
        {
            figures[1] = new ConvexQuadrilateral();
            double[] x = { 0, 4, 4, 0 };
            double[] y = { 0, 0, 3, 3 };
            figures[1].SetVertices(x, y);
        }

        foreach (Figure figure in figures)
        {
            if (figure != null)
            {
                figure.PrintVertices();
                figure.CalculateArea();
                Console.WriteLine();
            }
        }
    }
}