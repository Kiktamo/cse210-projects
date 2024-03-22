public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public void Run()
    {
        DisplayStartMsg();

        int breathDuration = _duration / 4;
        int breathCount = 0;

        while (breathCount < _duration)
        {
            Console.WriteLine("\nBreathe in...");
            ShowCountdown(breathDuration);
            breathCount += breathDuration;

            if (breathCount >= _duration)
                break;

            Console.WriteLine("\nBreathe out...");
            ShowCountdown(breathDuration);
            breathCount += breathDuration;
        }

        DisplayEndMsg();
    }
}