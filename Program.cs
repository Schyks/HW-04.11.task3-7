using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Random random = new Random();
        int length = 30;
        List<int> list = new List<int>();

        for (int i = 0; i < length; i++)
        {
            int numb = random.Next(0, 100);
            list.Add(numb);
        }

        Task.Run(() =>
       {
           Console.WriteLine("Початковий список:");
           PrintList(list);
       })
       .ContinueWith(task => RemoveDuplicates(list))
       .ContinueWith(task =>
       {
           Console.WriteLine("\nСписок пiсля видалення дубльованих значень:");
           PrintList(list);
       })
       .ContinueWith(task => SortList(list))
       .ContinueWith(task =>
       {
           Console.WriteLine("\nСписок пiсля сортування:");
           PrintList(list);
       })
       .ContinueWith(task =>
       {
           Console.WriteLine("\nВведiть число для пошуку");
           string input = Console.ReadLine();
           int number = int.Parse(input);
           return BinarySearch(list, number);
       })
       .ContinueWith(task =>
       {
           int result = task.Result;
           if (result != -1)
               Console.WriteLine($"\nБiнарний пошук для значення = {result}");
           else Console.WriteLine("Даного числа немає в списку!");
       })
       .Wait();
    }

    static void PrintList(List<int> list)
    {
        foreach (var element in list)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static void RemoveDuplicates(List<int> list)
    {
        var uniqueList = list.Distinct().ToList();
        list.Clear();
        list.AddRange(uniqueList);
    }

    static void SortList(List<int> list)
    {
        list.Sort();
    }

    static int BinarySearch(List<int> list, int target)
    {
        int left = 0;
        int right = list.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (list[mid] == target)
                return mid + 1;

            if (list[mid] < target)
                left = mid + 1;
            else
                right = mid - 1;
        }
        return -1;
    }
}



