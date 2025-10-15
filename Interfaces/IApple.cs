namespace MyFruits.Interfaces;

public interface IApple : IFruitVeget
{
    void SetVariety(string variety);
    void SetAverageSize(double cm);
}