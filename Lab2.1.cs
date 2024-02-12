/// 1. Список з 0-1, знайти найдовшу послідовність і індекси крайніх елементів(Колекції)
/// 2.Знайти максимальне та мінімальне значення словника і записати їх у список. Якщо список пустий, вивести повідомлення. 
/// Якщо словник має кілька максимальних або мінімальних значень, не записувати їх у вихідний список.(Dictionary)
/// 3. Послідовність цілих чисел, всі додатні, двозначні, зростання(LinQ)




namespace Lab2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("As always, 1, 2, 3 - task. 'Exit' for exit");
            while (true)
            {
                string u_input;
                u_input = Console.ReadLine();

                if (u_input.ToLower() == "exit")
                {
                    break;
                }
                else if (u_input.ToLower() == "1")
                {
                    try
                    {
                        Console.WriteLine("Count of elements?");
                        int c = int.Parse(Console.ReadLine());
                        List<int> chain = new List<int>();
                        Random rnd = new Random();
                        for (int i = 0; i < c; i++)
                        {
                            chain.Add(rnd.Next(0, 2));
                        }
                        Indexes(chain);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error. " + e.Message);
                    }
                }
                else if (u_input.ToLower() == "2")
                {
                    try
                    {
                        Dictionary<string, int> dictionary = new Dictionary<string, int>
                        {
                            { "A", 10 },
                            { "B", 20 },
                            { "C", 10 },
                            { "D", 30 },
                            { "E", 20 }
                        };

                        List<int> list = new List<int>();

                        if (dictionary.Any())
                        {
                            int min = dictionary.Values.Min();
                            int max = dictionary.Values.Max();

                            foreach (var pair in dictionary)
                            {
                                if (pair.Value == min && !list.Contains(min))
                                {
                                    list.Add(min);
                                }
                                else if (pair.Value == max && !list.Contains(max))
                                {
                                    list.Add(max);
                                }
                            }
                            Console.WriteLine("Min - " + min);
                            Console.WriteLine("Max - " + max);
                        }
                        else
                        {
                            Console.WriteLine("Dictionary is empty.");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error. " + e.Message);
                    }
                }
                else if (u_input.ToLower() == "3")
                {
                    try
                    {
                        Console.WriteLine("Count of elements?");
                        int c = int.Parse(Console.ReadLine());
                        List<int> chain = new List<int>();
                        Random rnd = new Random();
                        Console.WriteLine("Min and Max values?");
                        int min = int.Parse(Console.ReadLine());
                        int max = int.Parse(Console.ReadLine());
                        for (int i = 0; i < c; i++)
                        {
                            chain.Add(rnd.Next(min, max));
                        }

                        List<int> numbers = chain
                            .Where(num => num >= 10 && num <= 99)
                            .OrderBy(num => num)
                            .Distinct()
                            .ToList();

                        foreach(int num in numbers)
                        {
                            Console.Write(num + "  ");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error. " + e.Message);
                    }
                }
            }
        }
        static void Indexes(List<int> list)
        {
            List<int> longest = new List<int>();
            List<int> current = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if ((i > 0 && list[i] == list[i - 1]) || (i < list.Count - 1 && list[i] == list[i + 1]))
                {
                    current.Add(i);
                }
                else
                {
                    if (current.Count > longest.Count)
                    {
                        longest = new List<int>(current);
                    }
                    current.Clear();
                }
            }
            Console.WriteLine("Indexes in the longest chain:");
            Console.WriteLine(longest[0]);
            Console.WriteLine(longest[longest.Count - 1]);
            Console.WriteLine("Length - " + longest.Count);
        }
    }
}