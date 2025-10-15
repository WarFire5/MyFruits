using MyFruits.Common;
using MyFruits.Interfaces;
using System.Text;

namespace MyFruits.Fruits;

public class Apple : Fruit, IApple
{
    public string Variety { get; private set; } = null!;
    public double AverageSizeCm { get; private set; }
    public bool IsRootVegetable { get; } = false;

    public Apple(string variety, double averageSizeCm, string name, string shape, string whereGrows, decimal price)
    {
        InitializeFruit(name, shape, whereGrows, price);
        SetVariety(variety);
        SetAverageSize(averageSizeCm);
    }

    public void SetVariety(string variety) => Variety = Guards.NotEmpty(variety, nameof(variety));
    public void SetAverageSize(double cm) => AverageSizeCm = Guards.Positive(cm, nameof(cm));

    protected override void AppendDetails(StringBuilder sb)
    {
        sb.AppendLine($"  Сорт: {Variety}");
        sb.AppendLine($"  Средний размер: {AverageSizeCm:0.##} см");
        sb.AppendLine($"  Корнеплод: {IsRootVegetable}");
    }
}