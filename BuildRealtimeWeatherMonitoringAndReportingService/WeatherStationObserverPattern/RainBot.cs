using BuildRealtimeWeatherMonitoringAndReportingService.CustomMessages;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;

public class RainBot : IObserver
{
    private readonly string _message;
    public RainBot(string message)
    {
        _message = message;
    }
    public virtual void Display()
    {
        Console.WriteLine(CustomMessage.RainBotMessage);
        Console.WriteLine($"RainBot: \"{_message}\"");
    }
}