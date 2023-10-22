namespace LocalisationSystem;

public static class Program
{
    public static void Main(string[] args)
    {
        // INIT
        OutputManager.Init();
        LocalisationManager.Init();

        OutputManager.Write(LocalisationManager.GetLine("introduction-one"));
        
        Console.ReadKey(true);
    }
}