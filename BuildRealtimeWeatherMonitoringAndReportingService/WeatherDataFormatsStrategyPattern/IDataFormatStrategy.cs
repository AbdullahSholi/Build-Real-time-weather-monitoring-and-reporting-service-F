using BuildRealtimeWeatherMonitoringAndReportingService.Entities;
namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;

public interface IDataFormatStrategy
{
    public bool CanProcessWeatherData(string weatherData);
    public WeatherData ProcessWeatherData(string weatherData);
}