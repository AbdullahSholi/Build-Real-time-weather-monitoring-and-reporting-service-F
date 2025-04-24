using System.Xml.Serialization;
using BuildRealtimeWeatherMonitoringAndReportingService.Entities;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;

public class DeserializeStringToXmlWeatherDataObject
{
    public static WeatherData DeserializeXmlStringToXmlWeatherDataObject(string toDeserialize)
    { 
        XmlSerializer deserializer =
            new XmlSerializer(typeof(WeatherData));
        WeatherData weatherData = (WeatherData)deserializer.Deserialize(new StringReader(toDeserialize));
        return weatherData;
    }
}