using System.IO;

public class PromptGen
{
    List<string> _prompts = new List<string>();

    public PromptGen(string filename = "prompts.txt")
    {
        Load(filename);
    }

    public void Load(string file)
    {
        foreach (string line in File.ReadLines(file))
        {
            _prompts.Add(line);
        }
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();

        int line = random.Next(_prompts.Count);

        return _prompts[line];

    }
}