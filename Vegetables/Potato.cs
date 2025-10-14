namespace MyFruits.Vegetables;

public class Potato : Vegetable
{
    public string Variety { get; private set; } = null!;
    public double AverageSizeCm { get; private set; }
    public bool IsRootVegetable { get; } = true;

    public Potato(string variety, double averageSizeCm,
                  string name, string shape, string whereGrows, decimal price)
    {
        InitializeVegetable(name, shape, whereGrows, price);
        Variety = variety;
        AverageSizeCm = averageSizeCm;
    }
}