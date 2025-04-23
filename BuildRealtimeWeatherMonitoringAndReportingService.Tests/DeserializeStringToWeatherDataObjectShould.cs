using BuildRealtimeWeatherMonitoringAndReportingService.Deserialization;
using Newtonsoft.Json;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;

public class DeserializeStringToWeatherDataObjectShould
{
    [Theory]
    [InlineData("{\"Location\": \"City Name\", \"Temperature\": 32, \"Humidity\": 40}")]
    public void DeserializeJsonStringToJsonWeatherDataObject_WhenEnterValidJsonString_ThenReturnCorrectWeatherDataObject(string toDeserialize)
    {
        // Assert
        
        // Act
        var sut = DeserializeStringToWeatherDataObject.DeserializeJsonStringToWeatherDataObject(toDeserialize);
        
        // Assert
        Assert.Equal("City Name", sut.Location);
        Assert.Equal(32, sut.Temperature);
        Assert.Equal(40, sut.Humidity);
    }
    
    [Theory]
    [InlineData("<WeatherData><Location>City Name</Location><Temperature>32</Temperature><Humidity>40</Humidity></WeatherData>")]
    public void DeserializeJsonStringToJsonWeatherDataObject_WhenEnterInValidJsonString_ThenThrowsException(string toDeserialize)
    {
        // Assert
        
        // Act && Assert
        Assert.Throws<JsonReaderException>(() => DeserializeStringToWeatherDataObject.DeserializeJsonStringToWeatherDataObject(toDeserialize));
    }
}