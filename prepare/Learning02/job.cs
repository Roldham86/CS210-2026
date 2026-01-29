// made by W00f
public class Job
{
// DATA //
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

// FUNCT //
    public void Display()
    {
        Console.WriteLine($"    {_jobTitle} at {_company} ({_startYear} to {_endYear})");
    }
}