namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;

public class DataFormats : IDataFormats
{
    
    public List<IDataFormatStrategy> DataFormatStrategies()
    {
        return new List<IDataFormatStrategy>
        {
            new XmlDataFormatStrategy(),
            new JsonDataFormatStrategy()
        };
    }
}