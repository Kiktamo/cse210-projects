public class Job
{
    public string _company = "";
    public string _jobTitle = "";
    public int _startYr = 0;
    public int _endYr = 0;

    public Job()
    {
    }

    public void display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYr}-{_endYr}");
    }
}