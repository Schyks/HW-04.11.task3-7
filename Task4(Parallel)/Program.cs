using System;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введiть число!");
        string input = Console.ReadLine();
        if (int.TryParse(input, out int number))
        {
            Parallel.Invoke(
            () => Factorial(number),
            () => CountDigits(number),
            () => SumDigits(number)
        );
        }
        else
        {
            Console.WriteLine("Введений рядок не є числом або не є цiлим числом.");
        }

        Console.ReadLine(); 
    }

    static void Factorial(int number)
    {
        long factorial = 1;

        for (int i = 2; i <= number; i++)
        {
            factorial *= i;
        }

        Console.WriteLine($"\nФакторiал числа {number}: {factorial}");
    }

    static void CountDigits(int number)
    {
        int digitCount = number.ToString().Length;

        Console.WriteLine($"\nКiлькiсть цифр у числi {number}: {digitCount}");
    }
    static void SumDigits(int number)
    {
        int sum = number.ToString().Select(c => int.Parse(c.ToString())).Sum();

        Console.WriteLine($"\nСума цифр у числi {number}: {sum}");
    }
    
}
