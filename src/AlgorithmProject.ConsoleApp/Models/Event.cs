namespace AlgorithmProject.ConsoleApp.Models;

public class Event
{

    public int Id { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Location { get; set; }
    public int Priority { get; set; }

    public Event(int id, string startTime, string endTime, string location, int priority)
    {
        Id = id;
        StartTime = startTime;
        EndTime = endTime;
        Location = location;
        Priority = priority;
    }

}
