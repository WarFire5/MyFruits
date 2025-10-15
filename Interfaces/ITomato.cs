using MyFruits.Common;

namespace MyFruits.Interfaces;

public interface ITomato : IFruitVeget
{
    void SetColor(ProduceColor color);
    void SetHarvestDate(DateTime date);
}