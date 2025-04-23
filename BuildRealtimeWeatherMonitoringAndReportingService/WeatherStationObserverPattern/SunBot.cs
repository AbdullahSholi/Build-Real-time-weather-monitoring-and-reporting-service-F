using BuildRealtimeWeatherMonitoringAndReportingService.CustomMessages;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;

public class SunBot : IObserver
{
    private readonly string _message;
    public SunBot(string message)
    {
        _message = message;
    }
    public virtual void Display()
    {
        Console.WriteLine(CustomMessage.SunBotMessage);
        Console.WriteLine($"SunBot: \"{_message}\"");
    }
}