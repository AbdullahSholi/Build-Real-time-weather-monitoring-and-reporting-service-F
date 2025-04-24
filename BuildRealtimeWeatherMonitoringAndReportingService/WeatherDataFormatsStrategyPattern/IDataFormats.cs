namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;

public interface IDataFormats
{
    List<IDataFormatStrategy> DataFormatStrategies();
}