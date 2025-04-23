namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;

public class DataFormats
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