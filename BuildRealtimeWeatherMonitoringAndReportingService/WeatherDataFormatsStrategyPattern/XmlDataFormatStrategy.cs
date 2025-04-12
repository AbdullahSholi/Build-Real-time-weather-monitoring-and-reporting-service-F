using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;

namespace BuildRealtimeWeatherMonitoringAndReportingService;

public class XmlDataFormatStrategy : IDataFormatStrategy
{
    public bool CanProcessWeatherData(string weatherData)
    {
        return weatherData.Trim().StartsWith("<") && weatherData.Trim().EndsWith(">");
    }

    public WeatherData ProcessWeatherData(string weatherData)
    {
        WeatherData xmlWeatherData = DeserializeStringToXmlWeatherDataObject.DeserializeXmlStringToXmlWeatherDataObject(weatherData);
        return xmlWeatherData;
    }
}