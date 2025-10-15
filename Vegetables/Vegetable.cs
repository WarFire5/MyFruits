using MyFruits.Common;

namespace MyFruits.Vegetables;

public abstract class Vegetable : ProduceBase
{
    protected void InitializeVegetable(string name, string shape, string whereGrows, decimal price)
        => InitializeProduce(name, shape, whereGrows, price);
}