using MyFruits.Common;

namespace MyFruits.Interfaces;

public interface IBerry : IFruitVeget
{
    void SetColor(ProduceColor color);
    void SetHarvestDate(DateTime date);
}