using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using BuildRealtimeWeatherMonitoringAndReportingService.Entities;

namespace BuildRealtimeWeatherMonitoringAndReportingService.WeatherDataFormatsStrategyPattern;


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