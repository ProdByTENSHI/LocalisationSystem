using System.Text;

namespace LocalisationSystem;

using System.IO;
using System.Text.Json;

public static class FileManager
{
    // Load a File and returns the Content
    public static string LoadFile(string filename)
    {
        string _finalPath = $"../../../resources/{filename}";
        string _content;

        using (StreamReader _stream = new StreamReader(_finalPath, Encoding.UTF8))
        {
            _content = _stream.ReadToEnd();
        }

        return _content;
    }

    // Returns a Line by the Identifier
    public static string GetLine(string id)
    {
        string _line = string.Empty;

        return _line;
    }
}