using System.IO;
using System.Text.Json;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public bool _saved = false;
    public string _filePath = "journal.json";

    public void Save()
    {
        Console.WriteLine("Choose a file name.");
        Console.Write("> ");
        
        string filename = Console.ReadLine();
        
        _filePath = filename + ".json";

        if (_entries.Count == 0)
        {
            return;
        }

        _entries.Sort((entry1, entry2) => DateTime.Compare(entry1._date, entry2._date)); // Ensure the journal is sorted properly

        using (StreamWriter writer = new StreamWriter(_filePath))
        {
                string jsonData = JsonSerializer.Serialize(_entries);
                writer.Write(jsonData);
        }
        _saved = true;
    }

    public void Load()
    {
        Console.WriteLine("Load which journal?");
        Console.Write("> ");
        _filePath = Console.ReadLine();

        if (File.Exists(_filePath))
        {
            using (StreamReader reader = new StreamReader(_filePath))
            {
                    string jsonData = reader.ReadToEnd();
                    _entries = JsonSerializer.Deserialize<List<Entry>>(jsonData);
            }
                _saved = true;
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }

    public void Display()
    {
        string today = DateTime.Now.ToShortDateString();
        _entries.Sort((entry1, entry2) => DateTime.Compare(entry1._date, entry2._date)); // Ensure the journal is sorted properly

        Console.WriteLine($"Journal - Today: {today}");

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }

    }

    public void AddEntry()
    {
        Entry entry = new Entry();

        entry.Write();

        _entries.Add(entry);

        _saved = false;
    }

    public bool isSaved()
    {
        return _saved;
    }
}