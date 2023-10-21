namespace LocalisationSystem;

public static class OutputManager
{
    private const ConsoleColor DEFAULT_COLOR = ConsoleColor.DarkGray;

    public static void Write(string content, ConsoleColor color = DEFAULT_COLOR)
    {
        Console.ForegroundColor = color;
        Console.Write(content);
        Console.ForegroundColor = DEFAULT_COLOR;
    }
}