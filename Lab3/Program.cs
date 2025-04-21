using System;

abstract class Pair
{
    public abstract Pair Add(Pair other);
    public abstract Pair Subtract(Pair other);
    public abstract Pair Multiply(Pair other);
    public abstract Pair Divide(Pair other);
    public abstract void Print();
}

class Fraction : Pair
{
    public int WholePart { get; set; } // Ціла частина (може бути від'ємною)
    public uint FractionalPart { get; set; } // Дробова частина (тільки додатне число)

    public Fraction(int whole, uint fractional)
    {
        WholePart = whole;
        FractionalPart = fractional;
    }

    public override Pair Add(Pair other)
    {
        if (other is Fraction f)
            return new Fraction(this.WholePart + f.WholePart, this.FractionalPart + f.FractionalPart);
        throw new ArgumentException("Invalid type for operation");
    }

    public override Pair Subtract(Pair other)
    {
        if (other is Fraction f)
            return new Fraction(this.WholePart - f.WholePart, this.FractionalPart - f.FractionalPart);
        throw new ArgumentException("Invalid type for operation");
    }

    public override Pair Multiply(Pair other)
    {
        if (other is Fraction f)
            return new Fraction(this.WholePart * f.WholePart, this.FractionalPart * f.FractionalPart);
        throw new ArgumentException("Invalid type for operation");
    }

    public override Pair Divide(Pair other)
    {
        if (other is Fraction f && f.WholePart != 0 && f.FractionalPart != 0)
            return new Fraction(this.WholePart / f.WholePart, this.FractionalPart / f.FractionalPart);
        throw new ArgumentException("Cannot divide by zero or invalid type");
    }

    public override void Print()
    {
        Console.WriteLine($"{WholePart}.{FractionalPart}");
    }
}

class FuzzyNumber : Pair
{
    public double X { get; set; }  // Центр нечіткого числа
    public double L { get; set; }  // Нижня межа
    public double R { get; set; }  // Верхня межа

    public FuzzyNumber(double x, double l, double r)
    {
        X = x;
        L = l;
        R = r;
    }

    public override Pair Add(Pair other)
    {
        if (other is FuzzyNumber f)
            return new FuzzyNumber(this.X + f.X, this.L + f.L, this.R + f.R);
        throw new ArgumentException("Invalid type for operation");
    }

    public override Pair Subtract(Pair other)
    {
        if (other is FuzzyNumber f)
            return new FuzzyNumber(this.X - f.X, this.L - f.L, this.R - f.R);
        throw new ArgumentException("Invalid type for operation");
    }

    public override Pair Multiply(Pair other)
    {
        if (other is FuzzyNumber f)
            return new FuzzyNumber(this.X * f.X, this.L * f.L, this.R * f.R);
        throw new ArgumentException("Invalid type for operation");
    }

    public override Pair Divide(Pair other)
    {
        if (other is FuzzyNumber f && f.X != 0 && f.L != 0 && f.R != 0)
            return new FuzzyNumber(this.X / f.X, this.L / f.L, this.R / f.R);
        throw new ArgumentException("Cannot divide by zero or invalid type");
    }

    public override void Print()
    {
        Console.WriteLine($"({X}, {L}, {R})");
    }
}

class Program
{
    static void Main()
    {
        // Тестування Fraction
        Fraction frac1 = new Fraction(2, 50);
        Fraction frac2 = new Fraction(1, 25);
        Pair sumFrac = frac1.Add(frac2);
        sumFrac.Print();

        // Тестування FuzzyNumber
        FuzzyNumber fuzz1 = new FuzzyNumber(3.5, 1.2, 2.1);
        FuzzyNumber fuzz2 = new FuzzyNumber(2.0, 0.8, 1.5);
        Pair sumFuzz = fuzz1.Add(fuzz2);
        sumFuzz.Print();
    }
}
