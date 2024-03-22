using System.IO;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";

        LoadPrompts();
        LoadQuestions();
    }

    public void Run()
    {
        DisplayStartMsg();

        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);

        ShowCountdown(5);

        DisplayQuestions();

        DisplayEndMsg();
    }

    private string GetRandomPrompt()
    {
        if (_prompts.Count == 0)
            return "Think of a time when you overcame a significant challenge.";

        Random rand = new Random();
        int index = rand.Next(_prompts.Count);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        if (_questions.Count == 0)
            return "What did you learn from this experience?";

        Random rand = new Random();
        int index = rand.Next(_questions.Count);
        return _questions[index];
    }

    private void DisplayPrompt(string prompt)
    {
        Console.WriteLine(prompt);
    }

    private void DisplayQuestions()
    {
        int elapsedTime = 0;
        string lastQuestion = "";
        while (elapsedTime < _duration)
        {
            string question = GetRandomQuestion();
            while (question == lastQuestion)
            {
                question = GetRandomQuestion();
            }

            Console.WriteLine(question);
            ShowSpinner(_duration / 5);
            elapsedTime += _duration / 5;
            lastQuestion = question;
        }
    }

    private void LoadPrompts()
    {
        string filePath = "Reflection_Prompts.txt";
        if (File.Exists(filePath))
        {
            _prompts.AddRange(File.ReadAllLines(filePath));
        }
        else
        {
            _prompts.Add("Think of a time when you stood up for someone else.");
            _prompts.Add("Think of a time when you did something really difficult.");
            _prompts.Add("Think of a time when you helped someone in need.");
            _prompts.Add("Think of a time when you did something truly selfless.");
        }
    }

    private void LoadQuestions()
    {
        string filePath = "Reflection_Questions.txt";
        if (File.Exists(filePath))
        {
            _questions.AddRange(File.ReadAllLines(filePath));
        }
        else
        {
            _questions.Add("Why was this experience meaningful to you?");
            _questions.Add("Have you ever done anything like this before?");
            _questions.Add("How did you get started?");
            _questions.Add("How did you feel when it was complete?");
            _questions.Add("What made this time different than other times when you were not as successful?");
            _questions.Add("What is your favorite thing about this experience?");
            _questions.Add("What could you learn from this experience that applies to other situations?");
            _questions.Add("What did you learn about yourself through this experience?");
            _questions.Add("How can you keep this experience in mind in the future?");
        }
    }
}