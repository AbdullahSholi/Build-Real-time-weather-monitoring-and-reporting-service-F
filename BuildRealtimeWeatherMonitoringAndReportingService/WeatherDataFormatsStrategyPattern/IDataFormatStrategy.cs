namespace BuildRealtimeWeatherMonitoringAndReportingService;

public interface IDataFormatStrategy
{
    public bool CanProcessWeatherData(string weatherData);
    public WeatherData ProcessWeatherData(string weatherData);
}