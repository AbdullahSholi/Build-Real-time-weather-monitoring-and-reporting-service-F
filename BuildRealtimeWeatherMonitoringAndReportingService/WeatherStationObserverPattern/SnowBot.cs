using BuildRealtimeWeatherMonitoringAndReportingService.CustomMessages;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;

public class SnowBot :IObserver
{
    private readonly string _message;
    public SnowBot(string message)
    {
        _message = message;
    }
    public void Display()
    {
        Console.WriteLine(CustomMessage.SnowBotMessage);
        Console.WriteLine($"SnowBot: \"{_message}\"");
    }

    
}