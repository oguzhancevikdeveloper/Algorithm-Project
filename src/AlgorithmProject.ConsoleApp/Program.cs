using AlgorithmProject.ConsoleApp.Models;

List<Event> events = new List<Event>()
{
    new Event(id:1,startTime:"10:00",endTime:"12:00",location:"A",priority:50),
    new Event(id:1,startTime:"10:00",endTime:"11:00",location:"B",priority:30),
    new Event(id:1,startTime:"11:30",endTime:"12:30",location:"A",priority:40),
    new Event(id:1,startTime:"14:30",endTime:"16:00",location:"C",priority:70),
    new Event(id:1,startTime:"14:25",endTime:"15:30",location:"B",priority:60),
    new Event(id:1,startTime:"13:00",endTime:"14:00",location:"D",priority:80)
};

List<TravelTimeEvent> travelTimeMatrices = new List<TravelTimeEvent>
{
    new TravelTimeEvent(from:"A",to :"B", durationTime:15),
    new TravelTimeEvent(from:"A",to :"C", durationTime:20),
    new TravelTimeEvent(from:"A",to :"D", durationTime:10),
    new TravelTimeEvent(from:"B",to :"C", durationTime:5),
    new TravelTimeEvent(from:"B",to :"D", durationTime:25),
    new TravelTimeEvent(from:"C",to :"D", durationTime:25),

};