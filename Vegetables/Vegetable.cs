using MyFruits.Common;

namespace MyFruits.Vegetables;

public class Vegetable : IProduce
{
    protected string WhereGrows { get; set; } = null!;
    public string Name { get; protected set; } = null!;
    public string Shape { get; protected set; } = null!;

    public string WhereGrowsPublic => WhereGrows;

    private decimal _price;

    public void SetPrice(decimal value)
    {
        Guards.EnsureNonNegative(value, nameof(value), "Цена не может быть отрицательной.");
        _price = value;
    }
    public decimal GetPrice() => _price;

    protected void InitializeVegetable(string name, string shape, string whereGrows, decimal price)
    {
        Name = name;
        Shape = shape;
        WhereGrows = whereGrows;
        SetPrice(price);
    }

    public virtual string Describe() => ProduceFormatter.Format(this);
}