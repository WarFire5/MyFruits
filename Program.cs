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
            var items = new object[]
            {
                new Apple("Антоновка", 7.5, "Яблоко", "Круглая", "Сад", 95.90m),
                new Berry(ProduceColor.Красный, new DateTime(2025, 7, 20), "Клубника", "Конус", "Грядка", 299.00m),
                new Potato("Гала", 6.0, "Картофель", "Овальная", "Поле", 45.00m),
                new Tomato(ProduceColor.Красный, new DateTime(2025, 8, 5), "Помидор", "Шарообразная", "Теплица", 139.00m)
            };

            foreach (var it in items)
            {
                Console.WriteLine(ProduceFormatter.Format(it));
            }
        });
    }
}