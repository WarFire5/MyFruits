using MyFruits.Common;

namespace MyFruits.Vegetables;

public class Tomato : Vegetable
{
    public ProduceColor Color { get; private set; }
    public DateTime HarvestDate { get; private set; }
    public bool IsRootVegetable { get; } = false;

    public Tomato(ProduceColor color, DateTime harvestDate,
                  string name, string shape, string whereGrows, decimal price)
    {
        InitializeVegetable(name, shape, whereGrows, price);
        Color = color;
        HarvestDate = harvestDate;
    }
}