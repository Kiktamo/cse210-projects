public class Resume
{
    public string _name = "";
    public List<Job> jobs = new List<Job>();

    public Resume()
    {
    }

    public void display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");

        foreach (Job job in jobs) 
        {
            job.display();
        }
    }
}