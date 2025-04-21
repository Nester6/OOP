using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Одновимірний масив
        double[] array = { 0, -5.3, 3.1, 0, 2.7, -1.5, 4.8, 0 };

        // а) Мінімальний елемент масиву
        double minElement = array.Min();
        Console.WriteLine($"Мінімальний елемент: {minElement}");

        // б) Сума елементів між першим і другим додатними числами
        int firstPos = Array.FindIndex(array, x => x > 0);
        int secondPos = Array.FindIndex(array, firstPos + 1, x => x > 0);
        double sumBetween = (firstPos != -1 && secondPos != -1)
            ? array.Skip(firstPos + 1).Take(secondPos - firstPos - 1).Sum()
            : 0;
        Console.WriteLine($"Сума між першим і другим додатними числами: {sumBetween}");

        // Перетворення: спочатку нулі, потім решта
        double[] transformedArray = array.OrderBy(x => x != 0).ToArray();
        Console.WriteLine("Перетворений масив: " + string.Join(", ", transformedArray));

        // 2. Двовимірний масив
        int[,] matrix = {
            { 1,  4,  7 },
            { -2, 5,  8 },
            { -9, 3,  6 }
        };

        Console.WriteLine("Двовимірний масив:");
        PrintMatrix(matrix);

        // а) Порівняння нижніх кутів
        int lowerLeft = matrix[matrix.GetLength(0) - 1, 0]; // Лівий нижній кут
        int lowerRight = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1]; // Правий нижній кут
        Console.WriteLine($"Менший з нижніх кутів: {Math.Min(lowerLeft, lowerRight)}");

        // б) Порівняння верхнього правого і нижнього лівого кута
        int upperRight = matrix[0, matrix.GetLength(1) - 1]; // Верхній правий кут
        Console.WriteLine($"Менший з верхнього правого і нижнього лівого кута: {Math.Min(upperRight, lowerLeft)}");
    }

    // Функція для виводу матриці
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}
