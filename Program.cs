using MyFruits.Common;
using MyFruits.Fruits;
using MyFruits.Vegetables;
using System.Text;

namespace MyFruits;

internal static class Program
{
    private static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        ErrorHandler.Run(() =>
        {
            var items = new ProduceBase[]
            {
                new Apple ("Антоновка", 7.5, "Яблоко",   "Круглая",     "Сад",     95.90m),
                new Berry (ProduceColor.Красный, new DateTime(2025, 7, 20), "Клубника", "Конус", "Грядка", 299.00m),
                new Potato("Гала", 6.0, "Картофель", "Овальная", "Поле", 45.00m),
                new Tomato(ProduceColor.Красный, new DateTime(2025, 8, 5), "Помидор", "Шарообразная", "Теплица", 139.00m),
            };

            foreach (var p in items)
                ConsoleColorizer.WriteBlockWithColoredColors(p.DescribeVirtual());

            while (true)
            {
                Console.WriteLine();
                Console.Write("Сгенерировать ещё 10 объектов? (да/нет): ");
                var answer = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

                if (IsYes(answer))
                {
                    var more = ProduceRandom.Generate(fruitsCount: 5, vegetablesCount: 5);
                    Console.WriteLine();
                    foreach (var p in more)
                        ConsoleColorizer.WriteBlockWithColoredColors(p.DescribeVirtual());
                    continue;
                }
                if (IsNo(answer))
                {
                    Console.WriteLine("\nПока!");
                    break;
                }
                // непонятный ввод — спрашиваем ещё раз
            }
        });
    }
    static bool IsYes(string s) =>
        s is "да" or "д" or "y" or "yes" or "ага" or "ок" or "lf"; 

    static bool IsNo(string s) =>
        s is "нет" or "н" or "no" or "не" or "yas";
}