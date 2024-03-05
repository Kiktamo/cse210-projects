using System;

class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume();

        resume._name = "Jack Hunt";

        Job job1 = new Job();
        Job job2 = new Job();

        job1._jobTitle = "Student Researcher";
        job1._company = "Google";
        job1._startYr = 2015;
        job1._endYr = 2017;

        job2._jobTitle = "Software Engineer";
        job2._company = "Google";
        job2._startYr = 2017;
        job2._endYr = 2020;

        resume.jobs.Add(job1);
        resume.jobs.Add(job2);

        resume.display();

    }
}