namespace MyFruits.Common;

public interface IProduce
{
    string Name { get; }
    string Shape { get; }
    string WhereGrowsPublic { get; }
    decimal GetPrice();
}