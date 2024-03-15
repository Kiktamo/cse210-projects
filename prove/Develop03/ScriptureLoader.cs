using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Nodes;

public class ScriptureLoader
{
    private string _file;
    private JsonNode _json;
    private int _length;
    private int _start;
    private int _end;
    private Random ran = new Random();
    

    private JsonSerializerOptions _options = new JsonSerializerOptions { WriteIndented = true };

    public ScriptureLoader(string file)
    {
        _file = file;
        string fileText = File.ReadAllText(_file);

        _json = JsonNode.Parse(fileText)!;

        _length = _json!.AsArray().Count();
    }


    public void ChoseScriptures()
    {
        _start = ran.Next(_length);

        _end = _start + ran.Next(5);

        if (_end > _length)
        {
            _end = _length;
        }
        while (_json![_start]!["book_title"].ToString() != _json![_end]!["book_title"].ToString())
        {
            _end -= 1;
        }

    }



    public string GetText()
    {
        string text = "";

        for (int i = _start; i <= _end; i++)
        {
            text += _json![i]!["scripture_text"].ToString();  
        }

        return text;
    }

    public Reference GetReference()
    {
        string book = _json![_start]!["book_title"].ToString();
        int chapter = (int)_json![_start]!["chapter_number"];
        int verse = (int)_json![_start]!["verse_number"];
        int endVerse = (int)_json![_end]!["verse_number"];

        if (verse != endVerse)
        {
            return new Reference(book, chapter, verse, endVerse);
        }
        else
        {
            return new Reference(book, chapter, verse);
        }

    }



}