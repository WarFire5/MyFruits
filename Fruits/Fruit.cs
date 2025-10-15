using MyFruits.Common;

namespace MyFruits.Fruits;

public abstract class Fruit : ProduceBase
{
    protected void InitializeFruit(string name, string shape, string whereGrows, decimal price)
        => InitializeProduce(name, shape, whereGrows, price);
}