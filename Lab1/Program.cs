using System;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nОберіть завдання (1-7) або 0 для виходу:");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1: CalculateExpression(); break;
                case 2: EquilateralTriangle(); break;
                case 3: IsIncreasingSequence(); break;
                case 4: TriangleCheck(); break;
                case 5: CountNumbers(); break;
                case 6: FindWords(); break;
                case 7: ReplaceColons(); break;
                case 0: return;
                default: Console.WriteLine("Неправильний вибір!"); break;
            }
        }
    }

    static void CalculateExpression()
    {
        Console.Write("Введіть x: ");
        double x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть y: ");
        double y = Convert.ToDouble(Console.ReadLine());

        double result = x * Math.Log(x) + (y / Math.Cos(x)) - (x / Math.Sqrt(3));
        Console.WriteLine($"Результат: {result}");
    }

    static void EquilateralTriangle()
    {
        Console.Write("Введіть сторону трикутника: ");
        double a = Convert.ToDouble(Console.ReadLine());

        double S = (Math.Sqrt(3) / 4) * a * a;
        double h = (Math.Sqrt(3) / 2) * a;
        double R_in = a / (2 * Math.Sqrt(3));
        double R_out = a / Math.Sqrt(3);

        Console.WriteLine($"Площа: {S}, Висота: {h}, Радіус вписаного: {R_in}, Радіус описаного: {R_out}");
    }

    static void IsIncreasingSequence()
    {
        Console.Write("Введіть чотиризначне число: ");
        int N = Convert.ToInt32(Console.ReadLine());

        int d1 = N / 1000, d2 = (N / 100) % 10, d3 = (N / 10) % 10, d4 = N % 10;
        Console.WriteLine((d1 < d2 && d2 < d3 && d3 < d4) ? "True" : "False");
    }

    static void TriangleCheck()
    {
        Console.Write("Введіть a: ");
        double a = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть b: ");
        double b = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a + b > c && a + c > b && b + c > a)
        {
            double p = (a + b + c) / 2;
            double S = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            Console.WriteLine($"Площа трикутника: {S}");
        }
        else
        {
            Console.WriteLine("Ці числа не можуть бути сторонами трикутника.");
        }
    }

    static void CountNumbers()
    {
        Console.Write("Введіть n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int count = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % 2 != 0 && i % 3 != 0 && i % 5 != 0)
            {
                count++;
            }
        }

        Console.WriteLine($"Кількість таких чисел: {count}");
    }

    static void FindWords()
    {
        Console.Write("Введіть рядок: ");
        string input = Console.ReadLine();
        string[] words = input.Split(new char[] { ' ', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        
        var result = words.Where(word => word.Length > 1 && word[0] == word[^1]);
        Console.WriteLine("Слова, які починаються і закінчуються однаковою буквою:");
        foreach (var word in result) Console.WriteLine(word);
    }

    static void ReplaceColons()
    {
        Console.Write("Введіть рядок: ");
        string input = Console.ReadLine();

        int count = input.Split(':').Length - 1;
        string output = input.Replace(":", ";");

        Console.WriteLine($"Замінений рядок: {output}");
        Console.WriteLine($"Кількість замін: {count}");
    }
}
