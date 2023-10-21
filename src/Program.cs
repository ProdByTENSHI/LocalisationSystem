namespace LocalisationSystem;

public class Program
{
    public static void Main(string[] args)
    {
        OutputManager.Write(FileManager.GetLine("introduction-one"));
        Console.ReadKey(true);
    }
}