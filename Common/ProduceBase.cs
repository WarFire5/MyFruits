using MyFruits.Interfaces;
using System.Globalization;
using System.Text;

namespace MyFruits.Common
{
    public abstract class ProduceBase : IFruitVeget
    {
        protected string WhereGrows { get; set; } = null!;
        public string Name { get; protected set; } = null!;
        public string Shape { get; protected set; } = null!;

        public decimal Price { get; private set; }

        public void SetName(string name) =>
            Name = Guards.NotEmpty(name, nameof(name));

        public void SetWhere(string where) =>
            WhereGrows = Guards.NotEmpty(where, nameof(where));

        public void SetPrice(decimal price) =>
            Price = Guards.NonNegative(price, nameof(price));

        public decimal GetPrice() => Price;

        protected void InitializeProduce(string name, string shape, string whereGrows, decimal price)
        {
            SetName(name);
            Shape = shape;
            SetWhere(whereGrows);
            SetPrice(price);
        }

        public virtual string DescribeVirtual()
        {
            var ru = CultureInfo.GetCultureInfo("ru-RU");
            var sb = new StringBuilder();
            sb.AppendLine($"[{GetType().Name}]");
            sb.AppendLine($"  Название: {Name}");
            sb.AppendLine($"  Форма: {Shape}");
            sb.AppendLine($"  Где растёт: {WhereGrows}");
            sb.AppendLine($"  Цена: {Price.ToString("C2", ru)}");
            AppendDetails(sb);
            return sb.ToString();
        }

        protected abstract void AppendDetails(StringBuilder sb);
    }
}