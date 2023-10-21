namespace LocalisationSystem;

public class Program
{
    // Key : Language in format -> de, en, es, fr
    // Value: The parsed Content
    private static Dictionary<string, string> content = new Dictionary<string, string>();

    // Supported Languages
    private static readonly string[] Languages = new string[2]
    {
        "en",
        "de"
    };
    
    public static void Main(string[] args)
    {
        // Load Content into Dictionary by Language to reduce File Reading
        foreach (string _lang in Languages)
        {
            content.Add(_lang, FileManager.LoadFile($"{_lang}_test.json"));
            content.TryGetValue(_lang, out string? _output);

            if (_output != null)
            {
                OutputManager.Write($"Loaded Content for Language {_lang}\n", ConsoleColor.Green);
            }
            else
            {
                OutputManager.Write($"Could not load Content for Language {_lang}\n", ConsoleColor.Red);
            }
        }

        Console.WriteLine(FileManager.GetLine(content["de"], "introduction-one"));
        Console.ReadKey(true);
    }
}