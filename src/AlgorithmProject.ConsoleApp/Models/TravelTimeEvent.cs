namespace AlgorithmProject.ConsoleApp.Models;

public class TravelTimeEvent
{

    public string From { get; set; }
    public string To { get; set; }
    public int DurationTime { get; set; }

    public TravelTimeEvent(string from, string to, int durationTime)
    {
        From = from;
        To = to;
        DurationTime = durationTime;
    }

}
