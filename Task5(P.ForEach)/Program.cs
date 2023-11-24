using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        string filePath = "input.txt"; 
        List<int> numbers = NumbersFromFile(filePath);
        Parallel.ForEach(numbers, (number) =>
        {
            long factorial = Factorial(number);
            Console.WriteLine($"Факторiал числа {number}: {factorial}");
        });
        Console.ReadLine(); 
    }

    static List<int> NumbersFromFile(string filePath)
    {
        List<int> numbers = new List<int>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (int.TryParse(line, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"Помилка: '{line}' не є цiлим числом.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка при зчитуваннi з файлу: {ex.Message}");
        }
        return numbers;
    }

    static long Factorial(int number)
    {
        long factorial = 1;

        for (int i = 2; i <= number; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}
