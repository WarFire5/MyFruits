namespace MyFruits.Common;

public static class ErrorHandler
{
    public static void Run(Action action)
    {
        try { action(); }
        catch (Exception ex) { Console.Error.WriteLine($"[Ошибка] {ex.GetType().Name}: {ex.Message}"); }
    }
}