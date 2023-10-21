namespace LocalisationSystem;

using System.IO;
using System.Collections.Generic;
using System.Text;
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
    public static string? GetLine(string input, string id)
    {
        var _lines = JsonSerializer.Deserialize<List<Line>>(input, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        Line _line = null;
        
        foreach (Line _l in _lines)
        {
            if (_l.Id == id)
                _line = _l;
        }

        return _line.Content;
    }

    private class Line
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}