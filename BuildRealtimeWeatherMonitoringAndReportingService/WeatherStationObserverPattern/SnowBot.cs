using BuildRealtimeWeatherMonitoringAndReportingService.CustomMessages;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;

public class SnowBot :IObserver
{
    private readonly string _message;
    public SnowBot(string message)
    {
        _message = message;
    }
    public virtual void Display()
    {
        Console.WriteLine(CustomMessage.SnowBotMessage);
        Console.WriteLine($"SnowBot: \"{_message}\"");
    }

    
}