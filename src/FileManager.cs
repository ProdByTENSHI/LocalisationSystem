namespace LocalisationSystem;

using System.IO;
using System.Text;

public static class FileManager
{
    private const string FILE_PATH = "../../../resources/";

    // Generic Method to write to a Text File
    public static void WriteToFile<T>(T content, string filename)
    {
        string _finalPath = $"{FILE_PATH}{filename}.txt";

        using (StreamWriter _stream = new StreamWriter(_finalPath, true))
        {
            _stream.WriteLine(content);
        }
    }
    
    // Clear File
    public static void ClearFile(string filename)
    {
        string _finalPath = $"{FILE_PATH}{filename}.txt";

        using (StreamWriter _stream = new StreamWriter(_finalPath))
        {
            _stream.Write("");
        }
    }

    // Load a File and returns the Content
    public static string LoadFile(string filename)
    {
        string _finalPath = $"{FILE_PATH}{filename}";
        string _content;

        using (StreamReader _stream = new StreamReader(_finalPath, Encoding.UTF8))
        {
            _content = _stream.ReadToEnd();
        }

        return _content;
    }
}