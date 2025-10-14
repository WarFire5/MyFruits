namespace MyFruits.Common;

public static class Guards
{
    public static void EnsureNonNegative(decimal value, string paramName, string? message = null)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(paramName, message ?? "Значение не может быть отрицательным.");
    }
}