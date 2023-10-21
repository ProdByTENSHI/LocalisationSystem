namespace LocalisationSystem;

using System.Collections.Generic;
using System.Text.Json;
public static class LocalisationManager
{
    // Returns a Line by the ID
    public static Line? GetLine(string input, string id)
    {
        List<Line>? _lines = JsonSerializer.Deserialize<List<Line>>(input, new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        Line? _line = null;
        
        foreach (Line _l in _lines)
        {
            if (_l.Id == id)
                _line = _l;
        }

        return _line;
    }

    // Wrapper Class for JSON Data
    public class Line
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}