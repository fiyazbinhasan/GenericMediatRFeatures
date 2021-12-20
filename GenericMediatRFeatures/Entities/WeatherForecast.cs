namespace GenericMediatRFeatures.Entities;

public class WeatherForecast : Entity
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}