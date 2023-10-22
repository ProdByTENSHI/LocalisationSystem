namespace LocalisationSystem;

public static class OutputManager
{
    private const string LOG_FILE_NAME = "Debug_Log";
    private const ConsoleColor DEFAULT_COLOR = ConsoleColor.DarkGray;

    public static void Init()
    {
        // Clear the Logger File to remove Logs from old Instances of the Application
        FileManager.ClearFile(LOG_FILE_NAME);
    }
    
    public static void WriteToLog(string content)
    {
        string _currentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        
        FileManager.WriteToFile($"[{_currentTime}] : {content}", LOG_FILE_NAME);
    }

    public static void Write(string content, bool newLine = false, ConsoleColor color = DEFAULT_COLOR)
    {
        Console.ForegroundColor = color;

        if (newLine)
        {
            Console.WriteLine(content);
        }
        else
        {
            Console.Write(content);
        }
        
        Console.ForegroundColor = DEFAULT_COLOR;
    }
}