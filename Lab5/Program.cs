using System;

class Program
{
    static void Main()
    {
        Console.Write("Введіть рядок: ");
        string input = Console.ReadLine();

        if (IsValidSignedInteger(input))
            Console.WriteLine("Це правильний запис цілого числа зі знаком.");
        else
            Console.WriteLine("Це НЕ правильний запис цілого числа зі знаком.");
    }

    static bool IsValidSignedInteger(string str)
    {
        if (string.IsNullOrEmpty(str))
            return false;

        if (str[0] == '+' || str[0] == '-')
        {
            if (str.Length == 1) 
                return false;
            str = str.Substring(1); 
        }

        foreach (char c in str)
        {
            if (!char.IsDigit(c))
                return false;
        }

        return true;
    }
}
