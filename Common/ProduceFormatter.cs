using MyFruits.Fruits;
using MyFruits.Vegetables;
using System.Globalization;
using System.Text;

namespace MyFruits.Common;

public static class ProduceFormatter
{
    private static readonly CultureInfo Ru = CultureInfo.GetCultureInfo("ru-RU");

    public static string Format(object produce)
    {
        var sb = new StringBuilder();

        switch (produce)
        {
            case Apple a:
                AppendBase(sb, a);
                sb.AppendLine($"  Сорт: {a.Variety}");
                sb.AppendLine($"  Средний размер: {a.AverageSizeCm:0.##} см");
                sb.AppendLine($"  Корнеплод: {a.IsRootVegetable}");
                break;

            case Berry b:
                AppendBase(sb, b);
                sb.AppendLine($"  Цвет: {b.Color}");
                sb.AppendLine($"  Урожай: {b.HarvestDate:yyyy-MM-dd}");
                sb.AppendLine($"  Корнеплод: {b.IsRootVegetable}");
                break;

            case Potato p:
                AppendBase(sb, p);
                sb.AppendLine($"  Сорт: {p.Variety}");
                sb.AppendLine($"  Средний размер: {p.AverageSizeCm:0.##} см");
                sb.AppendLine($"  Корнеплод: {p.IsRootVegetable}");
                break;

            case Tomato t:
                AppendBase(sb, t);
                sb.AppendLine($"  Цвет: {t.Color}");
                sb.AppendLine($"  Урожай: {t.HarvestDate:yyyy-MM-dd}");
                sb.AppendLine($"  Корнеплод: {t.IsRootVegetable}");
                break;

            case IProduce p:
                AppendBase(sb, p);
                break;

            default:
                sb.AppendLine(produce?.ToString() ?? "<null>");
                break;
        }

        return sb.ToString();
    }

    private static void AppendBase(StringBuilder sb, IProduce p)
    {
        sb.AppendLine($"[{p.GetType().Name}]");
        sb.AppendLine($"  Название: {p.Name}");
        sb.AppendLine($"  Форма: {p.Shape}");
        sb.AppendLine($"  Где растёт: {p.WhereGrowsPublic}");
        sb.AppendLine($"  Цена: {p.GetPrice().ToString("C2", Ru)}");
    }
}