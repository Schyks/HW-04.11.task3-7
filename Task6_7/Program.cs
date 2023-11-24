internal class Program
{
    private static void Main(string[] args)
    {
        string filePath = "input.txt";
        List<int> nums = NumbersFromFile(filePath);
        PrintList(nums);
        var longestSequenceTask = Task.Run(() =>
        {
            var longestSequenceLength = nums
                .AsParallel()
                .Aggregate(
                    new { Max = 0, Current = 0, Previous = nums.Min() },
                    (a, x) => x > a.Previous
                        ? new { Max = a.Max > a.Current + 1 ? a.Max : a.Current + 1, Current = a.Current + 1, Previous = x }
                        : new { Max = a.Max, Current = 0, Previous = nums.Min() })
                .Max + 1;

            Console.WriteLine($"Довжина найбiльшої зростаючої послiдовностi: {longestSequenceLength}");
        });

        var longestPositiveSequenceTask = Task.Run(() =>
        {
            var longestSequenceLength = nums
                .AsParallel()
                .Aggregate(
                    new { Max = 0, Current = 0 },
                    (a, x) => x > 0
                        ? new { Max = a.Max > a.Current + 1 ? a.Max : a.Current + 1, Current = a.Current + 1 }
                        : new { Max = a.Max, Current = 0 })
                .Max;

            Console.WriteLine($"Довжина найбiльшої додатньої послiдовностi: {longestSequenceLength}");
        });

        Task.WaitAll(longestSequenceTask, longestPositiveSequenceTask);
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
    static void PrintList(List<int> list)
    {
        foreach (var element in list)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}
