using MyFruits.Fruits;
using MyFruits.Vegetables;

namespace MyFruits.Common;

public static class ProduceRandom
{
    private static readonly Random _rng = new();

    private static readonly string[] ShapesApple = { "Круглая", "Плоско-круглая" };
    private static readonly string[] ShapesBerry = { "Конус", "Сферическая", "Овальная" };
    private static readonly string[] ShapesPotato = { "Овальная", "Удлинённая" };
    private static readonly string[] ShapesTomato = { "Шарообразная", "Сливовидная" };

    private static readonly string[] WhereGarden = { "Сад", "Плантация" };
    private static readonly string[] WhereBed = { "Грядка", "Теплица" };
    private static readonly string[] WhereField = { "Поле", "Огород" };

    private static readonly string[] AppleVarieties = { "Антоновка", "Синап", "Гала", "Фуджи", "Грэнни Смит", "Голден" };
    private static readonly string[] PotatoVarieties = { "Гала", "Ред Скарлет", "Невский", "Удача", "Жуковский" };

    public static List<ProduceBase> Generate(int fruitsCount, int vegetablesCount)
    {
        var list = new List<ProduceBase>(fruitsCount + vegetablesCount);
        for (int i = 0; i < fruitsCount; i++) list.Add(GenerateFruit());
        for (int i = 0; i < vegetablesCount; i++) list.Add(GenerateVegetable());
        return list;
    }

    private static ProduceBase GenerateFruit()
    {
        return _rng.Next(2) == 0 ? RandomApple() : RandomBerry();
    }

    private static ProduceBase GenerateVegetable()
    {
        return _rng.Next(2) == 0 ? RandomPotato() : RandomTomato();
    }
    private static ProduceColor PickColorExcept(params ProduceColor[] banned)
    {
        var all = (ProduceColor[])Enum.GetValues(typeof(ProduceColor));
        var pool = all.Where(c => !banned.Contains(c)).ToArray();
        return pool[_rng.Next(pool.Length)];
    }

    private static Apple RandomApple()
    {
        var variety = Pick(AppleVarieties);
        var size = NextDouble(5.0, 9.0);
        var shape = Pick(ShapesApple);
        var where = Pick(WhereGarden);
        var price = NextPrice(60m, 180m);
        return new Apple(variety, size, "Яблоко", shape, where, price);
    }

    private static Berry RandomBerry()
    {
        var color = PickColorExcept(ProduceColor.Коричневый);
        var harvest = DateTime.Today.AddDays(-_rng.Next(0, 180));
        var shape = Pick(ShapesBerry);
        var where = Pick(WhereBed);
        var price = NextPrice(150m, 600m);
        var name = Pick(new[] { "Клубника", "Малина", "Черника", "Смородина", "Ежевика" });
        return new Berry(color, harvest, name, shape, where, price);
    }

    private static Potato RandomPotato()
    {
        var variety = Pick(PotatoVarieties);
        var size = NextDouble(4.0, 8.0);
        var shape = Pick(ShapesPotato);
        var where = Pick(WhereField);
        var price = NextPrice(20m, 60m);
        return new Potato(variety, size, "Картофель", shape, where, price);
    }

    private static Tomato RandomTomato()
    {
        var color = PickColorExcept(ProduceColor.Чёрный, ProduceColor.Белый);
        var harvest = DateTime.Today.AddDays(-_rng.Next(0, 120));
        var shape = Pick(ShapesTomato);
        var where = Pick(WhereBed);
        var price = NextPrice(80m, 250m);
        return new Tomato(color, harvest, "Помидор", shape, where, price);
    }

    private static T Pick<T>(IReadOnlyList<T> arr) => arr[_rng.Next(arr.Count)];
    private static double NextDouble(double min, double max) => Math.Round(min + _rng.NextDouble() * (max - min), 2);
    private static decimal NextPrice(decimal min, decimal max)
    {
        var v = (double)min + _rng.NextDouble() * (double)(max - min);
        return Math.Round((decimal)v, 2);
    }
}