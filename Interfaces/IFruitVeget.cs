namespace MyFruits.Interfaces;

public interface IFruitVeget
{
    void SetName(string name);
    void SetWhere(string where);
    void SetPrice(decimal price);
    decimal GetPrice();
}