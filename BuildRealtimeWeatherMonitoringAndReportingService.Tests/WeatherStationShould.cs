using BuildRealtimeWeatherMonitoringAndReportingService.WeatherStationObserverPattern;
using Moq;

namespace BuildRealtimeWeatherMonitoringAndReportingService.Tests;


public class WeatherStationShould
{
    [Fact]
    public void AddObserver_WhenProvideValidObserver_ThenObserverAddedSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        var sut = new WeatherStation();

        // Act
        sut.AddObserver(mockObserver.Object);        
        
        // Assert
        Assert.Single(sut.GetObservers());
    }

    [Fact]
    public void RemoveObserver_WhenProvideValidObserver_ThenObserverRemovedSuccessfully()
    {
        // Arrange
        var mockObserver1 = new Mock<IObserver>();
        var mockObserver2 = new Mock<IObserver>();
        
        var sut = new WeatherStation();
        sut.AddObserver(mockObserver1.Object); 
        sut.AddObserver(mockObserver2.Object); 
        
        // Act
        sut.RemoveObserver(mockObserver2.Object);
        
        // Assert
        Assert.Single(sut.GetObservers());
    }

    [Fact]
    public void NotifyObserver_WhenProvideValidObservers_ThenObserverNotifiedSuccessfully()
    {
        // Arrange
        var mockObserver = new Mock<IObserver>();
        var sut = new WeatherStation();
        sut.AddObserver(mockObserver.Object);
        
        // Act
        sut.NotifyObservers();
        
        // Assert
        mockObserver.Verify(s => s.Display(), Times.Once);
    }
}