using MyFruits.Common;
using MyFruits.Interfaces;
using System.Text;

namespace MyFruits.Vegetables;

public class Tomato : Vegetable, ITomato
{
    public ProduceColor Color { get; private set; }
    public DateTime HarvestDate { get; private set; }
    public bool IsRootVegetable { get; } = false;

    public Tomato(ProduceColor color, DateTime harvestDate, string name, string shape, string whereGrows, decimal price)
    {
        InitializeVegetable(name, shape, whereGrows, price);
        SetColor(color);
        SetHarvestDate(harvestDate);
    }

    public void SetColor(ProduceColor color) => Color = color;
    public void SetHarvestDate(DateTime date) => HarvestDate = date;

    protected override void AppendDetails(StringBuilder sb)
    {
        sb.AppendLine($"  Цвет: {Color}");
        sb.AppendLine($"  Урожай: {HarvestDate:yyyy-MM-dd}");
        sb.AppendLine($"  Корнеплод: {IsRootVegetable}");
    }
}