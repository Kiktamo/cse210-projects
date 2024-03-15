public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        foreach (string word in text.Split(" "))
        {
            Word word1 = new Word(word);
            _words.Add(word1);
        }

    }

    public void HideRandomWords(int numberToHide)
    {
        Random ran = new Random();

        for (int i = 0; i <= numberToHide; i++)
        {
            int choice = ran.Next(_words.Count);
            while (_words[choice].isHidden())
            {
                if (isCompletelyHidden())
                {
                    break;
                }
                choice = ran.Next(_words.Count);
            }

            _words[choice].Hide();
            
        }

    }

    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText();

        foreach (Word word in _words)
        {
            text += " " + word.GetDisplayText();
        }

        return text;
    }

    public bool isCompletelyHidden()
    {
        List<bool> totalHidden = new List<bool>();

        foreach (Word word in _words)
        {
            bool hidden = word.isHidden();
            if (hidden)
            {
                totalHidden.Add(hidden);
            }
        }

        if (totalHidden.Count == _words.Count)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}