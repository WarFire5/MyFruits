using MyFruits.Common;

namespace MyFruits.Fruits;

public class Berry : Fruit
{
    public ProduceColor Color { get; private set; }
    public DateTime HarvestDate { get; private set; }
    public bool IsRootVegetable { get; } = false;

    public Berry(ProduceColor color, DateTime harvestDate,
                 string name, string shape, string whereGrows, decimal price)
    {
        InitializeFruit(name, shape, whereGrows, price);
        Color = color;
        HarvestDate = harvestDate;
    }
}