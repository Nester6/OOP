using System;

struct Line
{
    public double A;
    public double B;
    public double C;

    public Line(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public void Print()
    {
        Console.WriteLine($"{A}x + {B}y + {C} = 0");
    }
}

class Program
{
    static void Main()
    {
        Line line1 = new Line(1, 2, -3);
        Line line2 = new Line(2, -1, 4);

        line1.Print();
        line2.Print();

        if (DoLinesIntersect(line1, line2))
            Console.WriteLine("Прямі перетинаються (не паралельні).");
        else
            Console.WriteLine("Прямі паралельні або збігаються.");
    }

    static bool DoLinesIntersect(Line l1, Line l2)
    {
        double d = l1.A * l2.B - l2.A * l1.B;
        return d != 0;
    }
}
