using BuildRealtimeWeatherMonitoringAndReportingService;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigurationsFileReader reader = new ConfigurationsFileReader();
        reader.ReadConfigurations();
        
        Console.WriteLine(CustomMessage.EnterWeatherData);
        var weatherData = Console.ReadLine();
        Console.WriteLine(weatherData);
        
        
    }
}