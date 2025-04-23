using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using Newtonsoft.Json.Linq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;

public class WeatherStation : ISubject
{
    private List<IObserver> _observers = new List<IObserver>();
    
    public void AddObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }
    

    public void NotifyObservers()
    {
        for (int i = 0; i < _observers.Count; i++)
        {
            _observers[i].Display();
        }
    }
    
    
}