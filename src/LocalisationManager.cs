using System.Diagnostics;

namespace LocalisationSystem;

using System.Collections.Generic;
using System.Text.Json;
public static class LocalisationManager
{
    
    // The currently selected Language
    public static string SelectedLanguage { get; private set; } = "invalid";
    
    // The default language
    private const string DEFAULT_LANGUAGE = "en";
    
    // The Naming for the Files(Everything after the Language Indicator. eg: de_FILENAME, en_FILENAME
    private const string FILE_NAME = "_test.json";
    
    // A Dictionary that holds the Content by the Language
    // Key : Language in format -> de, en, es, fr
    // Value: The parsed Content
    private static Dictionary<string, string> content = new Dictionary<string, string>();
    
    // Supported Languages
    private static readonly string[] Languages = new string[3]
    {
        "en",
        "de",
        "fr"
    };

    // Initialize the Selected Language
    public static void Init()
    {
        OutputManager.Write("Avaiable Languages: ", true);
        
        // Load Content into Dictionary by Language to reduce File Reading
        foreach (string _lang in Languages)
        {
            content.Add(_lang, FileManager.LoadFile($"{_lang}{FILE_NAME}"));
            content.TryGetValue(_lang, out string? _output);

            OutputManager.WriteToLog(_output != null
                ? $"Loaded Language Pack for {_lang}"
                : $"Could not load Language Pack {_lang}");
            
            OutputManager.Write(_output != null ? $"{_lang}" : string.Empty, true);
        }
        
        OutputManager.Write("Please select your Language: ", false);
        string? _input = Console.ReadLine();
        
        // Check if Input corresponds to an avaiable Language
        if (Languages.Contains(_input?.ToLower()))
        {
            SelectedLanguage = _input;
        }
        else
        {
            SelectedLanguage = DEFAULT_LANGUAGE;
        }
        
        OutputManager.WriteToLog($"Set the preffered Language to {SelectedLanguage}");
    }
    
    /// <summary>
    /// Returns the Content of a Line by it's ID in the set Language(See SelectedLanguage)
    /// </summary>
    /// <param name="id">The ID of the Line. See more in the Line Class to get more Information on the Structure</param>
    /// <returns></returns>
    public static string GetLine(string id)
    {
        List<Line>? _lines = JsonSerializer.Deserialize<List<Line>>($"{content[SelectedLanguage.ToLower()]}", new JsonSerializerOptions() {PropertyNameCaseInsensitive = true});
        Line? _line = null;
        
        foreach (Line _l in _lines)
        {
            if (_l.Id == id)
                _line = _l;
        }

        return _line?.Content;
    }

    // Wrapper Class for JSON Data
    public class Line
    {
        public string Id { get; set; }
        public string Content { get; set; }
    }
}