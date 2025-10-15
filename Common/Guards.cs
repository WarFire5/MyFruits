namespace MyFruits.Common;

public static class Guards
{
    public static string NotEmpty(string? value, string paramName, string? message = null)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(message ?? "Строка не должна быть пустой.", paramName);
        return value;
    }

    public static double Positive(double value, string paramName, string? message = null)
    {
        if (value <= 0)
            throw new ArgumentOutOfRangeException(paramName, message ?? "Значение должно быть > 0.");
        return value;
    }

    public static decimal NonNegative(decimal value, string paramName, string? message = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(paramName, message ?? "Значение не может быть отрицательным.");
        return value;
    }
}