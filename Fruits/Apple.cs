namespace MyFruits.Fruits;

public class Apple : Fruit
{
    public string Variety { get; private set; } = null!;
    public double AverageSizeCm { get; private set; }
    public bool IsRootVegetable { get; } = false;

    public Apple(string variety, double averageSizeCm,
                 string name, string shape, string whereGrows, decimal price)
    {
        InitializeFruit(name, shape, whereGrows, price);
        Variety = variety;
        AverageSizeCm = averageSizeCm;
    }
}