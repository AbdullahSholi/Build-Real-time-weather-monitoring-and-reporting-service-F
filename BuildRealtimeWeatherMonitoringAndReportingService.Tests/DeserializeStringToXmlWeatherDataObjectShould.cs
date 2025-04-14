using System.Xml.Serialization;
using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using BuildRealtimeWeatherMonitoringAndReportingService.Entities;
using Moq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;

public class DeserializeStringToXmlWeatherDataObjectShould
{
    [Theory]
    [InlineData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>")]
    public void DeserializeXmlStringToXmlWeatherDataObject_WhenEnterValidXmlString_ThenReturnCorrectWeatherDataObject(string toDeserialize)
    {
        // Assert
        
        // Act
        var sut = DeserializeStringToXmlWeatherDataObject.DeserializeXmlStringToXmlWeatherDataObject(toDeserialize);
        
        // Assert
        Assert.Equal("City Name", sut.Location);
        Assert.Equal(32, sut.Temperature);
        Assert.Equal(40, sut.Humidity);
    }
    
    [Theory]
    [InlineData("{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}")]
    public void DeserializeXmlStringToXmlWeatherDataObject_WhenEnterInValidXmlString_ThenThrowsException(string toDeserialize)
    {
        // Assert
        
        // Act && Assert
        Assert.Throws<InvalidOperationException>(() => DeserializeStringToXmlWeatherDataObject.DeserializeXmlStringToXmlWeatherDataObject(toDeserialize));
    }
}