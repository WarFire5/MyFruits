namespace MyFruits.Interfaces;

public interface IPotato : IFruitVeget
{
    void SetVariety(string variety);
    void SetAverageSize(double cm);
}